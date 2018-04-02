using System;
using System.Data;

namespace Entidades
{
    public class Usuario : Base
    {
        public string usuario { get; set; }
        public string senha { get; set; }
  
        public Usuario convertToUsuario(DataRow row)
        {
            Usuario objusuario = new Usuario();
            objusuario.id = Convert.ToInt32(row["id"].ToString());
            objusuario.usuario = row["usuario"].ToString();
            objusuario.senha = row["senha"].ToString();
            return objusuario;
        }
    }
}
