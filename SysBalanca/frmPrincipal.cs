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
using System.IO.Ports;
using System.Threading;
using System.Configuration;
using System.Reflection;

namespace SysBalanca
{
    public partial class frmPrincipal : Form
    {
        Usuario objusuario;
        List<Configuracao> listconfiguracao;
        ConfiguracaoBLL bllconfiguracao = new ConfiguracaoBLL("Configuracao");
        TipoReleBLL blltiporele = new TipoReleBLL("TipoRele");
        public frmPrincipal()
        {
            InitializeComponent();
            //var settings = ConfigurationManager.ConnectionStrings[0];

            //var fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);

            //fi.SetValue(settings, false);

            //settings.ConnectionString = "Data Source=Something";
            cadastros();
            //testes
            //BLL.ItensReceitaBLL bllitensreceita = new BLL.ItensReceitaBLL("ItensReceita");
            //var result = bllitensreceita.primeiroValorByte(210000);
            //var result2 = bllitensreceita.segundoValorByte(210000, result);
            //var result3 = bllitensreceita.terceiroValorByte(210000, result2);
        }

        public frmPrincipal(Usuario p_objusuario)
        {
            InitializeComponent();
            objusuario = p_objusuario;
            statusVersao.Text = "VERSÃO: 1.0";
            statusUsuario.Text = "USUÁRIO: " + objusuario.usuario.ToUpper();


        }

        public void cadastros()
        {
            if (blltiporele.getAll("", "nome") == null)
            {
                TipoRele tiporele = new TipoRele();
                tiporele.nome = "PRODUTO";
                tiporele.dateinsert = DateTime.Now;
                blltiporele.insert(tiporele);
                tiporele = new TipoRele();
                tiporele.nome = "FUNCAO";
                tiporele.dateinsert = DateTime.Now;
                blltiporele.insert(tiporele);
            }
        }

        private void importarTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gerenciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verificaFormAberto())
            {
                frmCadComando frm = new frmCadComando();
                frm.Show();
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void trabalharToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialArduino.Close();
            Application.Exit();
        }

