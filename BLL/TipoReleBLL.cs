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
    public class TipoReleBLL : BaseBLL<TipoRele>
    {
        public TipoReleBLL(string table):base(table)
        {
        }

        public List<TipoRele> getAllCustom()
        {
            List<TipoRele> listTipoRele = new List<TipoRele>();

            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT * FROM " + table);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listTipoRele.Add(ConvertToClass(dt.Rows[i]));
            }

            return listTipoRele;
        }

        public override TipoRele ConvertToClass(DataRow row)
        {
            TipoRele obj = new TipoRele();
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
