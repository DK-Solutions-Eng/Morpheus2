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
    public class ComandoBLL : BaseBLL<Comando>
    {
        public ComandoBLL(string table):base(table)
        {
        }

        public List<Comando> getCustomTipoComando(string tipo_comando)
        {
            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT * FROM " + table + " com left join TipoComando tipo on com.tipo = tipo.id WHERE tipo.nome = '" + tipo_comando + "'");
            List<Comando> list = new List<Comando>();
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

        public override DataTable getAll(string filtro, string campopesquisa)
        {
            DAOGeral daogeral = new DAOGeral();
            DataTable dt = daogeral.executaComRetorno("SELECT TABLEX.ID,TABLEX.CODIGO_COMANDO,TABLEX.DESCRICAO_COMANDO,TIPO.NOME AS TIPO FROM " + table + " TABLEX LEFT JOIN TIPOCOMANDO TIPO ON TABLEX.TIPO = TIPO.ID " + (filtro != "" ? " WHERE " + campopesquisa + " LIKE '" + filtro + "%'" : "") + " ORDER BY ID");
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
        public override Comando ConvertToClass(DataRow row)
        {
            Comando obj = new Comando();
            obj.id = Convert.ToInt32(row["id"].ToString());
            obj.codigo_comando = row["codigo_comando"].ToString();
            obj.descricao_comando = row["descricao_comando"].ToString();
            obj.tipo = Convert.ToInt32(row["tipo"].ToString());
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