        private void cadastrarOperadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void produtividadeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verificaFormAberto())
            {
                frmCadUsuarios frm = new frmCadUsuarios();
                frm.Show();
            }
        }

        private void testarComandosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verificaFormAberto())
            {
                frmTestarComandos frmtestarcomandos = new frmTestarComandos();
                frmtestarcomandos.Show();
            }
        }

        private void relesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verificaFormAberto())
            {
                frmCadRele frm = new frmCadRele();
                frm.Show();
            }
        }

        private void tipoDosRelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verificaFormAberto())
            {
                frmCadTipoRele frm = new frmCadTipoRele();
                frm.Show();
            }
        }

        private void tipoDeComandoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verificaFormAberto())
            {
                frmCadTipoComando frm = new frmCadTipoComando();
                frm.Show();
            }
        }

        private void receitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verificaFormAberto())
            {
                frmReceita frm = new frmReceita(this);
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verificaFormAberto())
            {
                frmStatus frm = new frmStatus();
                frm.Show();
            }
        }

        private void configuraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public bool verificaFormAberto()
        {
            //var formaberto = Application.OpenForms[name];
            if (Application.OpenForms.Count <= 1)
            {
                return false;
            }
            else
            {
                MessageBox.Show("Não é permitido abrir dois formulários simultaneamente!");
                return true;
            }
        }
        public void conectarSerial()
        {

            if (serialArduino.IsOpen == false)
            {
                try
                {
                    listconfiguracao = bllconfiguracao.getAllCustom();
                    string[] ports = SerialPort.GetPortNames();
                    foreach (string port in ports)
                    {
                        if(listconfiguracao[0].porta_arduino == port)
                        {
                            serialArduino.PortName = listconfiguracao[0].porta_arduino;
                            serialArduino.BaudRate = listconfiguracao[0].baud_rate;
                            serialArduino.StopBits = StopBits.Two;
                            serialArduino.Open();
                        }
                    }
                }
                catch
                {
                    serialArduino.Close();
                    return;

                }

            }
            else
            {

                try
                {
                    //serialArduino.Close();

                }
                catch
                {

                    return;
                }

            }
        }
        
        public void monitoraConexaoPortaCom()
        {
            if (IsOpen())
            {
                statusArduino.Text = "Status: Conectado";
                statusArduino.BackColor = Color.LightGreen;
                statusPorta.Visible = true;
                statusPorta.Text = "Porta: " + listconfiguracao[0].porta_arduino;

            }
            else
            {
                statusArduino.Text = "Status: Desconectado";
                statusArduino.BackColor = Color.Red;
                statusPorta.Visible = false;
                conectarSerial();
            }
        }

        public bool IsOpen()
        {
            return serialArduino.IsOpen;
        }

        public void ConectarEquipamento()
        {
            listconfiguracao = bllconfiguracao.getAllCustom();
            conectarSerial();
        }

        public void Write(byte[] buffer,int offset,int count)
        {
            serialArduino.Write(buffer, offset, count);
        }

        private void serialArduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] bytesreturn = new byte[1000];
                int controla = 0;
                Thread.Sleep(100);
                while (serialArduino.BytesToRead != 0)
                {
                    bytesreturn[controla] = Convert.ToByte(serialArduino.ReadByte());
                    controla++;
                }

                if (Common.Comunicacao.checkCRCReceived(bytesreturn))
                {
                    for (int i = 0; i < 24; i++)
                    {
                        Common.Comunicacao.lastbytes[i] = bytesreturn[i];
                    }
                    //Common.Comunicacao.lastbytes = bytesreturn;
                    Thread.Sleep(100);
                    Common.Comunicacao.retorno = true;
                    statusMensagens.Visible = false;
                    if (Common.Comunicacao.lastbytes[0].ToString("X") == "75")
                    {
                        statusMensagens.Visible = true;
                        statusMensagens.Text = " Receita iniciada no ControlMix";
                    }

                    if (Common.Comunicacao.lastbytes[0].ToString("X") == "76")
                    {
                        statusMensagens.Visible = true;
                        statusMensagens.Text = " Receita parada no ControlMix";
                    }

                    if (Common.Comunicacao.lastbytes[0].ToString("X") == "77")
                    {
                        statusMensagens.Visible = true;
                        statusMensagens.Text = " Receita finalizada no ControlMix";
                    }
                    return;
                }
                Common.Comunicacao.retorno = true;
                Thread.Sleep(100);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Falha na comunicação com o equipamento, por favor reinicie!");
            }
        }

        private void comunicaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verificaFormAberto())
            {
                frmConfiguracao frm = new frmConfiguracao();
                frm.Show();
            }
        }

        private void atualizarDataHoraControlMixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(IsOpen())
            {
                DateTime dt = DateTime.Now;
                int tentativas = 0;
                Common.Comunicacao.retorno = false;
                tentadinovo:
                byte[] acertadatahora = new byte[] { 0x68, Convert.ToByte(dt.Day), Convert.ToByte(dt.Month), Convert.ToByte(dt.Year.ToString().Substring(0,2)), Convert.ToByte(dt.Year.ToString().Substring(2)), Convert.ToByte(dt.Hour), Convert.ToByte(dt.Minute), Convert.ToByte(dt.Second), 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                acertadatahora = Common.Comunicacao.setCRC(acertadatahora);
                Write(acertadatahora, 0, acertadatahora.Length);

                if (!Common.Comunicacao.validaRetorno())
                {
                    return;
                }

                if (Common.Comunicacao.lastbytes[0].ToString("X") != "78")
                {
                    //significa q a instrução deu erro reenviar
                    if (tentativas == 3)
                    {
                        MessageBox.Show("Falha no envio da receita, tente novamente!");
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

                MessageBox.Show("Atualização efetuada com sucesso!");
            }
            else
            {
                MessageBox.Show("Equipamento desligado, verifique!");
            }
                
        }

        private void relesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!verificaFormAberto())
            {
                frmCadRele frm = new frmCadRele();
                frm.Show();
            }
        }

        private void monitorarConexao_Tick(object sender, EventArgs e)
        {
            monitoraConexaoPortaCom();
        }
    }
}
