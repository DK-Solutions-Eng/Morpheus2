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
    public class ReleBLL : BaseBLL<Rele>
    {
        public ReleBLL(string table):base(table)
        {
        }

        public List<Rele> getCustomListRele()
        {
            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT ID,CODIGO,(CODIGO + '-' + NOME) AS NOME,TIPO,DATEINSERT,DATEUPDATE FROM " + table + " ORDER BY ID");
            List<Rele> list = new List<Rele>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(ConvertToClass(dt.Rows[i]));
                }

                return list;

            }
            return null;
        }

        public Rele getCustomReleCodigo(string codigo)
        {
            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT * FROM " + table + " WHERE CODIGO = '" + codigo + "' ORDER BY ID");
            Rele obj = new Rele();
            if (dt.Rows.Count > 0)
            {

                obj = ConvertToClass(dt.Rows[0]);
                return obj;

            }
            return null;
        }

        public override DataTable getAll(string filtro, string campopesquisa)
        {
            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT TABLEX.ID,TABLEX.CODIGO,TABLEX.NOME,TIPO.NOME AS TIPO FROM " + table + " TABLEX LEFT JOIN TIPORELE TIPO ON TABLEX.TIPO = TIPO.ID " + (filtro != "" ? " WHERE " + campopesquisa + " LIKE '" + filtro + "%'" : "") + " ORDER BY ID");
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
        public override Rele ConvertToClass(DataRow row)
        {
            Rele obj = new Rele();
            obj.id = Convert.ToInt32(row["id"].ToString());
            obj.codigo = row["codigo"].ToString();
            obj.nome = row["nome"].ToString();
            obj.tipo = Convert.ToInt32(row["tipo"].ToString());
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
