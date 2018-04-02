namespace SysBalanca
{
    partial class frmTestarComandos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listReceber = new System.Windows.Forms.ListBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.cboPortasCOM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComando = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.timerCOM = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listReceber
            // 
            this.listReceber.FormattingEnabled = true;
            this.listReceber.ItemHeight = 15;
            this.listReceber.Location = new System.Drawing.Point(-2, 43);
            this.listReceber.Name = "listReceber";
            this.listReceber.Size = new System.Drawing.Size(831, 274);
            this.listReceber.TabIndex = 0;
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(203, 9);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(87, 27);
            this.btnConectar.TabIndex = 1;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboPortasCOM
            // 
            this.cboPortasCOM.FormattingEnabled = true;
            this.cboPortasCOM.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11"});
            this.cboPortasCOM.Location = new System.Drawing.Point(55, 12);
            this.cboPortasCOM.Name = "cboPortasCOM";
            this.cboPortasCOM.Size = new System.Drawing.Size(140, 23);
            this.cboPortasCOM.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Porta:";
            // 
            // txtComando
            // 
            this.txtComando.Location = new System.Drawing.Point(419, 12);
            this.txtComando.Name = "txtComando";
            this.txtComando.Size = new System.Drawing.Size(301, 23);
            this.txtComando.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Comando:";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(728, 9);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(87, 27);
            this.btnEnviar.TabIndex = 6;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // timerCOM
            // 
            this.timerCOM.Tick += new System.EventHandler(this.timerCOM_Tick);
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Mostra Peso";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmTestarComandos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 315);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtComando);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPortasCOM);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.listReceber);
            this.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.Name = "frmTestarComandos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testes de Comandos - Morpheus 2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTestarComandos_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listReceber;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.ComboBox cboPortasCOM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComando;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Timer timerCOM;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button button1;
    }
}