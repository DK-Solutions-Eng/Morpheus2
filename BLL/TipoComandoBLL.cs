using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAL;

namespace BLL
{
    public class TipoComandoBLL : BaseBLL<TipoComando>
    {
        public TipoComandoBLL(string table):base(table)
        {
        }

        public List<TipoComando> getAllCustom()
        {
            List<TipoComando> list = new List<TipoComando>();

            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT * FROM " + table);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(ConvertToClass(dt.Rows[i]));
            }

            return list;
        }
        public override TipoComando ConvertToClass(DataRow row)
        {
            TipoComando obj = new TipoComando();
            obj.id = Convert.ToInt32(row["id"].ToString());
            obj.nome = row["nome"].ToString();
            if(row["dateinsert"].ToString() == "")
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
