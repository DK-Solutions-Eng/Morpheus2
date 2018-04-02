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
    public class UsuarioBLL : BaseBLL<Usuario>
    {
        public UsuarioBLL(string table):base(table)
        {

        }
        public override Usuario ConvertToClass(DataRow row)
        {
            Usuario obj = new Usuario();
            obj.id = Convert.ToInt32(row["id"].ToString());
            obj.usuario = row["usuario"].ToString();
            obj.senha = row["senha"].ToString();
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

        public List<Usuario> consultaUsuarios()
        {
            List<Usuario> listusuario = new List<Usuario>();
            DAOGeral daogeral = new DAOGeral();
            Usuario objusuario;
            DataTable dtusuario = daogeral.executaComRetorno("select * from " + table + " order by usuario");
            if (dtusuario.Rows.Count > 0)
            {
                for (int i = 0; i < dtusuario.Rows.Count; i++)
                {
                    objusuario = new Usuario();
                    objusuario = objusuario.convertToUsuario(dtusuario.Rows[i]);
                    listusuario.Add(objusuario);
                }
            }
            return listusuario;
        }

        public Usuario consultaUsuarioAutenticacao(string usuario,string senha)
        {
            DAOGeral daogeral = new DAOGeral();
            Usuario objusuario = new Usuario(); ;
            DataTable dtusuario = daogeral.executaComRetorno("select * from " + table + " where usuario = '" + usuario + "' and senha = '" + senha + "' order by usuario");
            if (dtusuario.Rows.Count > 0)
            {
                objusuario = objusuario.convertToUsuario(dtusuario.Rows[0]);
            }
            return objusuario;
        }
    }
}
