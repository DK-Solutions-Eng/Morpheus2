using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Entidades;
using BLL;
using Common;


namespace SysBalanca
{
    public partial class frmTestarComandos : Form
    {
        string RxString;
        public frmTestarComandos()
        {
            InitializeComponent();

            //simula get do peso
            string p1 = "0", p2 = "BD", p3 = "2", sinal = "0";
            string multiplicador = "3";
            Comunicacao.calcularPeso(p1, p2, p3,multiplicador, sinal);
            var teste =  Comunicacao.peso;



            timerCOM.Enabled = true;
        }

        private void atualizaListaCOM()
        {
            int i;
            bool quantDiferente; //flag para sinalizar que a quantidade de portas mudou

            i = 0;
            quantDiferente = false;

            //se a quantidade de portas mudou
            if (cboPortasCOM.Items.Count == SerialPort.GetPortNames().Length)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (cboPortasCOM.Items[i++].Equals(s) == false)
                    {
                        quantDiferente = true;
                    }
                }
            }
            else
            {
                quantDiferente = true;
            }

            //Se não foi detectado diferença
            if (quantDiferente == false)
            {
                return;                     //retorna
            }

            //limpa comboBox
            cboPortasCOM.Items.Clear();

            //adiciona todas as COM diponíveis na lista
            foreach (string s in SerialPort.GetPortNames())
            {
                cboPortasCOM.Items.Add(s);
            }
            //seleciona a primeira posição da lista
            cboPortasCOM.SelectedIndex = 0;
        }

        private void timerCOM_Tick(object sender, EventArgs e)
        {
            atualizaListaCOM();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen == false)
            {
                try
                {
                    serialPort.PortName = cboPortasCOM.Items[cboPortasCOM.SelectedIndex].ToString();
                    serialPort.BaudRate = 38400;
                    serialPort.StopBits = StopBits.Two;
                    serialPort.Open();

                }
                catch
                {
                    return;

                }
                if (serialPort.IsOpen)
                {
                    btnConectar.Text = "Desconectar";
                    cboPortasCOM.Enabled = false;

                }
            }
            else
            {

                try
                {
                    serialPort.Close();
                    cboPortasCOM.Enabled = true;
                    btnConectar.Text = "Conectar";
                }
                catch
                {
                    return;
                }

            }
        }

        private void frmTestarComandos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort.IsOpen == true)  // se porta aberta
                serialPort.Close();         //fecha a porta
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //byte[] buf = System.Text.Encoding.UTF8.GetBytes(txtComando.Text);
            byte[] buf = new byte[] { 0x01 };
            
            if (serialPort.IsOpen == true)          //porta está aberta
                serialPort.Write(buf,0,buf.Length);
            
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var recebido = 0;
            //verifica se tem bytes para ler
            if (serialPort.BytesToRead != 0)
            {
                recebido = serialPort.ReadByte();
                //verifica se e reference a balanca sempre primeiro byte igual a 1
                if(recebido == 1)
                {
                    //le o proximo byte
                    recebido = serialPort.ReadByte();
                    // se for verdadeira a condicao significa que e funcao de peso
                    if(recebido == 1)
                    {
                        string[] parametrospeso = new string[5];
                        parametrospeso[0] = serialPort.ReadByte().ToString("X");
                        parametrospeso[1] = serialPort.ReadByte().ToString();
                        parametrospeso[2] = serialPort.ReadByte().ToString();
                        parametrospeso[3] = serialPort.ReadByte().ToString();
                        parametrospeso[4] = serialPort.ReadByte().ToString();
                        Comunicacao.calcularPeso(parametrospeso[0], parametrospeso[1], parametrospeso[2], parametrospeso[3], parametrospeso[4]);
                    }
                }
            }


            /*var verificador = 0;
            var completo = "";
            while (serialPort.BytesToRead != 0)
            {
                recebido = serialPort.ReadByte();
                
                completo += recebido;
                verificador = recebido;
                RxString = recebido.ToString("X");
                this.Invoke(new EventHandler(trataDadoRecebido));
            }*/
        }

        private void trataDadoRecebido(object sender, EventArgs e)
        {
            listReceber.Items.Add(RxString);
        }
    }
}
