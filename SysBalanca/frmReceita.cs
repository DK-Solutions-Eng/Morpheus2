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
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Threading;
using System.Configuration;

namespace SysBalanca
{
    public partial class frmReceita : Form
    {
        ReceitaBLL bll = new ReceitaBLL("Receita");
        Receita obj;
        ItensReceita objitensreceita;
        ItensReceitaBLL bllitensreceita = new ItensReceitaBLL("ItensReceita");
        ComandoBLL bllcomando = new ComandoBLL("Comando");
        ReleBLL bllrele = new ReleBLL("Rele");
        frmPrincipal frmPrincipal = new frmPrincipal();
        public frmReceita(frmPrincipal frm)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            carregaCombos();
            atualiza("");
            ZerarAbaCadastro();
            frmPrincipal = frm;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                carregaCombos();
                atualiza("");
                ZerarAbaCadastro();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                //verificar se vou zerar algo
            }
        }
        private void frmReceita_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                DataTable dt = bllitensreceita.getCustomReceita(Convert.ToInt32(txtCodigo.Text));
                if (dt == null)
                {
                    var confirmResult = MessageBox.Show("Receita sem itens, se prosseguir a receita irá ser deletada, deseja prosseguir?",
                          "Confirmação de exclusão!",
                 MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        bll.delete(Convert.ToInt32(txtCodigo.Text));
                    }
                }
            }
        }

        #region ...Aba Listagem...
        #region ...Eventos...
        private void txtPesq_KeyUp(object sender, KeyEventArgs e)
        {
            atualiza(txtPesq.Text);

            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (grid.Rows.Count == 0)
            //    {
            //        tabControl1.SelectedIndex = 1;
            //        txtNome.Enabled = true;
            //        txtNome.Text = txtPesq.Text;
            //        txtNome.Focus();

            //    }
            //}
        }
        private void grid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grid.Rows[grid.SelectedCells[0].RowIndex].Cells[0].Value != null)
                {
                    Receita obj = bll.get(Convert.ToInt32(grid.Rows[grid.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
                    mostrar(obj);
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region ...Metodos...
        public void mostrar(Receita obj)
        {
            this.obj = obj;
            txtCodigo.Text = obj.id.ToString();
            txtNome.Text = obj.nome;
            carregaItensReceita(obj.id);
            tabControl1.SelectedIndex = 1;
            btnExcluir.Enabled = true;
            btnPesquisar.Enabled = true;
            txtNome.Enabled = true;
            btnNovoItem.Enabled = true;
            btnCarregaReceita.Enabled = true;
            btnIniciarReceita.Enabled = true;
            btnPausarReceita.Enabled = true;
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
            grid.ClearSelection();
        }
        #endregion
        #endregion

        #region ...Aba Cadastro...
        #region ...Eventos...
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            txtNome.Enabled = true;
            txtNome.Focus();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Informe o nome da receita!");
                return;
            }

            //se nao existir id para a receita significa q nao foi adicionado item
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Adicione pelo menos um item na receita!");
                return;
            }

            //verifica se tem item para a receita
            DataTable dt = bllitensreceita.getCustomReceita(Convert.ToInt32(txtCodigo.Text));
            if (dt == null)
            {
                MessageBox.Show("Adicione pelo menos um item na receita!");
                return;
            }
            if (obj == null)
            {
                obj = new Receita();
            }
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                obj.nome = txtNome.Text;
                obj.dateinsert = DateTime.Now;
                bll.insert(obj);
                MessageBox.Show("Receita cadastrada com sucesso!");
            }
            else
            {
                obj.id = Convert.ToInt32(txtCodigo.Text);
                obj.nome = txtNome.Text;
                obj.dateupdate = DateTime.Now;
                obj.dateinsert = this.obj.dateinsert;
                bll.update(obj);
                MessageBox.Show("Receita atualizada com sucesso!");
            }
            tabControl1.SelectedIndex = 0;
            atualiza("");
            carregaItensReceita(0);
            limpa();
            limpaCamposItensReceita();

        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Selecione uma receita para excluir!");
                return;
            }

            var confirmResult = MessageBox.Show("Você realmente deseja deletar essa receita?",
                                     "Confirmação de exclusão!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                bll.delete(Convert.ToInt32(txtCodigo.Text));
                bllitensreceita.deleteCustomReceita(Convert.ToInt32(txtCodigo.Text));
                MessageBox.Show("Receita excluída com sucesso!");
                tabControl1.SelectedIndex = 0;
                atualiza("");
                limpa();
                carregaItensReceita(0);
                limpaCamposItensReceita();
            }
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                DataTable dt = bllitensreceita.getCustomReceita(Convert.ToInt32(txtCodigo.Text));
                if (dt == null)
                {
                    var confirmResult = MessageBox.Show("Receita sem itens, se prosseguir a receita irá ser deletada, deseja prosseguir?",
                          "Confirmação de exclusão!",
                 MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        bll.delete(Convert.ToInt32(txtCodigo.Text));
                    }
                }
            }
            tabControl1.SelectedIndex = 0;
            atualiza("");
            carregaItensReceita(0);
            limpa();
            limpaCamposItensReceita();
            txtPesq.Focus();
        }
        private void btnAdicionaItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Informe o nome da receita para adicionar um item!");
                return;
            }

            if (cboObjetivo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um Objetivo!");
                return;
            }

            if (cboObjetivo.SelectedIndex != 2)
            {
                if (cboObjetivo.SelectedIndex == 1)
                {
                    if (string.IsNullOrEmpty(txtValor.Text))
                    {
                        MessageBox.Show("Informe o Pré corte!");
                        return;
                    }
                    if (string.IsNullOrEmpty(txtValorCorte.Text))
                    {
                        MessageBox.Show("Informe o Corte!");
                        return;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtValor.Text.Replace(":", "").Trim()))
                    {
                        MessageBox.Show("Informe o tempo!");
                        return;
                    }
                }
            }

            if (cboAcao.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma Ação!");
                return;
            }

            if (cboParametro1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o Parametro!");
                return;
            }

            if (cboAcao.SelectedIndex != 2)
            {

                if (cboParametro2.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione o Rele!");
                    return;
                }

                if (cboTipoLimite.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione um Tipo de Limite!");
                    return;
                }

                if (cboTipoLimite.SelectedIndex != 2)
                {
                    if (string.IsNullOrEmpty(txtValorLimite.Text.Replace(":", "").Trim()))
                    {
                        MessageBox.Show("Informe um Valor de Limite!");
                        return;
                    }
                }
            }

            obj = new Receita();
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                obj.nome = txtNome.Text;
                obj.dateinsert = DateTime.Now;
                bll.insert(obj);
                obj = bll.getCustomUltimo();
                txtCodigo.Text = obj.id.ToString();
            }
            else
            {
                obj = bll.get(Convert.ToInt32(txtCodigo.Text));
            }

            if (objitensreceita != null)
            {
                objitensreceita.id_receita = objitensreceita.id_receita;
                objitensreceita.objetivo = cboObjetivo.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                //item.comando_valor = Convert.ToInt32(cboValor.SelectedItem.ToString().Split('-').GetValue(0));
                objitensreceita.valor = txtValor.Text;
                objitensreceita.corte = txtValorCorte.Text;
                objitensreceita.acao = cboAcao.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                objitensreceita.parametro1 = cboParametro1.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                objitensreceita.parametro2 = cboParametro2.SelectedItem == null ? "" : cboParametro2.SelectedValue.ToString();
                objitensreceita.tipo_limite = cboTipoLimite.SelectedItem == null ? "" : cboTipoLimite.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                objitensreceita.valor_limite = txtValorLimite.Text;
                objitensreceita.dateinsert = objitensreceita.dateinsert;
                objitensreceita.dateupdate = objitensreceita.dateupdate;
                //considero as linhas do grid porque por padrao ele conta o cabeçalho... resumindo seria a nova linha
                objitensreceita.sequencia = 0;
                bllitensreceita.update(objitensreceita);
                carregaItensReceita(obj.id);
                limpaCamposItensReceita();
                objitensreceita = null;
                cboObjetivo.Focus();
            }
            else
            {
                ItensReceita item = new ItensReceita();
                item.id_receita = obj.id;
                item.objetivo = cboObjetivo.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                //item.comando_valor = Convert.ToInt32(cboValor.SelectedItem.ToString().Split('-').GetValue(0));
                item.valor = txtValor.Text;
                item.corte = txtValorCorte.Text;
                item.acao = cboAcao.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                item.parametro1 = cboParametro1.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                item.parametro2 = cboParametro2.SelectedValue == null ? "" : cboParametro2.SelectedValue.ToString();
                item.tipo_limite = cboTipoLimite.SelectedItem == null ? "" : cboTipoLimite.SelectedItem.ToString().Split('-').GetValue(0).ToString();
                item.valor_limite = txtValorLimite.Text;
                item.dateinsert = DateTime.Now;
                //considero as linhas do grid porque por padrao ele conta o cabeçalho... resumindo seria a nova linha
                item.sequencia = 0;//bllitensreceita.getCustomReceita(obj.id) == null ? 1 : bllitensreceita.getCustomReceita(obj.id).Rows.Count + 1;
                bllitensreceita.insert(item);
                carregaItensReceita(obj.id);
                limpaCamposItensReceita();
                cboObjetivo.Focus();
            }
            gridItensReceita.Left = 6;
            gridItensReceita.Top = 64;
            gridItensReceita.Height = 204;
            enableButtonItensReceita(true, false, false, false);
            bllitensreceita.ordenaSequencia(obj.id);
            carregaItensReceita(obj.id);
            btnNovoItem.Focus();
        }
        private void btnDeletaItem_Click(object sender, EventArgs e)
        {
            try
            {
                var itemselecionado = gridItensReceita.Rows[gridItensReceita.SelectedCells[0].RowIndex].Cells[9].Value.ToString();
                if (string.IsNullOrEmpty(itemselecionado))
                {
                    MessageBox.Show("Selecione um item para deletar!");
                    return;
                }

                var confirmResult = MessageBox.Show("Você realmente deseja deletar este item da receita?",
                             "Confirmação de exclusão!",
                             MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bllitensreceita.delete(Convert.ToInt32(gridItensReceita.Rows[gridItensReceita.SelectedCells[0].RowIndex].Cells[9].Value.ToString()));
                }

                bllitensreceita.ordenaSequencia(Convert.ToInt32(txtCodigo.Text));
                carregaItensReceita(Convert.ToInt32(txtCodigo.Text));
                limpaCamposItensReceita();
                cboObjetivo.Focus();
                enableButtonItensReceita(true, false, false, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione um item para deletar!");
                carregaItensReceita(Convert.ToInt32(txtCodigo.Text));
            }
        }
        private void cboObjetivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboObjetivo.SelectedIndex == 0)
            {
                lblValor.Text = "Tempo";
                txtValor.Enabled = true;
                txtValorCorte.Enabled = false;
                lblValorCorte.Visible = false;
                txtValorCorte.Visible = false;
                cboAcao.Enabled = true;
                txtValor.Clear();
                txtValorCorte.Clear();
                carregaAcao();
                carregaParametro1();
                carregaParametro2();
                carregaTipoLimite();
                txtValorLimite.Clear();
                gridItensReceita.Left = 6;
                gridItensReceita.Top = 64;
                gridItensReceita.Height = 204;
                txtValor.Mask = "00:00:00";
            }
            else if (cboObjetivo.SelectedIndex == 1)
            {
                lblValor.Text = "Pré corte";
                txtValor.Enabled = true;
                lblValorCorte.Text = "Corte";
                txtValorCorte.Enabled = true;
                lblValorCorte.Visible = true;
                txtValorCorte.Visible = true;
                cboAcao.Enabled = true;
                txtValor.Clear();
                carregaAcao();
                carregaParametro1();
                carregaParametro2();
                carregaTipoLimite();
                txtValorLimite.Clear();
                gridItensReceita.Left = 6;
                gridItensReceita.Top = 110;
                gridItensReceita.Height = 160;
                txtValor.Mask = "";
            }
            else if (cboObjetivo.SelectedIndex == 2)
            {
                lblValor.Text = "Nenhum valor";
                txtValor.Enabled = false;
                txtValorCorte.Enabled = false;
                lblValorCorte.Visible = false;
                txtValorCorte.Visible = false;
                txtValor.Clear();
                if (cboAcao.SelectedIndex == -1)
                {
                    carregaAcao();
                    cboAcao.Enabled = true;
                }
                carregaParametro1();
                carregaParametro2();
                carregaTipoLimite();
                txtValorLimite.Clear();
                gridItensReceita.Left = 6;
                gridItensReceita.Top = 64;
                gridItensReceita.Height = 204;
                txtValor.Mask = "";
                txtValorLimite.Mask = "";
            }
        }
        private void cboAcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAcao.SelectedIndex == 0)
            {
                lblParametro1.Text = "Parametro";
                cboParametro1.Enabled = true;
                lblParametro2.Text = "Rele";
                cboParametro2.Enabled = true;
                lblTipoLimite.Text = "Tipo Limite";
                cboTipoLimite.Enabled = true;
                lblValorLimite.Text = "Valor Limite";
                txtValorLimite.Enabled = true;
                cboParametro1.Items.Clear();
                cboParametro1.Items.Add("Saída");
                cboParametro2.SelectedIndex = -1;
                cboTipoLimite.SelectedIndex = -1;
                txtValorLimite.Clear();
            }
            else if (cboAcao.SelectedIndex == 1)
            {
                lblParametro1.Text = "Parametro";
                cboParametro1.Enabled = true;
                lblParametro2.Text = "Rele";
                cboParametro2.Enabled = true;
                lblTipoLimite.Text = "Tipo Limite";
                cboTipoLimite.Enabled = true;
                lblValorLimite.Text = "Valor Limite";
                txtValorLimite.Enabled = true;
                cboParametro1.Items.Clear();
                cboParametro1.Items.Add("Saída");
                cboParametro2.SelectedIndex = -1;
                cboTipoLimite.SelectedIndex = -1;
                txtValorLimite.Clear();
            }
            else if (cboAcao.SelectedIndex == 2)
            {
                lblParametro1.Text = "Parametro";
                cboParametro1.Enabled = true;
                lblParametro2.Text = "Nenhum Rele";
                cboParametro2.Enabled = false;
                lblTipoLimite.Text = "Nenhum valor";
                cboTipoLimite.Enabled = false;
                lblValorLimite.Text = "Nenhum valor";
                txtValorLimite.Enabled = false;
                cboParametro1.Items.Clear();
                cboParametro1.Items.Add("Zero");
                cboParametro1.Items.Add("Tara");
                cboParametro2.SelectedIndex = -1;
                cboTipoLimite.SelectedIndex = -1;
                txtValorLimite.Clear();
                cboObjetivo.SelectedIndex = 2;
                lblValor.Text = "Nenhum valor";
                txtValor.Enabled = false;
                gridItensReceita.Left = 6;
                gridItensReceita.Top = 64;
                gridItensReceita.Height = 204;

            }
        }
        private void cboTipoLimite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoLimite.SelectedIndex == 0)
            {
                lblValorLimite.Text = "Valor Limite";
                txtValorLimite.Enabled = true;
                txtValorLimite.Mask = "00:00:00";
                txtValorLimite.Clear();
            }
            else if (cboTipoLimite.SelectedIndex == 1)
            {
                lblValorLimite.Text = "Valor Limite";
                txtValorLimite.Enabled = true;
                txtValorLimite.Mask = "";
                txtValorLimite.Clear();
            }
            else if (cboTipoLimite.SelectedIndex == 2)
            {
                lblValorLimite.Text = "Nenhum valor";
                txtValorLimite.Enabled = false;
                txtValorLimite.Mask = "";
                txtValorLimite.Clear();
            }
        }
        private void gridItensReceita_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("Você deseja editar esse item?",
                 "Edição",
                 MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (gridItensReceita.Rows[gridItensReceita.SelectedCells[0].RowIndex].Cells[9].Value != null)
                    {
                        ItensReceita obj = bllitensreceita.get(Convert.ToInt32(gridItensReceita.Rows[gridItensReceita.SelectedCells[0].RowIndex].Cells[9].Value.ToString()));
                        mostrarItensReceita(obj);
                        cboObjetivo.Enabled = true;
                        enableButtonItensReceita(false, true, true, true);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btnMoveAcima_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridItensReceita.Rows[gridItensReceita.SelectedCells[0].RowIndex].Cells[9].Value != null)
                {
                    int sequencia = Convert.ToInt32(gridItensReceita.Rows[gridItensReceita.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                    if ((sequencia + 1) <= gridItensReceita.Rows.Count)
                    {
                        bllitensreceita.updateCustomMoveAcimaSequencia(sequencia, Convert.ToInt32(gridItensReceita.Rows[gridItensReceita.SelectedCells[0].RowIndex].Cells[9].Value.ToString()));
                        carregaItensReceita(obj.id);
                        gridItensReceita.ClearSelection();
                        gridItensReceita.CurrentCell = gridItensReceita.Rows[sequencia].Cells[0];
                        gridItensReceita.Rows[sequencia].Selected = true;
                        limpaCamposItensReceita();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btnMoveAbaixo_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridItensReceita.Rows[gridItensReceita.SelectedCells[0].RowIndex].Cells[9].Value != null)
                {
                    int sequencia = Convert.ToInt32(gridItensReceita.Rows[gridItensReceita.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                    if (sequencia != 1)
                    {
                        bllitensreceita.updateCustomMoveAbaixoSequencia(sequencia, Convert.ToInt32(gridItensReceita.Rows[gridItensReceita.SelectedCells[0].RowIndex].Cells[9].Value.ToString()));
                        carregaItensReceita(obj.id);
                        gridItensReceita.ClearSelection();
                        gridItensReceita.CurrentCell = gridItensReceita.Rows[(sequencia - 2)].Cells[0];
                        gridItensReceita.Rows[(sequencia - 2)].Selected = true;
                        limpaCamposItensReceita();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btnNovoItem_Click(object sender, EventArgs e)
        {
            limpaCamposItensReceita();
            cboObjetivo.Enabled = true;
            cboObjetivo.Focus();
            enableButtonItensReceita(false, true, true, false);
        }
        private void btnCancelarItem_Click(object sender, EventArgs e)
        {
            limpaCamposItensReceita();
            cboObjetivo.Focus();
            enableButtonItensReceita(true, false, false, false);
        }
        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                enableButtonItensReceita(false, false, false, false);
                btnConfirmar.Enabled = false;
                txtNome.Enabled = true;
                txtNome.Focus();
                gridItensReceita.Enabled = false;
            }
            else
            {
                enableButtonItensReceita(true, false, false, false);
                btnPesquisar.Enabled = true;
                btnConfirmar.Enabled = true;
                gridItensReceita.Enabled = true;
            }
        }
        #endregion
        #region ...Metodos...
        public void limpa()
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }
        public void limpaCamposItensReceita()
        {
            cboObjetivo.SelectedIndex = -1;
            cboObjetivo.Enabled = false;
            txtValor.Clear();
            cboAcao.SelectedIndex = -1;
            cboParametro1.SelectedIndex = -1;
            cboParametro2.SelectedIndex = -1;
            cboTipoLimite.SelectedIndex = -1;
            txtValorLimite.Clear();
            objitensreceita = null;
            txtValor.Enabled = false;
            cboAcao.Enabled = false;
            cboParametro1.Enabled = false;
            cboParametro2.Enabled = false;
            cboTipoLimite.Enabled = false;
            txtValorLimite.Enabled = false;
            gridItensReceita.ClearSelection();
            txtValorCorte.Visible = false;
            txtValorCorte.Clear();
            lblValorCorte.Visible = false;
            txtValor.Mask = "";
            txtValorLimite.Mask = "";
            gridItensReceita.Left = 6;
            gridItensReceita.Top = 64;
            gridItensReceita.Height = 204;
        }
        public void mostrarItensReceita(ItensReceita obj)
        {
            this.objitensreceita = obj;
            Rele objrele = bllrele.get(Convert.ToInt32(string.IsNullOrEmpty(obj.parametro2) ? "0" : obj.parametro2));
            cboObjetivo.SelectedIndex = (obj.objetivo == "Tempo" ? 0 : (obj.objetivo == "Peso" ? 1 : 2));
            txtValor.Text = obj.valor;
            txtValorCorte.Text = obj.corte;
            cboAcao.SelectedIndex = (obj.acao == "Ativar" ? 0 : (obj.acao == "Desativar" ? 1 : 2));
            cboParametro1.SelectedItem = obj.parametro1;
            cboParametro2.SelectedValue = objrele == null ? 0 : objrele.id;
            cboTipoLimite.SelectedIndex = (obj.tipo_limite == "Tempo" ? 0 : (obj.tipo_limite == "Peso" ? 1 : 2));
            txtValorLimite.Text = obj.valor_limite;
        }
        public void carregaItensReceita(int? id_receita)
        {
            gridItensReceita.DataSource = bllitensreceita.getCustomReceita(id_receita);
            gridItensReceita.Refresh();
            gridItensReceita.ClearSelection();
            if (gridItensReceita.DataSource != null)
            {
                btnMoveAcima.Enabled = true;
                btnMoveBaixo.Enabled = true;
                btnConfirmar.Enabled = true;
                gridItensReceita.Enabled = true;
                gridItensReceita.Columns["ID"].Visible = false;
                gridItensReceita.Columns["sequência"].Width = 75;
                gridItensReceita.Columns["VALOR"].Width = 151;
                gridItensReceita.Columns["CORTE"].Width = 80;
                gridItensReceita.Columns["AÇÃO"].Width = 110;
                gridItensReceita.Columns["PARAMETRO"].Width = 120;
                gridItensReceita.Columns["RELE"].Width = 170;
                gridItensReceita.Columns["TIPO_LIMITE"].Width = 120;
                gridItensReceita.Columns["VALOR_LIMITE"].Width = 120;
            }
            else
            {
                btnMoveAcima.Enabled = false;
                btnMoveBaixo.Enabled = false;
                btnConfirmar.Enabled = false;
                gridItensReceita.Enabled = false;
            }
        }
        public void ZerarAbaCadastro()
        {
            //enable
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            cboObjetivo.Enabled = false;
            txtValor.Enabled = false;
            txtValorCorte.Enabled = false;
            cboAcao.Enabled = false;
            cboParametro1.Enabled = false;
            cboParametro2.Enabled = false;
            cboTipoLimite.Enabled = false;
            txtValorLimite.Enabled = false;
            gridItensReceita.Enabled = false;
            btnMoveAcima.Enabled = false;
            btnMoveBaixo.Enabled = false;
            enableButtonItensReceita(false, false, false, false);
            btnConfirmar.Enabled = false;
            btnExcluir.Enabled = false;
            btnPesquisar.Enabled = false;
            //zera campos
            gridItensReceita.DataSource = null;
            obj = null;
            objitensreceita = null;
            txtCodigo.Clear();
            txtNome.Clear();
            cboObjetivo.SelectedIndex = -1;
            txtValor.Clear();
            cboAcao.SelectedIndex = -1;
            cboParametro1.SelectedIndex = -1;
            cboParametro2.SelectedIndex = -1;
            cboTipoLimite.SelectedIndex = -1;
            txtValorLimite.Clear();
            txtValorCorte.Clear();
            txtValorCorte.Enabled = false;
            lblValorCorte.Visible = false;
            txtValorCorte.Visible = false;
            lblValor.Text = "";
            lblTipoLimite.Text = "Tipo Limite";
            lblValorLimite.Text = "";
            btnCarregaReceita.Enabled = false;
            btnIniciarReceita.Enabled = false;
            btnPausarReceita.Enabled = false;
        }

        #region ...Carregamento dos combos...
        public void carregaObjetivo()
        {
            /*List<Comando> list = bllcomando.getCustomTipoComando("OBJETIVO");
            if (list != null)
            {
                foreach (Comando item in list)
                {
                    cboObjetivo.Items.Add(item.id + "-" + item.descricao_comando);
                }
            }*/
            cboObjetivo.Items.Clear();
            cboObjetivo.Items.Add("Tempo");
            cboObjetivo.Items.Add("Peso");
            cboObjetivo.Items.Add("Nenhum");

        }

        public void carregaValor()
        {
            /*List<Comando> list = bllcomando.getCustomTipoComando("VALOR");
            if (list != null)
            {
                foreach (Comando item in list)
                {
                    cboValor.Items.Add(item.id + "-" + item.descricao_comando);
                }
            }*/
        }

        public void carregaAcao()
        {
            //List<Comando> list = bllcomando.getCustomTipoComando("ACAO");
            //if (list != null)
            //{
            //    foreach (Comando item in list)
            //    {
            //        cboAcao.Items.Add(item.id + "-" + item.descricao_comando);
            //    }
            //}
            cboAcao.Items.Clear();
            cboAcao.Items.Add("Ativar");
            cboAcao.Items.Add("Desativar");
            cboAcao.Items.Add("Função");
        }

        public void carregaParametro1()
        {
            //List<Comando> list = bllcomando.getCustomTipoComando("PARAMETRO1");
            //if (list != null)
            //{
            //    foreach (Comando item in list)
            //    {
            //        cboParametro1.Items.Add(item.id + "-" + item.descricao_comando);
            //    }
            //}
            cboParametro1.Items.Clear();
            if (cboAcao.SelectedIndex == 0 || cboAcao.SelectedIndex == 1)
            {
                cboParametro1.Items.Add("Saída");
            }
            else if (cboAcao.SelectedIndex == 2)
            {
                cboParametro1.Items.Add("Zero");
                cboParametro1.Items.Add("Tara");
            }
        }

        public void carregaParametro2()
        {
            cboParametro2.DataSource = null;
            cboParametro2.Items.Clear();
            List<Rele> list = bllrele.getCustomListRele();
            if (list != null)
            {
                cboParametro2.ValueMember = "id";
                cboParametro2.DisplayMember = "nome";
                cboParametro2.DataSource = list;
            }
        }

        public void carregaTipoLimite()
        {
            //List<Comando> list = bllcomando.getCustomTipoComando("TIPOLIMITE");
            //if (list != null)
            //{
            //    foreach (Comando item in list)
            //    {
            //        cboTipoLimite.Items.Add(item.id + "-" + item.descricao_comando);
            //    }
            //}
            cboTipoLimite.Items.Clear();
            cboTipoLimite.Items.Add("Tempo");
            cboTipoLimite.Items.Add("Peso");
            cboTipoLimite.Items.Add("Nenhum");
        }

        public void carregaValorLimite()
        {
            //List<Comando> list = bllcomando.getCustomTipoComando("VALORLIMITE");
            //if (list != null)
            //{
            //    foreach (Comando item in list)
            //    {
            //        cboValorLimite.Items.Add(item.id + "-" + item.descricao_comando);
            //    }
            //}
        }

        public void carregaCombos()
        {
            txtValor.Enabled = false;
            cboAcao.Enabled = false;
            cboParametro1.Enabled = false;
            cboParametro2.Enabled = false;
            cboTipoLimite.Enabled = false;
            txtValorLimite.Enabled = false;
            lblObjetivo.Text = "Objetivo";
            lblValor.Text = "Valor";
            lblAcao.Text = "Ação";
            lblParametro1.Text = "Parametro";
            lblParametro2.Text = "Rele";
            lblTipoLimite.Text = "Tipo Limite";
            lblValorLimite.Text = "Valor Limite";
            carregaObjetivo();
            carregaValor();
            carregaAcao();
            carregaParametro1();
            carregaParametro2();
            carregaTipoLimite();
            carregaValorLimite();
        }

        public void enableButtonItensReceita(bool novoitem, bool salvaritem, bool cancelaritem, bool deletaritem)
        {
            btnNovoItem.Enabled = novoitem;
            btnSalvarItem.Enabled = salvaritem;
            btnCancelarItem.Enabled = cancelaritem;
            btnDeletaItem.Enabled = deletaritem;
        }

        #endregion

        #endregion

        #endregion

        private void txtValor_Leave(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_Leave_1(object sender, EventArgs e)
        {
            try
            {
                if (cboObjetivo.SelectedIndex == 1)
                {
                    if (ConfigurationManager.AppSettings["current"].ToString() == "pt-BR")
                    {
                        txtValor.Text = txtValor.Text.Replace(".", "");
                        if (txtValor.Text.IndexOf(",") == -1)
                        {
                            MessageBox.Show("Não é aceito ponto como separador decimal!");
                            txtValor.Clear();
                            txtValor.Focus();
                            return;
                        }
                        //var apenasDigitos = new Regex(@"\\d*(\\.\\d+)?");
                        if (txtValor.Text.IndexOf(",") != -1)
                        {
                            var apenasDigitos = new Regex(@"[^\d,\d-]");
                            txtValor.Text = Convert.ToDecimal(apenasDigitos.Replace(txtValor.Text, "") == "" ? "0" : apenasDigitos.Replace(txtValor.Text, "")).ToString("N1");
                        }
                        if (txtValor.Text == "0,0")
                        {
                            txtValor.Clear();
                        }
                    }
                    else if(ConfigurationManager.AppSettings["current"].ToString() == "en-US")
                    {
                        txtValor.Text = txtValor.Text.Replace(".", "");
                        if(txtValor.Text.IndexOf(",") == -1)
                        {
                            MessageBox.Show("Não é aceito ponto como separador decimal!");
                            txtValor.Clear();
                            txtValor.Focus();
                            return;
                        }
                        txtValor.Text = txtValor.Text.Replace(",", ".");
                        //var apenasDigitos = new Regex(@"\\d*(\\.\\d+)?");
                        if (txtValor.Text.IndexOf(".") != -1)
                        {
                            var apenasDigitos = new Regex(@"[^\d.\d-]");
                            txtValor.Text = Convert.ToDecimal(apenasDigitos.Replace(txtValor.Text, "") == "" ? "0" : apenasDigitos.Replace(txtValor.Text, "")).ToString("N1").Replace(".",",");
                        }
                        if (txtValor.Text == "0,0")
                        {
                            txtValor.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Formato inválido!");
                txtValor.Clear();
                txtValor.Focus();
            }
        }

        private void txtValorCorte_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cboObjetivo.SelectedIndex == 1)
                {
                    if (ConfigurationManager.AppSettings["current"].ToString() == "pt-BR")
                    {
                        txtValorCorte.Text = txtValorCorte.Text.Replace(".", "");
                        if (txtValorCorte.Text.IndexOf(",") == -1)
                        {
                            MessageBox.Show("Não é aceito ponto como separador decimal!");
                            txtValorCorte.Clear();
                            txtValorCorte.Focus();
                            return;
                        }
                        //var apenasDigitos = new Regex(@"\\d*(\\.\\d+)?");
                        if (txtValorCorte.Text.IndexOf(",") != -1)
                        {
                            var apenasDigitos = new Regex(@"[^\d,\d-]");
                            txtValorCorte.Text = Convert.ToDecimal(apenasDigitos.Replace(txtValorCorte.Text, "") == "" ? "0" : apenasDigitos.Replace(txtValorCorte.Text, "")).ToString("N1");
                        }
                        if (txtValorCorte.Text == "0,0")
                        {
                            txtValorCorte.Clear();
                        }
                    }
                    else if (ConfigurationManager.AppSettings["current"].ToString() == "en-US")
                    {
                        txtValorCorte.Text = txtValorCorte.Text.Replace(".", "");
                        if (txtValorCorte.Text.IndexOf(",") == -1)
                        {
                            MessageBox.Show("Não é aceito ponto como separador decimal!");
                            txtValorCorte.Clear();
                            txtValorCorte.Focus();
                            return;
                        }
                        txtValorCorte.Text = txtValorCorte.Text.Replace(",", ".");
                        //var apenasDigitos = new Regex(@"\\d*(\\.\\d+)?");
                        if (txtValorCorte.Text.IndexOf(".") != -1)
                        {
                            var apenasDigitos = new Regex(@"[^\d.\d-]");
                            txtValorCorte.Text = Convert.ToDecimal(apenasDigitos.Replace(txtValorCorte.Text, "") == "" ? "0" : apenasDigitos.Replace(txtValorCorte.Text, "")).ToString("N1").Replace(".", ",");
                        }
                        if (txtValorCorte.Text == "0,0")
                        {
                            txtValorCorte.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Formato inválido!");
                txtValorCorte.Clear();
                txtValorCorte.Focus();
            }
        }

        private void txtValorLimite_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cboObjetivo.SelectedIndex == 1)
                {
                    if (ConfigurationManager.AppSettings["current"].ToString() == "pt-BR")
                    {
                        txtValorLimite.Text = txtValorLimite.Text.Replace(".", "");
                        if (txtValorLimite.Text.IndexOf(",") == -1)
                        {
                            MessageBox.Show("Não é aceito ponto como separador decimal!");
                            txtValorLimite.Clear();
                            txtValorLimite.Focus();
                            return;
                        }
                        //var apenasDigitos = new Regex(@"\\d*(\\.\\d+)?");
                        if (txtValorLimite.Text.IndexOf(",") != -1)
                        {
                            var apenasDigitos = new Regex(@"[^\d,\d-]");
                            txtValorLimite.Text = Convert.ToDecimal(apenasDigitos.Replace(txtValorLimite.Text, "") == "" ? "0" : apenasDigitos.Replace(txtValorLimite.Text, "")).ToString("N1");
                        }
                        if (txtValorLimite.Text == "0,0")
                        {
                            txtValorLimite.Clear();
                        }
                    }
                    else if (ConfigurationManager.AppSettings["current"].ToString() == "en-US")
                    {
                        txtValorLimite.Text = txtValorLimite.Text.Replace(".", "");
                        if (txtValorLimite.Text.IndexOf(",") == -1)
                        {
                            MessageBox.Show("Não é aceito ponto como separador decimal!");
                            txtValorLimite.Clear();
                            txtValorLimite.Focus();
                            return;
                        }
                        txtValorLimite.Text = txtValorLimite.Text.Replace(",", ".");
                        //var apenasDigitos = new Regex(@"\\d*(\\.\\d+)?");
                        if (txtValorLimite.Text.IndexOf(".") != -1)
                        {
                            var apenasDigitos = new Regex(@"[^\d.\d-]");
                            txtValorLimite.Text = Convert.ToDecimal(apenasDigitos.Replace(txtValorLimite.Text, "") == "" ? "0" : apenasDigitos.Replace(txtValorLimite.Text, "")).ToString("N1").Replace(".", ",");
                        }
                        if (txtValorLimite.Text == "0,0")
                        {
                            txtValorLimite.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Formato inválido!");
                txtValorLimite.Clear();
                txtValorLimite.Focus();
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                {
                    DataTable dt = bllitensreceita.getCustomReceita(Convert.ToInt32(txtCodigo.Text));
                    if (dt == null)
                    {
                        var confirmResult = MessageBox.Show("Receita sem itens, se prosseguir a receita irá ser deletada, deseja prosseguir?",
                              "Confirmação de exclusão!",
                     MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.Yes)
                        {
                            bll.delete(Convert.ToInt32(txtCodigo.Text));
                        }
                    }
                }
            }
        }

        private void btnCarregaReceita_Click(object sender, EventArgs e)
        {
            if (frmPrincipal.IsOpen())          //porta está aberta
            {
                int tentativas = 0;
                Common.Comunicacao.retorno = false;
                DataTable dtitemreceita = bllitensreceita.getItensReceita(Convert.ToInt32(txtCodigo.Text));
                progressBar.Minimum = 0;
                progressBar.Maximum = dtitemreceita.Rows.Count + 2;
                progressBar.Step = 1;
                progressBar.Visible = true;
                //funcao, objetivo, precorte1, precorte2, precorte3,multiplicadorprecorte,sinalprecorte, valor1, valor2, valor3,multiplicadorvalor,sinalvalor, acao, parametro1, parametro2, tiporele, tipolimite, valorlimite1, valorlimite2, valorlimite3,multivalorlimite,sinalvalorlimite, crc-,crc+
                //inicia a receita no arduino
                //byte[] inicioreceita = new byte[] { 0x62, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x85, 0x09 };

                tentadinovo:
                byte[] inicioreceita = new byte[] { 0x62, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                inicioreceita = Common.Comunicacao.setCRC(inicioreceita);
                frmPrincipal.Write(inicioreceita, 0, inicioreceita.Length);
                progressBar.PerformStep();
                //se passar desse while significa que recebi a instrução que o comando foi certo
                if (!Common.Comunicacao.validaRetorno())
                {
                    progressBar.Visible = false;
                    return;
                }

                if (Common.Comunicacao.lastbytes[0].ToString("X") != "72")
                {
                    //significa q a instrução deu erro reenviar
                    if (tentativas == 3)
                    {
                        MessageBox.Show("Falha no envio da receita, tente novamente!");
                        progressBar.Visible = false;
                        return;
                    }
                    progressBar.Step = -1;
                    progressBar.PerformStep();
                    progressBar.Step = 1;
                    tentativas++;
                    goto tentadinovo;
                }

                if (Common.Comunicacao.lastbytes[1].ToString("X") != "0")
                {
                    MessageBox.Show("Falha no envio do comando, verifique o ControlMix!");
                    return;
                }

                tentativas = 0;
                Common.Comunicacao.retorno = false;

                for (int i = 0; i < dtitemreceita.Rows.Count; i++)
                {
                    tentedinovoitem:
                    int precortetotal, valortotal, limitetotal;
                    byte sinalprecorte, sinalvalor, sinallimite;
                    progressBar.PerformStep();
                    //valida pre corte
                    if (!string.IsNullOrEmpty(dtitemreceita.Rows[i]["valor"].ToString()))
                    {

                        if (dtitemreceita.Rows[i]["objetivo"].ToString() == "Tempo")
                        {
                            precortetotal = Convert.ToInt32(TimeSpan.Parse(dtitemreceita.Rows[i]["valor"].ToString()).TotalSeconds);
                        }
                        else if (dtitemreceita.Rows[i]["objetivo"].ToString() == "Peso")
                        {
                            precortetotal = Convert.ToInt32(dtitemreceita.Rows[i]["valor"].ToString().Replace("-", "").Replace(".", "").Replace(",", ""));
                        }
                        else
                        {
                            precortetotal = 0;
                        }
                    }
                    else
                    {
                        precortetotal = 0;
                    }

                    //valida valor
                    if (!string.IsNullOrEmpty(dtitemreceita.Rows[i]["corte"].ToString()))
                    {

                        if (dtitemreceita.Rows[i]["objetivo"].ToString() == "Tempo")
                        {
                            valortotal = Convert.ToInt32(TimeSpan.Parse(dtitemreceita.Rows[i]["corte"].ToString()).TotalSeconds);
                        }
                        else if (dtitemreceita.Rows[i]["objetivo"].ToString() == "Peso")
                        {
                            valortotal = Convert.ToInt32(dtitemreceita.Rows[i]["corte"].ToString().Replace("-", "").Replace(".", "").Replace(",", ""));
                        }
                        else
                        {
                            valortotal = 0;
                        }
                    }
                    else
                    {
                        valortotal = 0;
                    }

                    //valida limite
                    if (!string.IsNullOrEmpty(dtitemreceita.Rows[i]["valor_limite"].ToString()))
                    {

                        if (dtitemreceita.Rows[i]["tipo_limite"].ToString() == "Tempo")
                        {
                            limitetotal = Convert.ToInt32(TimeSpan.Parse(dtitemreceita.Rows[i]["valor_limite"].ToString()).TotalSeconds);
                        }
                        else if (dtitemreceita.Rows[i]["tipo_limite"].ToString() == "Peso")
                        {
                            limitetotal = Convert.ToInt32(dtitemreceita.Rows[i]["valor_limite"].ToString().Replace("-", "").Replace(".", "").Replace(",", ""));
                        }
                        else
                        {
                            limitetotal = 0;
                        }
                    }
                    else
                    {
                        limitetotal = 0;
                    }

                    //pega os sinais
                    sinalprecorte = Convert.ToByte(string.IsNullOrEmpty(dtitemreceita.Rows[i]["valor"].ToString()) ? 0 : (dtitemreceita.Rows[i]["valor"].ToString().Substring(0, 1) == "-" ? 1 : 0));
                    sinalvalor = Convert.ToByte(string.IsNullOrEmpty(dtitemreceita.Rows[i]["corte"].ToString()) ? 0 : (dtitemreceita.Rows[i]["corte"].ToString().Substring(0, 1) == "-" ? 1 : 0));
                    sinallimite = Convert.ToByte(string.IsNullOrEmpty(dtitemreceita.Rows[i]["valor_limite"].ToString()) ? 0 : (dtitemreceita.Rows[i]["valor_limite"].ToString().Substring(0, 1) == "-" ? 1 : 0));


                    //valor precorte quebrado com multiplicador
                    byte precorte1 = Convert.ToByte(bllitensreceita.primeiroValor(precortetotal));
                    byte precorte2 = Convert.ToByte(bllitensreceita.segundoValor(precortetotal, precorte1));
                    byte precorte3 = Convert.ToByte(bllitensreceita.terceiroValor(precortetotal, precorte2));
                    byte multprecorte = Convert.ToByte(bllitensreceita.pegaCasasDecimais(dtitemreceita.Rows[i]["valor"].ToString()));

                    //valor objetivo quebrado com multiplicador
                    byte valor1 = Convert.ToByte(bllitensreceita.primeiroValor(valortotal));
                    byte valor2 = Convert.ToByte(bllitensreceita.segundoValor(valortotal, valor1));
                    byte valor3 = Convert.ToByte(bllitensreceita.terceiroValor(valortotal, valor2));
                    byte multvalor = Convert.ToByte(bllitensreceita.pegaCasasDecimais(dtitemreceita.Rows[i]["corte"].ToString()));

                    //valor limite quebrado com multiplicador
                    byte limite1 = Convert.ToByte(bllitensreceita.primeiroValor(limitetotal));
                    byte limite2 = Convert.ToByte(bllitensreceita.segundoValor(limitetotal, limite1));
                    byte limite3 = Convert.ToByte(bllitensreceita.terceiroValor(limitetotal, limite2));
                    byte multlimite = Convert.ToByte(bllitensreceita.pegaCasasDecimais(dtitemreceita.Rows[i]["valor_limite"].ToString()));

                    //manda o item da receita
                    byte[] itemreceita = new byte[] { 0x63, bllitensreceita.deParaObjetivo(dtitemreceita.Rows[i]["objetivo"].ToString()), precorte1, precorte2, precorte3, multprecorte, sinalprecorte, valor1, valor2, valor3, multvalor, sinalvalor, bllitensreceita.deParaAcao(dtitemreceita.Rows[i]["acao"].ToString()), bllitensreceita.deParaParametro1(dtitemreceita.Rows[i]["parametro1"].ToString()), Convert.ToByte(dtitemreceita.Rows[i]["codigo_rele"].ToString() == "" ? "0" : dtitemreceita.Rows[i]["codigo_rele"].ToString()), bllitensreceita.deParaTipoRele(dtitemreceita.Rows[i]["nome_tiporele"].ToString()), bllitensreceita.deParaTipoLimite(dtitemreceita.Rows[i]["tipo_limite"].ToString()), limite1, limite2, limite3, multlimite, sinallimite };
                    itemreceita = Common.Comunicacao.setCRC(itemreceita);
                    //Thread.Sleep(100);
                    frmPrincipal.Write(itemreceita, 0, itemreceita.Length);

                    //se passar desse while significa que recebi a instrução que o comando foi certo
                    if (!Common.Comunicacao.validaRetorno())
                    {
                        return;
                    }
                    if (Common.Comunicacao.lastbytes[0].ToString("X") != "73")
                    {
                        //significa q a instrução deu erro reenviar
                        if (tentativas == 3)
                        {
                            MessageBox.Show("Falha no envio da receita, tente novamente!");
                            progressBar.Visible = false;
                            return;
                        }
                        progressBar.Step = -1;
                        progressBar.PerformStep();
                        progressBar.Step = 1;
                        tentativas++;
                        goto tentedinovoitem;
                    }

                    if (Common.Comunicacao.lastbytes[1].ToString("X") != "0")
                    {
                        MessageBox.Show("Falha no envio do comando, verifique o ControlMix!");
                        return;
                    }

                    tentativas = 0;
                    Common.Comunicacao.retorno = false;
                }

                tentadinovofim:
                progressBar.PerformStep();
                //funcao, objetivo, precorte1, precorte2, precorte3,multiplicadorprecorte, valor1, valor2, valor3,multiplicadorvalor, acao, parametro1, parametro2, tiporele, tipolimite, valorlimite1, valorlimite2, valorlimite3, crc-,crc+
                //fecha a receita no arduino
                byte[] fimreceita = new byte[] { 0x64, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                fimreceita = Common.Comunicacao.setCRC(fimreceita);
                Thread.Sleep(100);
                frmPrincipal.Write(fimreceita, 0, fimreceita.Length);

                Common.Comunicacao.retorno = false;
                tentativas = 0;
                //se passar desse while significa que recebi a instrução que o comando foi certo
                if (!Common.Comunicacao.validaRetorno())
                {
                    return;
                }

                if (Common.Comunicacao.lastbytes[0].ToString("X") != "74")
                {
                    //significa q a instrução deu erro reenviar
                    if (tentativas == 3)
                    {
                        MessageBox.Show("Falha no envio da receita, tente novamente!");
                        progressBar.Visible = false;
                        return;
                    }
                    progressBar.Step = -1;
                    progressBar.PerformStep();
                    progressBar.Step = 1;
                    tentativas++;
                    goto tentadinovofim;
                }

                if (Common.Comunicacao.lastbytes[1].ToString("X") != "0")
                {
                    MessageBox.Show("Falha no envio do comando, verifique o ControlMix!");
                    return;
                }

                tentativas = 0;
                Common.Comunicacao.retorno = false;

                MessageBox.Show("Receita carregada com sucesso!");
                progressBar.Visible = false;
            }
            else
            {
                MessageBox.Show("Equipamento desligado, verifique!");
            }
        }

        private void btnIniciarReceita_Click(object sender, EventArgs e)
        {
            if (frmPrincipal.IsOpen())          //porta está aberta
            {
                int tentativas = 0;
                Common.Comunicacao.retorno = false;
                //funcao, objetivo, precorte1, precorte2, precorte3,multiplicadorprecorte,sinalprecorte, valor1, valor2, valor3,multiplicadorvalor,sinalvalor, acao, parametro1, parametro2, tiporele, tipolimite, valorlimite1, valorlimite2, valorlimite3,multivalorlimite,sinalvalorlimite, crc-,crc+
                //inicia a receita no arduino
                //byte[] inicioreceita = new byte[] { 0x62, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x85, 0x09 };
                tentadinovo:
                byte[] iniciareceita = new byte[] { 0x65, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                iniciareceita = Common.Comunicacao.setCRC(iniciareceita);
                frmPrincipal.Write(iniciareceita, 0, iniciareceita.Length);

                if (!Common.Comunicacao.validaRetorno())
                {
                    return;
                }

                if (Common.Comunicacao.lastbytes[0].ToString("X") != "75")
                {
                    //significa q a instrução deu erro reenviar
                    if (tentativas == 3)
                    {
                        MessageBox.Show("Falha no envio do comando, tente novamente!");
                        return;
                    }
                    tentativas++;
                    goto tentadinovo;
                }


                if (Common.Comunicacao.lastbytes[1].ToString("X") != "0")
                {
                    MessageBox.Show("Falha no envio do comando, verifique o ControlMix!");
                    return;
                }

                MessageBox.Show("Receita iniciada com sucesso!");
            }
            else
            {
                MessageBox.Show("Equipamento desligado, verifique!");
            }


        }
        private void btnPausarReceita_Click(object sender, EventArgs e)
        {
            if (frmPrincipal.IsOpen())          //porta está aberta
            {
                int tentativas = 0;
                Common.Comunicacao.retorno = false;
                //funcao, objetivo, precorte1, precorte2, precorte3,multiplicadorprecorte,sinalprecorte, valor1, valor2, valor3,multiplicadorvalor,sinalvalor, acao, parametro1, parametro2, tiporele, tipolimite, valorlimite1, valorlimite2, valorlimite3,multivalorlimite,sinalvalorlimite, crc-,crc+
                //inicia a receita no arduino
                //byte[] inicioreceita = new byte[] { 0x62, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x85, 0x09 };
                tentadinovo:
                byte[] pausarreceita = new byte[] { 0x66, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                pausarreceita = Common.Comunicacao.setCRC(pausarreceita);
                frmPrincipal.Write(pausarreceita, 0, pausarreceita.Length);

                //se passar desse while significa que recebi a instrução que o comando foi certo
                if (!Common.Comunicacao.validaRetorno())
                {
                    return;
                }

                if (Common.Comunicacao.lastbytes[0].ToString("X") != "76")
                {
                    //significa q a instrução deu erro reenviar
                    if (tentativas == 3)
                    {
                        MessageBox.Show("Falha no envio do comando, tente novamente!");
                        return;
                    }
                    tentativas++;
                    goto tentadinovo;
                }

                if (Common.Comunicacao.lastbytes[1].ToString("X") != "0")
                {
                    MessageBox.Show("Falha no envio do comando, verifique o ControlMix!");
                    return;
                }


                MessageBox.Show("Receita parada com sucesso!");
            }
            else
            {
                MessageBox.Show("Equipamento desligado, verifique!");
            }
        }
    }
}
