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
using Common;
using System.IO.Ports;

namespace SysBalanca
{
    public partial class frmStatus : Form
    {
        List<Configuracao> list;
        ConfiguracaoBLL bll = new ConfiguracaoBLL("Configuracao");
        public frmStatus()
        {
            InitializeComponent();
            list = bll.getAllCustom();
            conectarSerial();
        }

        public void conectarSerial()
        {
            if (serialPort.IsOpen == false)
            {
                try
                {
                    serialPort.PortName = list[0].porta_arduino;
                    serialPort.BaudRate = 19200;
                    serialPort.StopBits = StopBits.Two;
                    serialPort.Open();
                    button1.Text = "Desconectar";

                }
                catch
                {
                    pctConexao.Image = SysBalanca.Properties.Resources.cancelar;
                    button1.Text = "Conectar";
                    return;

                }
                if (serialPort.IsOpen)
                {
                    pctConexao.Image = SysBalanca.Properties.Resources.confirmar;
                    button1.Text = "Desconectar";

                }
            }
            else
            {

                try
                {
                    serialPort.Close();
                    pctConexao.Image = SysBalanca.Properties.Resources.cancelar;
                    button1.Text = "Conectar";
                }
                catch
                {
                    pctConexao.Image = SysBalanca.Properties.Resources.cancelar;
                    button1.Text = "Conectar";
                    return;
                }

            }
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
             var recebido = 0;

            List<int> teste = new List<int>();
            while (serialPort.BytesToRead != 0)
            {
                teste.Add(serialPort.ReadByte());
                
            }

            //verifica se tem bytes para ler
            if (serialPort.BytesToRead != 0)
            {
                recebido = serialPort.ReadByte();
                //verifica se e reference a balanca sempre primeiro byte igual a 1
                if (recebido == 1)
                {
                    //le o proximo byte
                    recebido = serialPort.ReadByte();
                    // se for verdadeira a condicao significa que e funcao de peso
                    if (recebido == 1)
                    {
                        string[] parametrospeso = new string[5];
                        parametrospeso[0] = serialPort.ReadByte().ToString("X");
                        parametrospeso[1] = serialPort.ReadByte().ToString("X");
                        parametrospeso[2] = serialPort.ReadByte().ToString("X");
                        parametrospeso[3] = serialPort.ReadByte().ToString("X");
                        parametrospeso[4] = serialPort.ReadByte().ToString("X");
                        Comunicacao.calcularPeso(parametrospeso[0], parametrospeso[1], parametrospeso[2], parametrospeso[3], parametrospeso[4]);
                    }
                }
            }
        }

        private void Status_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort.IsOpen == true)  // se porta aberta
                serialPort.Close();         //fecha a porta
        }

        private void atualizaPeso_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen == true)          //porta está aberta
            {
                byte[] buf = new byte[] { 0x60,0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,0x82,0x4B };
                serialPort.Write(buf, 0, buf.Length);
                lblPeso.Text = Convert.ToDecimal(Comunicacao.peso).ToString("N" + Comunicacao.casadecimais);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conectarSerial();
        }
    }
}
