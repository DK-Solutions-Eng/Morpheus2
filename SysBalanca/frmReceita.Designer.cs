namespace SysBalanca
{
    partial class frmReceita
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.txtPesq = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnPausarReceita = new System.Windows.Forms.Button();
            this.btnIniciarReceita = new System.Windows.Forms.Button();
            this.btnCarregaReceita = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtValorLimite = new System.Windows.Forms.MaskedTextBox();
            this.txtValorCorte = new System.Windows.Forms.MaskedTextBox();
            this.txtValor = new System.Windows.Forms.MaskedTextBox();
            this.lblValorCorte = new System.Windows.Forms.Label();
            this.btnCancelarItem = new System.Windows.Forms.Button();
            this.btnNovoItem = new System.Windows.Forms.Button();
            this.btnMoveAcima = new System.Windows.Forms.Button();
            this.btnMoveBaixo = new System.Windows.Forms.Button();
            this.lblValorLimite = new System.Windows.Forms.Label();
            this.btnSalvarItem = new System.Windows.Forms.Button();
            this.btnDeletaItem = new System.Windows.Forms.Button();
            this.gridItensReceita = new System.Windows.Forms.DataGridView();
            this.sequência = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBJETIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CORTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AÇÃO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARAMETRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RELE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_LIMITE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALOR_LIMITE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboTipoLimite = new System.Windows.Forms.ComboBox();
            this.lblTipoLimite = new System.Windows.Forms.Label();
            this.cboParametro2 = new System.Windows.Forms.ComboBox();
            this.lblParametro2 = new System.Windows.Forms.Label();
            this.cboParametro1 = new System.Windows.Forms.ComboBox();
            this.lblParametro1 = new System.Windows.Forms.Label();
            this.cboAcao = new System.Windows.Forms.ComboBox();
            this.lblAcao = new System.Windows.Forms.Label();
            this.cboObjetivo = new System.Windows.Forms.ComboBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblObjetivo = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItensReceita)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1120, 530);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnIncluir);
            this.tabPage1.Controls.Add(this.grid);
            this.tabPage1.Controls.Add(this.txtPesq);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1112, 502);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listagem";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnIncluir
            // 
            this.btnIncluir.Image = global::SysBalanca.Properties.Resources.importar;
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncluir.Location = new System.Drawing.Point(970, 23);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(136, 47);
            this.btnIncluir.TabIndex = 5;
            this.btnIncluir.Text = "Nova Receita";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(15, 76);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.Size = new System.Drawing.Size(1091, 363);
            this.grid.TabIndex = 4;
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            // 
            // txtPesq
            // 
            this.txtPesq.Location = new System.Drawing.Point(15, 36);
            this.txtPesq.Name = "txtPesq";
            this.txtPesq.Size = new System.Drawing.Size(933, 23);
            this.txtPesq.TabIndex = 1;
            this.txtPesq.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPesq_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pesquisar (Para editar uma receita click duas vezes no registro):";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnPausarReceita);
            this.tabPage2.Controls.Add(this.btnIniciarReceita);
            this.tabPage2.Controls.Add(this.btnCarregaReceita);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.btnPesquisar);
            this.tabPage2.Controls.Add(this.btnExcluir);
            this.tabPage2.Controls.Add(this.btnConfirmar);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1112, 502);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cadastro";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnPausarReceita
            // 
            this.btnPausarReceita.Image = global::SysBalanca.Properties.Resources.cancelar;
            this.btnPausarReceita.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPausarReceita.Location = new System.Drawing.Point(947, 449);
            this.btnPausarReceita.Name = "btnPausarReceita";
            this.btnPausarReceita.Size = new System.Drawing.Size(159, 47);
            this.btnPausarReceita.TabIndex = 19;
            this.btnPausarReceita.Text = "Parar Receita";
            this.btnPausarReceita.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPausarReceita.UseVisualStyleBackColor = true;
            this.btnPausarReceita.Click += new System.EventHandler(this.btnPausarReceita_Click);
            // 
            // btnIniciarReceita
            // 
            this.btnIniciarReceita.Image = global::SysBalanca.Properties.Resources.confirmar;
            this.btnIniciarReceita.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciarReceita.Location = new System.Drawing.Point(782, 449);
            this.btnIniciarReceita.Name = "btnIniciarReceita";
            this.btnIniciarReceita.Size = new System.Drawing.Size(159, 47);
            this.btnIniciarReceita.TabIndex = 18;
            this.btnIniciarReceita.Text = "Executar Receita";
            this.btnIniciarReceita.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIniciarReceita.UseVisualStyleBackColor = true;
            this.btnIniciarReceita.Click += new System.EventHandler(this.btnIniciarReceita_Click);
            // 
            // btnCarregaReceita
            // 
            this.btnCarregaReceita.Image = global::SysBalanca.Properties.Resources.atualiza;
            this.btnCarregaReceita.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarregaReceita.Location = new System.Drawing.Point(617, 449);
            this.btnCarregaReceita.Name = "btnCarregaReceita";
            this.btnCarregaReceita.Size = new System.Drawing.Size(159, 47);
            this.btnCarregaReceita.TabIndex = 17;
            this.btnCarregaReceita.Text = "Carregar Receita";
            this.btnCarregaReceita.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCarregaReceita.UseVisualStyleBackColor = true;
            this.btnCarregaReceita.Click += new System.EventHandler(this.btnCarregaReceita_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtValorLimite);
            this.groupBox2.Controls.Add(this.txtValorCorte);
            this.groupBox2.Controls.Add(this.txtValor);
            this.groupBox2.Controls.Add(this.lblValorCorte);
            this.groupBox2.Controls.Add(this.btnCancelarItem);
            this.groupBox2.Controls.Add(this.btnNovoItem);
            this.groupBox2.Controls.Add(this.btnMoveAcima);
            this.groupBox2.Controls.Add(this.btnMoveBaixo);
            this.groupBox2.Controls.Add(this.lblValorLimite);
            this.groupBox2.Controls.Add(this.btnSalvarItem);
            this.groupBox2.Controls.Add(this.btnDeletaItem);
            this.groupBox2.Controls.Add(this.gridItensReceita);
            this.groupBox2.Controls.Add(this.cboTipoLimite);
            this.groupBox2.Controls.Add(this.lblTipoLimite);
            this.groupBox2.Controls.Add(this.cboParametro2);
            this.groupBox2.Controls.Add(this.lblParametro2);
            this.groupBox2.Controls.Add(this.cboParametro1);
            this.groupBox2.Controls.Add(this.lblParametro1);
            this.groupBox2.Controls.Add(this.cboAcao);
            this.groupBox2.Controls.Add(this.lblAcao);
            this.groupBox2.Controls.Add(this.cboObjetivo);
            this.groupBox2.Controls.Add(this.lblValor);
            this.groupBox2.Controls.Add(this.lblObjetivo);
            this.groupBox2.Location = new System.Drawing.Point(6, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1100, 342);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados do passo a passo da Receita";
            // 
            // txtValorLimite
            // 
            this.txtValorLimite.Location = new System.Drawing.Point(943, 37);
            this.txtValorLimite.Name = "txtValorLimite";
            this.txtValorLimite.Size = new System.Drawing.Size(150, 23);
            this.txtValorLimite.TabIndex = 11;
            this.txtValorLimite.Leave += new System.EventHandler(this.txtValorLimite_Leave);
            // 
            // txtValorCorte
            // 
            this.txtValorCorte.Location = new System.Drawing.Point(165, 82);
            this.txtValorCorte.Name = "txtValorCorte";
            this.txtValorCorte.Size = new System.Drawing.Size(146, 23);
            this.txtValorCorte.TabIndex = 6;
            this.txtValorCorte.Leave += new System.EventHandler(this.txtValorCorte_Leave);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(163, 37);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(148, 23);
            this.txtValor.TabIndex = 5;
            this.txtValor.Leave += new System.EventHandler(this.maskedTextBox1_Leave_1);
            // 
            // lblValorCorte
            // 
            this.lblValorCorte.AutoSize = true;
            this.lblValorCorte.Location = new System.Drawing.Point(162, 64);
            this.lblValorCorte.Name = "lblValorCorte";
            this.lblValorCorte.Size = new System.Drawing.Size(91, 15);
            this.lblValorCorte.TabIndex = 24;
            this.lblValorCorte.Text = "Valor Corte:";
            // 
            // btnCancelarItem
            // 
            this.btnCancelarItem.Enabled = false;
            this.btnCancelarItem.Image = global::SysBalanca.Properties.Resources.cancelar;
            this.btnCancelarItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarItem.Location = new System.Drawing.Point(463, 276);
            this.btnCancelarItem.Name = "btnCancelarItem";
            this.btnCancelarItem.Size = new System.Drawing.Size(144, 39);
            this.btnCancelarItem.TabIndex = 13;
            this.btnCancelarItem.Text = "Cancelar Item";
            this.btnCancelarItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarItem.UseVisualStyleBackColor = true;
            this.btnCancelarItem.Click += new System.EventHandler(this.btnCancelarItem_Click);
            // 
            // btnNovoItem
            // 
            this.btnNovoItem.Enabled = false;
            this.btnNovoItem.Image = global::SysBalanca.Properties.Resources.importar;
            this.btnNovoItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovoItem.Location = new System.Drawing.Point(163, 276);
            this.btnNovoItem.Name = "btnNovoItem";
            this.btnNovoItem.Size = new System.Drawing.Size(144, 39);
            this.btnNovoItem.TabIndex = 3;
            this.btnNovoItem.Text = "Novo Item";
            this.btnNovoItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovoItem.UseVisualStyleBackColor = true;
            this.btnNovoItem.Click += new System.EventHandler(this.btnNovoItem_Click);
            // 
            // btnMoveAcima
            // 
            this.btnMoveAcima.Enabled = false;
            this.btnMoveAcima.Location = new System.Drawing.Point(82, 276);
            this.btnMoveAcima.Name = "btnMoveAcima";
            this.btnMoveAcima.Size = new System.Drawing.Size(75, 23);
            this.btnMoveAcima.TabIndex = 21;
            this.btnMoveAcima.Text = "▼";
            this.btnMoveAcima.UseVisualStyleBackColor = true;
            this.btnMoveAcima.Click += new System.EventHandler(this.btnMoveAcima_Click);
            // 
            // btnMoveBaixo
            // 
            this.btnMoveBaixo.Enabled = false;
            this.btnMoveBaixo.Location = new System.Drawing.Point(6, 276);
            this.btnMoveBaixo.Name = "btnMoveBaixo";
            this.btnMoveBaixo.Size = new System.Drawing.Size(75, 23);
            this.btnMoveBaixo.TabIndex = 20;
            this.btnMoveBaixo.Text = "▲";
            this.btnMoveBaixo.UseVisualStyleBackColor = true;
            this.btnMoveBaixo.Click += new System.EventHandler(this.btnMoveAbaixo_Click);
            // 
            // lblValorLimite
            // 
            this.lblValorLimite.AutoSize = true;
            this.lblValorLimite.Location = new System.Drawing.Point(940, 19);
            this.lblValorLimite.Name = "lblValorLimite";
            this.lblValorLimite.Size = new System.Drawing.Size(98, 15);
            this.lblValorLimite.TabIndex = 19;
            this.lblValorLimite.Text = "Valor Limite:";
            // 
            // btnSalvarItem
            // 
            this.btnSalvarItem.Enabled = false;
            this.btnSalvarItem.Image = global::SysBalanca.Properties.Resources.confirmar;
            this.btnSalvarItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvarItem.Location = new System.Drawing.Point(313, 276);
            this.btnSalvarItem.Name = "btnSalvarItem";
            this.btnSalvarItem.Size = new System.Drawing.Size(144, 39);
            this.btnSalvarItem.TabIndex = 12;
            this.btnSalvarItem.Text = "Salvar Item";
            this.btnSalvarItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvarItem.UseVisualStyleBackColor = true;
            this.btnSalvarItem.Click += new System.EventHandler(this.btnAdicionaItem_Click);
            // 
            // btnDeletaItem
            // 
            this.btnDeletaItem.Enabled = false;
            this.btnDeletaItem.Image = global::SysBalanca.Properties.Resources.excluir;
            this.btnDeletaItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeletaItem.Location = new System.Drawing.Point(613, 276);
            this.btnDeletaItem.Name = "btnDeletaItem";
            this.btnDeletaItem.Size = new System.Drawing.Size(144, 39);
            this.btnDeletaItem.TabIndex = 14;
            this.btnDeletaItem.Text = "Deletar Item";
            this.btnDeletaItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeletaItem.UseVisualStyleBackColor = true;
            this.btnDeletaItem.Click += new System.EventHandler(this.btnDeletaItem_Click);
            // 
            // gridItensReceita
            // 
            this.gridItensReceita.AllowUserToAddRows = false;
            this.gridItensReceita.AllowUserToDeleteRows = false;
            this.gridItensReceita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItensReceita.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sequência,
            this.OBJETIVO,
            this.VALOR,
            this.CORTE,
            this.AÇÃO,
            this.PARAMETRO,
            this.RELE,
            this.TIPO_LIMITE,
            this.VALOR_LIMITE,
            this.ID});
            this.gridItensReceita.Location = new System.Drawing.Point(6, 64);
            this.gridItensReceita.Name = "gridItensReceita";
            this.gridItensReceita.ReadOnly = true;
            this.gridItensReceita.Size = new System.Drawing.Size(1087, 160);
            this.gridItensReceita.TabIndex = 17;
            this.gridItensReceita.DoubleClick += new System.EventHandler(this.gridItensReceita_DoubleClick);
            // 
            // sequência
            // 
            this.sequência.DataPropertyName = "SEQUÊNCIA";
            this.sequência.HeaderText = "SEQUÊNCIA";
            this.sequência.Name = "sequência";
            this.sequência.ReadOnly = true;
            this.sequência.Width = 75;
            // 
            // OBJETIVO
            // 
            this.OBJETIVO.DataPropertyName = "OBJETIVO";
            this.OBJETIVO.HeaderText = "OBJETIVO";
            this.OBJETIVO.Name = "OBJETIVO";
            this.OBJETIVO.ReadOnly = true;
            // 
            // VALOR
            // 
            this.VALOR.DataPropertyName = "VALOR";
            this.VALOR.HeaderText = "PRÉ CORTE / TEMPO";
            this.VALOR.Name = "VALOR";
            this.VALOR.ReadOnly = true;
            this.VALOR.Width = 151;
            // 
            // CORTE
            // 
            this.CORTE.DataPropertyName = "CORTE";
            this.CORTE.HeaderText = "CORTE";
            this.CORTE.Name = "CORTE";
            this.CORTE.ReadOnly = true;
            this.CORTE.Width = 80;
            // 
            // AÇÃO
            // 
            this.AÇÃO.DataPropertyName = "AÇÃO";
            this.AÇÃO.HeaderText = "AÇÃO";
            this.AÇÃO.Name = "AÇÃO";
            this.AÇÃO.ReadOnly = true;
            this.AÇÃO.Width = 110;
            // 
            // PARAMETRO
            // 
            this.PARAMETRO.DataPropertyName = "PARAMETRO";
            this.PARAMETRO.HeaderText = "PARAMETRO";
            this.PARAMETRO.Name = "PARAMETRO";
            this.PARAMETRO.ReadOnly = true;
            this.PARAMETRO.Width = 120;
            // 
            // RELE
            // 
            this.RELE.DataPropertyName = "RELE";
            this.RELE.HeaderText = "RELE";
            this.RELE.Name = "RELE";
            this.RELE.ReadOnly = true;
            this.RELE.Width = 170;
            // 
            // TIPO_LIMITE
            // 
            this.TIPO_LIMITE.DataPropertyName = "TIPO_LIMITE";
            this.TIPO_LIMITE.HeaderText = "TIPO LIMITE";
            this.TIPO_LIMITE.Name = "TIPO_LIMITE";
            this.TIPO_LIMITE.ReadOnly = true;
            this.TIPO_LIMITE.Width = 120;
            // 
            // VALOR_LIMITE
            // 
            this.VALOR_LIMITE.DataPropertyName = "VALOR_LIMITE";
            this.VALOR_LIMITE.HeaderText = "VALOR LIMITE";
            this.VALOR_LIMITE.Name = "VALOR_LIMITE";
            this.VALOR_LIMITE.ReadOnly = true;
            this.VALOR_LIMITE.Width = 120;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 40;
            // 
            // cboTipoLimite
            // 
            this.cboTipoLimite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoLimite.Enabled = false;
            this.cboTipoLimite.FormattingEnabled = true;
            this.cboTipoLimite.Location = new System.Drawing.Point(787, 37);
            this.cboTipoLimite.Name = "cboTipoLimite";
            this.cboTipoLimite.Size = new System.Drawing.Size(150, 23);
            this.cboTipoLimite.TabIndex = 10;
            this.cboTipoLimite.SelectedIndexChanged += new System.EventHandler(this.cboTipoLimite_SelectedIndexChanged);
            // 
            // lblTipoLimite
            // 
            this.lblTipoLimite.AutoSize = true;
            this.lblTipoLimite.Location = new System.Drawing.Point(784, 19);
            this.lblTipoLimite.Name = "lblTipoLimite";
            this.lblTipoLimite.Size = new System.Drawing.Size(91, 15);
            this.lblTipoLimite.TabIndex = 12;
            this.lblTipoLimite.Text = "Tipo Limite:";
            // 
            // cboParametro2
            // 
            this.cboParametro2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParametro2.Enabled = false;
            this.cboParametro2.FormattingEnabled = true;
            this.cboParametro2.Location = new System.Drawing.Point(631, 37);
            this.cboParametro2.Name = "cboParametro2";
            this.cboParametro2.Size = new System.Drawing.Size(150, 23);
            this.cboParametro2.TabIndex = 9;
            // 
            // lblParametro2
            // 
            this.lblParametro2.AutoSize = true;
            this.lblParametro2.Location = new System.Drawing.Point(628, 19);
            this.lblParametro2.Name = "lblParametro2";
            this.lblParametro2.Size = new System.Drawing.Size(42, 15);
            this.lblParametro2.TabIndex = 10;
            this.lblParametro2.Text = "Rele:";
            // 
            // cboParametro1
            // 
            this.cboParametro1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParametro1.Enabled = false;
            this.cboParametro1.FormattingEnabled = true;
            this.cboParametro1.Location = new System.Drawing.Point(475, 37);
            this.cboParametro1.Name = "cboParametro1";
            this.cboParametro1.Size = new System.Drawing.Size(150, 23);
            this.cboParametro1.TabIndex = 8;
            // 
            // lblParametro1
            // 
            this.lblParametro1.AutoSize = true;
            this.lblParametro1.Location = new System.Drawing.Point(472, 19);
            this.lblParametro1.Name = "lblParametro1";
            this.lblParametro1.Size = new System.Drawing.Size(77, 15);
            this.lblParametro1.TabIndex = 8;
            this.lblParametro1.Text = "Parametro:";
            // 
            // cboAcao
            // 
            this.cboAcao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAcao.Enabled = false;
            this.cboAcao.FormattingEnabled = true;
            this.cboAcao.Location = new System.Drawing.Point(319, 37);
            this.cboAcao.Name = "cboAcao";
            this.cboAcao.Size = new System.Drawing.Size(150, 23);
            this.cboAcao.TabIndex = 7;
            this.cboAcao.SelectedIndexChanged += new System.EventHandler(this.cboAcao_SelectedIndexChanged);
            // 
            // lblAcao
            // 
            this.lblAcao.AutoSize = true;
            this.lblAcao.Location = new System.Drawing.Point(316, 19);
            this.lblAcao.Name = "lblAcao";
            this.lblAcao.Size = new System.Drawing.Size(42, 15);
            this.lblAcao.TabIndex = 6;
            this.lblAcao.Text = "Ação:";
            // 
            // cboObjetivo
            // 
            this.cboObjetivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObjetivo.Enabled = false;
            this.cboObjetivo.FormattingEnabled = true;
            this.cboObjetivo.Location = new System.Drawing.Point(7, 37);
            this.cboObjetivo.Name = "cboObjetivo";
            this.cboObjetivo.Size = new System.Drawing.Size(150, 23);
            this.cboObjetivo.TabIndex = 4;
            this.cboObjetivo.SelectedIndexChanged += new System.EventHandler(this.cboObjetivo_SelectedIndexChanged);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(162, 19);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(49, 15);
            this.lblValor.TabIndex = 2;
            this.lblValor.Text = "Valor:";
            // 
            // lblObjetivo
            // 
            this.lblObjetivo.AutoSize = true;
            this.lblObjetivo.Location = new System.Drawing.Point(6, 19);
            this.lblObjetivo.Name = "lblObjetivo";
            this.lblObjetivo.Size = new System.Drawing.Size(70, 15);
            this.lblObjetivo.TabIndex = 0;
            this.lblObjetivo.Text = "Objetivo:";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Enabled = false;
            this.btnPesquisar.Image = global::SysBalanca.Properties.Resources.procurar;
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(336, 449);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(159, 47);
            this.btnPesquisar.TabIndex = 16;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = global::SysBalanca.Properties.Resources.excluir;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(171, 449);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(159, 47);
            this.btnExcluir.TabIndex = 15;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Enabled = false;
            this.btnConfirmar.Image = global::SysBalanca.Properties.Resources.confirmar;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.Location = new System.Drawing.Point(6, 449);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(159, 47);
            this.btnConfirmar.TabIndex = 15;
            this.btnConfirmar.Text = "Salvar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1100, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Receita";
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Location = new System.Drawing.Point(63, 38);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(1030, 23);
            this.txtNome.TabIndex = 2;
            this.txtNome.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNome_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nome da Receita";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(7, 38);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(50, 23);
            this.txtCodigo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Id:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 542);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1120, 10);
            this.progressBar.TabIndex = 25;
            this.progressBar.Visible = false;
            // 
            // frmReceita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 552);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.Name = "frmReceita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Receitas - Morpheus 2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReceita_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItensReceita)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TextBox txtPesq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboTipoLimite;
        private System.Windows.Forms.Label lblTipoLimite;
        private System.Windows.Forms.ComboBox cboParametro2;
        private System.Windows.Forms.Label lblParametro2;
        private System.Windows.Forms.ComboBox cboParametro1;
        private System.Windows.Forms.Label lblParametro1;
        private System.Windows.Forms.ComboBox cboAcao;
        private System.Windows.Forms.Label lblAcao;
        private System.Windows.Forms.ComboBox cboObjetivo;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblObjetivo;
        private System.Windows.Forms.Button btnSalvarItem;
        private System.Windows.Forms.Button btnDeletaItem;
        private System.Windows.Forms.DataGridView gridItensReceita;
        private System.Windows.Forms.Label lblValorLimite;
        private System.Windows.Forms.Button btnMoveAcima;
        private System.Windows.Forms.Button btnMoveBaixo;
        private System.Windows.Forms.Button btnCancelarItem;
        private System.Windows.Forms.Button btnNovoItem;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Label lblValorCorte;
        private System.Windows.Forms.MaskedTextBox txtValor;
        private System.Windows.Forms.MaskedTextBox txtValorCorte;
        private System.Windows.Forms.MaskedTextBox txtValorLimite;
        private System.Windows.Forms.Button btnCarregaReceita;
        private System.Windows.Forms.Button btnPausarReceita;
        private System.Windows.Forms.Button btnIniciarReceita;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn sequência;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBJETIVO;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CORTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn AÇÃO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARAMETRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RELE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_LIMITE;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALOR_LIMITE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}