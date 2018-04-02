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
    public partial class frmCadUsuarios : Form
    {
        UsuarioBLL bll = new UsuarioBLL("Usuario");
        Usuario obj;
        public frmCadUsuarios()
        {
            InitializeComponent();
            atualiza("");
        }

        public void atualiza(string filtro)
        {
            int linhaSelecionada = 0, primeiraLinha = 0;
            if (gridUsuarios.CurrentRow != null)
            {
                primeiraLinha = gridUsuarios.FirstDisplayedScrollingRowIndex;
                linhaSelecionada = gridUsuarios.CurrentRow.Index;
            }
            gridUsuarios.DataSource = bll.getAll(filtro,"usuario");
            gridUsuarios.Refresh(); 
        }

        private void txtPesq_KeyUp(object sender, KeyEventArgs e)
        {
            atualiza(txtPesq.Text);

            if (e.KeyCode == Keys.Enter)
            {
                if (gridUsuarios.Rows.Count == 0)
                {
                    tabControl1.SelectedIndex = 1;
                    limpa();
                    txtUsuario.Text = txtPesq.Text;
                    txtSenha.Focus();
                }
            }
        }

        public void limpa()
        {
            txtCodigo.Clear();
            txtSenha.Clear();
            txtUsuario.Clear();
        }

        public void mostrar(Usuario objusuario)
        {
            obj = objusuario;
            txtCodigo.Text = objusuario.id.ToString();
            txtUsuario.Text = objusuario.usuario;
            txtSenha.Text = objusuario.senha;
            tabControl1.SelectedIndex = 1;
        }

        private void gridUsuarios_DoubleClick(object sender, EventArgs e)
        {
            Usuario objusuario = bll.get(Convert.ToInt32(gridUsuarios.Rows[gridUsuarios.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
            mostrar(objusuario);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Informe o usuário!");
                return;
            }

            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                MessageBox.Show("Informe a senha!");
                return;
            }

            Usuario objusuario = new Usuario();
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                objusuario.usuario = txtUsuario.Text;
                objusuario.senha = txtSenha.Text;
                objusuario.dateinsert = DateTime.Now;
                bll.insert(objusuario);
                MessageBox.Show("Usuário cadastrado com sucesso!");
            }
            else
            {
                objusuario.id = Convert.ToInt32(txtCodigo.Text);
                objusuario.usuario = txtUsuario.Text;
                objusuario.senha = txtSenha.Text;
                objusuario.dateinsert = obj.dateinsert;
                objusuario.dateupdate = DateTime.Now;
                bll.update(objusuario);
                MessageBox.Show("Usuário atualizado com sucesso!");
            }
            tabControl1.SelectedIndex = 0;
            atualiza("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Selecione um usuário para excluir!");
                return;
            }

            bll.delete(Convert.ToInt32(txtCodigo.Text));
            MessageBox.Show("Usuário excluído com sucesso!");
            tabControl1.SelectedIndex = 0;
            atualiza("");
            limpa();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            atualiza("");
            txtPesq.Focus();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            limpa();
            txtUsuario.Focus();
        }
    }
}
