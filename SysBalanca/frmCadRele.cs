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
    public partial class frmCadRele : Form
    {
        ReleBLL bll = new ReleBLL("Rele");
        TipoReleBLL blltiporele = new TipoReleBLL("TipoRele");
        Rele obj;
        public frmCadRele()
        {
            InitializeComponent();
            atualiza("");
            carregaTipoRele();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            limpa();
            txtCodigoRele.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoRele.Text))
            {
                MessageBox.Show("Informe o código do Rele!");
                return;
            }

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do Rele!");
                return;
            }

            if (cboTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o tipo do Rele!");
                return;
            }

            Rele obj = new Rele();
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                obj.codigo = txtCodigoRele.Text;
                obj.nome = txtNome.Text;
                obj.tipo = Convert.ToInt32(cboTipo.SelectedItem.ToString().Split('-').GetValue(0));
                obj.dateinsert = DateTime.Now;
                bll.insert(obj);
                MessageBox.Show("Rele cadastrado com sucesso!");
            }
            else
            {
                obj.id = Convert.ToInt32(txtCodigo.Text);
                obj.codigo = txtCodigoRele.Text;
                obj.nome = txtNome.Text;
                obj.tipo = Convert.ToInt32(cboTipo.SelectedItem.ToString().Split('-').GetValue(0));
                obj.dateupdate = DateTime.Now;
                obj.dateinsert = this.obj.dateinsert;
                bll.update(obj);
                MessageBox.Show("Rele atualizado com sucesso!");
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
            MessageBox.Show("Rele excluído com sucesso!");
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
                    txtCodigoRele.Text = txtPesq.Text;
                    txtNome.Focus();
                }
            }
        }

        public void limpa()
        {
            txtCodigo.Clear();
            txtCodigoRele.Clear();
            txtNome.Clear();
            cboTipo.SelectedIndex = -1;
        }

        public void mostrar(Rele obj,TipoRele objTipoRele)
        {
            this.obj = obj;
            txtCodigo.Text = obj.id.ToString();
            txtCodigoRele.Text = obj.codigo;
            txtNome.Text = obj.nome;
            if (objTipoRele == null)
            {
                cboTipo.SelectedIndex = -1;
            }
            else
            {
                cboTipo.SelectedItem = objTipoRele.id + "-" + objTipoRele.nome;
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
            grid.DataSource = bll.getAll(filtro, "TABLEX.NOME");
            grid.Refresh();
        }

        public void carregaTipoRele()
        {
            cboTipo.Items.Clear();
            foreach (var item in blltiporele.getAllCustom())
            {
                cboTipo.Items.Add(item.id + "-" + item.nome);
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            Rele obj = bll.get(Convert.ToInt32(grid.Rows[grid.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
            TipoRele objtiporele = blltiporele.get(obj.tipo);
            mostrar(obj,objtiporele);
        }
    }
}
