using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using BLL;

namespace SysBalanca
{
    public partial class frmLogin : Form
    {
        UsuarioBLL bll = new UsuarioBLL("Usuario");
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cboUsuario.Focus();
            carregaUsuarios();
        }

        public void carregaUsuarios()
        {
            List<Usuario> listusuarios = bll.consultaUsuarios();
            foreach (Usuario objusuario in listusuarios)
            {
                cboUsuario.Items.Add(objusuario.usuario.ToUpper());
            }
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            validaUsuario();
        }

        public void validaUsuario()
        {
            if (cboUsuario.SelectedIndex == -1)
            {
                MessageBox.Show("Informe o nome do usuário para logar!");
                return;
            }
            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                MessageBox.Show("Informe a senha para logar!");
                return;
            }

            Usuario objusuario = bll.consultaUsuarioAutenticacao(cboUsuario.SelectedItem.ToString(), txtSenha.Text);
            if (objusuario.id == 0)
            {
                MessageBox.Show("Nome do usuário ou senha incorretos!");
            }
            else
            {
                frmPrincipal princ = new frmPrincipal(objusuario);
                //oculta o FORM login
                this.Hide();
                //abre o FORM principal
                princ.ShowDialog();
            }
        }

        private void txtSenha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validaUsuario();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
