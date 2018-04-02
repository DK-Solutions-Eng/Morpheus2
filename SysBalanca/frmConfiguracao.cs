using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Entidades;
using System.IO.Ports;

namespace SysBalanca
{
    public partial class frmConfiguracao : Form
    {
        ConfiguracaoBLL bll = new ConfiguracaoBLL("Configuracao");
        Configuracao obj = new Configuracao();
        frmPrincipal frmPrincipal = new frmPrincipal();
        public frmConfiguracao()
        {
            InitializeComponent();
            DataTable dt = bll.getAll("", "porta_arduino");
            if(dt == null)
            {
                bll.insert(obj);
                dt = bll.getAll("", "porta_arduino");
            }
            obj = bll.get(Convert.ToInt32(dt.Rows[0]["id"].ToString()));
            listaPortasCom();
            cboPorta.SelectedItem = obj.porta_arduino;
            txtBaudRate.Text = obj.baud_rate.ToString();

        }

        public void listaPortasCom()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cboPorta.Items.Add(port);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(cboPorta.Text))
            {
                MessageBox.Show("Informe a porta do Arduino!");
                return;
            }

            if (string.IsNullOrEmpty(txtBaudRate .Text))
            {
                MessageBox.Show("Informe o Baud Rate!");
                return;
            }

            obj.porta_arduino = cboPorta.Text;
            obj.baud_rate = Convert.ToInt32(txtBaudRate.Text);
            bll.update(obj);
            MessageBox.Show("Configuração atualizada com sucesso!");
        }
    }
}
