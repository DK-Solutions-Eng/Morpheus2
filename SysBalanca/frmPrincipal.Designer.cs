namespace SysBalanca
{
    partial class frmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.basesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeComandoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDosRelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testarComandosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comunicaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atualizarDataHoraControlMixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusArduino = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusPorta = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusVersao = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusMensagens = new System.Windows.Forms.ToolStripStatusLabel();
            this.serialArduino = new System.IO.Ports.SerialPort(this.components);
            this.monitorarConexao = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.basesToolStripMenuItem,
            this.testarComandosToolStripMenuItem,
            this.statusToolStripMenuItem,
            this.configuraçãoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.basesToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(861, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // basesToolStripMenuItem
            // 
            this.basesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerenciarToolStripMenuItem,
            this.tipoDeComandoToolStripMenuItem,
            this.receitaToolStripMenuItem,
            this.usuárioToolStripMenuItem,
            this.tipoDosRelesToolStripMenuItem});
            this.basesToolStripMenuItem.Name = "basesToolStripMenuItem";
            this.basesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.basesToolStripMenuItem.Text = "Funções";
            // 
            // gerenciarToolStripMenuItem
            // 
            this.gerenciarToolStripMenuItem.Name = "gerenciarToolStripMenuItem";
            this.gerenciarToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.gerenciarToolStripMenuItem.Text = "Comandos";
            this.gerenciarToolStripMenuItem.Visible = false;
            this.gerenciarToolStripMenuItem.Click += new System.EventHandler(this.gerenciarToolStripMenuItem_Click);
            // 
            // tipoDeComandoToolStripMenuItem
            // 
            this.tipoDeComandoToolStripMenuItem.Name = "tipoDeComandoToolStripMenuItem";
            this.tipoDeComandoToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.tipoDeComandoToolStripMenuItem.Text = "Tipo de Comando";
            this.tipoDeComandoToolStripMenuItem.Visible = false;
            this.tipoDeComandoToolStripMenuItem.Click += new System.EventHandler(this.tipoDeComandoToolStripMenuItem_Click);
            // 
            // receitaToolStripMenuItem
            // 
            this.receitaToolStripMenuItem.Name = "receitaToolStripMenuItem";
            this.receitaToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.receitaToolStripMenuItem.Text = "Receitas";
            this.receitaToolStripMenuItem.Click += new System.EventHandler(this.receitaToolStripMenuItem_Click);
            // 
            // usuárioToolStripMenuItem
            // 
            this.usuárioToolStripMenuItem.Name = "usuárioToolStripMenuItem";
            this.usuárioToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.usuárioToolStripMenuItem.Text = "Usuários";
            this.usuárioToolStripMenuItem.Visible = false;
            this.usuárioToolStripMenuItem.Click += new System.EventHandler(this.usuárioToolStripMenuItem_Click);
            // 
            // tipoDosRelesToolStripMenuItem
            // 
            this.tipoDosRelesToolStripMenuItem.Name = "tipoDosRelesToolStripMenuItem";
            this.tipoDosRelesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.tipoDosRelesToolStripMenuItem.Text = "Tipo de Reles";
            this.tipoDosRelesToolStripMenuItem.Visible = false;
            this.tipoDosRelesToolStripMenuItem.Click += new System.EventHandler(this.tipoDosRelesToolStripMenuItem_Click);
            // 
            // testarComandosToolStripMenuItem
            // 
            this.testarComandosToolStripMenuItem.Name = "testarComandosToolStripMenuItem";
            this.testarComandosToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.testarComandosToolStripMenuItem.Text = "Testar Comandos";
            this.testarComandosToolStripMenuItem.Visible = false;
            this.testarComandosToolStripMenuItem.Click += new System.EventHandler(this.testarComandosToolStripMenuItem_Click);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.statusToolStripMenuItem.Text = "Status";
            this.statusToolStripMenuItem.Visible = false;
            this.statusToolStripMenuItem.Click += new System.EventHandler(this.statusToolStripMenuItem_Click);
            // 
            // configuraçãoToolStripMenuItem
            // 
            this.configuraçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comunicaçãoToolStripMenuItem,
            this.atualizarDataHoraControlMixToolStripMenuItem,
            this.relesToolStripMenuItem1});
            this.configuraçãoToolStripMenuItem.Name = "configuraçãoToolStripMenuItem";
            this.configuraçãoToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.configuraçãoToolStripMenuItem.Text = "Configuração";
            this.configuraçãoToolStripMenuItem.Click += new System.EventHandler(this.configuraçãoToolStripMenuItem_Click);
            // 
            // comunicaçãoToolStripMenuItem
            // 
            this.comunicaçãoToolStripMenuItem.Name = "comunicaçãoToolStripMenuItem";
            this.comunicaçãoToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.comunicaçãoToolStripMenuItem.Text = "Comunicação";
            this.comunicaçãoToolStripMenuItem.Click += new System.EventHandler(this.comunicaçãoToolStripMenuItem_Click);
            // 
            // atualizarDataHoraControlMixToolStripMenuItem
            // 
            this.atualizarDataHoraControlMixToolStripMenuItem.Name = "atualizarDataHoraControlMixToolStripMenuItem";
            this.atualizarDataHoraControlMixToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.atualizarDataHoraControlMixToolStripMenuItem.Text = "Atualizar Data Hora ControlMix";
            this.atualizarDataHoraControlMixToolStripMenuItem.Click += new System.EventHandler(this.atualizarDataHoraControlMixToolStripMenuItem_Click);
            // 
            // relesToolStripMenuItem1
            // 
            this.relesToolStripMenuItem1.Name = "relesToolStripMenuItem1";
            this.relesToolStripMenuItem1.Size = new System.Drawing.Size(284, 22);
            this.relesToolStripMenuItem1.Text = "Reles";
            this.relesToolStripMenuItem1.Click += new System.EventHandler(this.relesToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusUsuario,
            this.statusArduino,
            this.statusPorta,
            this.statusVersao,
            this.statusMensagens});
            this.statusStrip1.Location = new System.Drawing.Point(0, 277);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(861, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusUsuario
            // 
            this.statusUsuario.Name = "statusUsuario";
            this.statusUsuario.Size = new System.Drawing.Size(63, 19);
            this.statusUsuario.Text = "USUÁRIO:";
            this.statusUsuario.Visible = false;
            // 
            // statusArduino
            // 
            this.statusArduino.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusArduino.Name = "statusArduino";
            this.statusArduino.Size = new System.Drawing.Size(130, 19);
            this.statusArduino.Text = "Status ControlMix";
            // 
            // statusPorta
            // 
            this.statusPorta.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusPorta.Name = "statusPorta";
            this.statusPorta.Size = new System.Drawing.Size(46, 19);
            this.statusPorta.Text = "Porta";
            // 
            // statusVersao
            // 
            this.statusVersao.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusVersao.Name = "statusVersao";
            this.statusVersao.Size = new System.Drawing.Size(88, 19);
            this.statusVersao.Text = "Versão: 1.1";
            // 
            // statusMensagens
            // 
            this.statusMensagens.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusMensagens.Name = "statusMensagens";
            this.statusMensagens.Size = new System.Drawing.Size(74, 19);
            this.statusMensagens.Text = "Mensagens";
            this.statusMensagens.Visible = false;
            // 
            // serialArduino
            // 
            this.serialArduino.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialArduino_DataReceived);
            // 
            // monitorarConexao
            // 
            this.monitorarConexao.Enabled = true;
            this.monitorarConexao.Interval = 5000;
            this.monitorarConexao.Tick += new System.EventHandler(this.monitorarConexao_Tick);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 301);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal - Morpheus 2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem basesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusVersao;
        private System.Windows.Forms.ToolStripStatusLabel statusUsuario;
        private System.Windows.Forms.ToolStripMenuItem gerenciarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receitaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testarComandosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDosRelesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeComandoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçãoToolStripMenuItem;
        private System.IO.Ports.SerialPort serialArduino;
        private System.Windows.Forms.ToolStripStatusLabel statusArduino;
        private System.Windows.Forms.ToolStripStatusLabel statusPorta;
        private System.Windows.Forms.ToolStripStatusLabel statusMensagens;
        private System.Windows.Forms.ToolStripMenuItem comunicaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atualizarDataHoraControlMixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relesToolStripMenuItem1;
        private System.Windows.Forms.Timer monitorarConexao;
    }
}

