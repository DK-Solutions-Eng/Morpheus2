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
    public partial class frmCadComando : Form
    {
        ComandoBLL bll = new ComandoBLL("Comando");
        TipoComandoBLL blltipocomando = new TipoComandoBLL("TipoComando");
        Comando obj;
        public frmCadComando()
        {
            InitializeComponent();
            atualiza("");
            carregaTipoComando();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            limpa();
            txtCodigoComando.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoComando.Text))
            {
                MessageBox.Show("Informe o código do comando!");
                return;
            }

            if (string.IsNullOrEmpty(txtDescricaoComando.Text))
            {
                MessageBox.Show("Informe a descrição do comando!");
                return;
            }

            Comando obj = new Comando();
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                obj.codigo_comando = txtCodigoComando.Text;
                obj.descricao_comando = txtDescricaoComando.Text;
                obj.tipo = Convert.ToInt32(cboTipo.SelectedItem.ToString().Split('-').GetValue(0));
                obj.dateinsert = DateTime.Now;
                bll.insert(obj);
                MessageBox.Show("Comando cadastrado com sucesso!");
            }
            else
            {
                obj.id = Convert.ToInt32(txtCodigo.Text);
                obj.codigo_comando = txtCodigoComando.Text;
                obj.descricao_comando = txtDescricaoComando.Text;
                obj.tipo = Convert.ToInt32(cboTipo.SelectedItem.ToString().Split('-').GetValue(0));
                obj.dateupdate = DateTime.Now;
                obj.dateinsert = this.obj.dateinsert;
                bll.update(obj);
                MessageBox.Show("Comando atualizado com sucesso!");
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
            MessageBox.Show("Comando excluído com sucesso!");
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
                    txtCodigoComando.Text = txtPesq.Text;
                    txtDescricaoComando.Focus();
                }
            }
        }

        public void limpa()
        {
            txtCodigo.Clear();
            txtCodigoComando.Clear();
            txtDescricaoComando.Clear();
        }

        public void mostrar(Comando obj, TipoComando objtipocomando)
        {
            this.obj = obj;
            txtCodigo.Text = obj.id.ToString();
            txtCodigoComando.Text = obj.codigo_comando;
            txtDescricaoComando.Text = obj.descricao_comando;
            if (objtipocomando != null)
            {
                cboTipo.SelectedItem = objtipocomando.id + "-" + objtipocomando.nome;
            }
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
            grid.DataSource = bll.getAll(filtro,"descricao_comando");
            grid.Refresh();
        }

        public void carregaTipoComando()
        {
            cboTipo.Items.Clear();
            foreach (var item in blltipocomando.getAllCustom())
            {
                cboTipo.Items.Add(item.id + "-" + item.nome);
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            Comando obj = bll.get(Convert.ToInt32(grid.Rows[grid.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
            TipoComando objtipocomando = blltipocomando.get(obj.tipo);
            mostrar(obj,objtipocomando);
        }
    }
}
