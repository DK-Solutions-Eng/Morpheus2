using System;
using System.Data;

namespace Entidades
{
    public class Log
    {
        public int id { get; set; }
        public string descricao_erro { get; set; }
        public string data_execucao { get; set; }

        public Log convertToLog(DataRow row)
        {
            Log objlog = new Log();
            objlog.id = Convert.ToInt32(row["id"].ToString());
            objlog.descricao_erro = row["descricao_erro"].ToString();
            objlog.data_execucao = row["data_execucao"].ToString();
            return objlog;
        }
    }
}
