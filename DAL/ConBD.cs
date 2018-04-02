using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class Conexao
    {
        private String connectionString;
        private SqlConnection connection;

        private SqlCommand command;

        private static string m_conexaobd = "";

        public static string conexaobd
        {

            get { return m_conexaobd; }

            set { m_conexaobd = value; }

        }

        private static string m_banco = "";

        public static string banco
        {

            get { return m_banco; }

            set { m_banco = value; }

        }

        private static string m_senha = "";

        public static string senha
        {

            get { return m_senha; }

            set { m_senha = value; }

        }

        public void open()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["stringdeconexao"].ToString();
            this.connection = new SqlConnection(this.connectionString);
            this.connection.Open();
        }

        public void close()
        {
            if (this.connection.Equals(null) == false)
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }
        }

        public System.Data.DataTable executeGetResult(string query)
        {
            DataTable dataTable;
            SqlDataReader dataReader;
            dataTable = new DataTable();
            this.command = new SqlCommand(query, connection);
            dataReader = this.command.ExecuteReader(CommandBehavior.CloseConnection);
            dataTable.Load(dataReader, LoadOption.OverwriteChanges);
            dataReader.Close();
            dataReader.Dispose();
            return (dataTable);
        }        

        public void execute(string query)
        {

            SqlCommand command = this.connection.CreateCommand();
            SqlTransaction transaction;

            // Start a local transaction.
            transaction = this.connection.BeginTransaction("TransactionExecute");

            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            command.Connection = this.connection;
            command.Transaction = transaction;        
            command.CommandText = query;
            command.ExecuteNonQuery();
            // Attempt to commit the transaction.
            transaction.Commit();          
        }
    }
}
