using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using BLL;

namespace SysBalanca
{
    public partial class frmCadTipoComando : Form
    {
        TipoComandoBLL bll = new TipoComandoBLL("TipoComando");
        TipoComando obj;
        public frmCadTipoComando()
        {
            InitializeComponent();
            atualiza("");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            limpa();
            txtNome.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do Tipo de Comando!");
                return;
            }

            TipoComando obj = new TipoComando();
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                obj.nome = txtNome.Text;
                obj.dateinsert = DateTime.Now;
                bll.insert(obj);
                MessageBox.Show("Tipo de Comando cadastrado com sucesso!");
            }
            else
            {
                obj.id = Convert.ToInt32(txtCodigo.Text);
                obj.nome = txtNome.Text;
                obj.dateupdate = DateTime.Now;
                obj.dateinsert = this.obj.dateinsert;
                bll.update(obj);
                MessageBox.Show("Tipo de Comando atualizado com sucesso!");
            }
            tabControl1.SelectedIndex = 0;
            atualiza("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Selecione um usuário para excluir!");
                return;
            }

            bll.delete(Convert.ToInt32(txtCodigo.Text));
            MessageBox.Show("Tipo de Comando excluído com sucesso!");
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

        private void txtPesq_KeyUp(object sender, KeyEventArgs e)
        {
            atualiza(txtPesq.Text);

            if (e.KeyCode == Keys.Enter)
            {
                if (grid.Rows.Count == 0)
                {
                    tabControl1.SelectedIndex = 1;
                    limpa();
                    txtNome.Text = txtPesq.Text;
                    txtNome.Focus();
                }
            }
        }

        public void limpa()
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }

        public void mostrar(TipoComando obj)
        {
            this.obj = obj;
            txtCodigo.Text = obj.id.ToString();
            txtNome.Text = obj.nome;
            tabControl1.SelectedIndex = 1;
        }

        public void atualiza(string filtro)
        {
            int linhaSelecionada = 0, primeiraLinha = 0;
            if (grid.CurrentRow != null)
            {
                primeiraLinha = grid.FirstDisplayedScrollingRowIndex;
                linhaSelecionada = grid.CurrentRow.Index;
            }
            grid.DataSource = bll.getAll(filtro, "NOME");
            grid.Refresh();
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            TipoComando obj = bll.get(Convert.ToInt32(grid.Rows[grid.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
            mostrar(obj);
        }
    }
}
