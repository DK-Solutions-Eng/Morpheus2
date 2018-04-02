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
    public class ConfiguracaoBLL : BaseBLL<Configuracao>
    {
        public ConfiguracaoBLL(string table):base(table)
        {
        }

        public List<Configuracao> getAllCustom()
        {
            List<Configuracao> list = new List<Configuracao>();

            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT * FROM " + table);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(ConvertToClass(dt.Rows[i]));
            }

            return list;
        }

        public override Configuracao ConvertToClass(DataRow row)
        {
            Configuracao obj = new Configuracao();
            obj.id = Convert.ToInt32(row["id"].ToString());
            obj.porta_arduino= row["porta_arduino"].ToString();
            obj.baud_rate = Convert.ToInt32(row["baud_rate"].ToString());
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
