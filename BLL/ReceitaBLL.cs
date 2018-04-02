using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using DAL;

namespace BLL
{
    public class ReceitaBLL : BaseBLL<Receita>
    {
        public ReceitaBLL(string table):base(table)
        {
        }

        public Receita getCustomUltimo()
        {
            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT TOP 1 * FROM " + table + " ORDER BY ID DESC");
            if (dt.Rows.Count > 0)
            {
                return ConvertToClass(dt.Rows[0]);
            }
            return null;
        }

        public override Receita ConvertToClass(DataRow row)
        {
            Receita obj = new Receita();
            obj.id = Convert.ToInt32(row["id"].ToString());
            obj.nome = row["nome"].ToString();
            if (row["dateinsert"].ToString() == "")
            {
                obj.dateinsert = null;
            }
            else
            {
                obj.dateinsert = Convert.ToDateTime(row["dateinsert"].ToString());
            }
            if (row["dateupdate"].ToString() == "")
            {
                obj.dateupdate = null;
            }
            else
            {
                obj.dateupdate = Convert.ToDateTime(row["dateupdate"].ToString());
            }
            return obj;
        }
    }
}
