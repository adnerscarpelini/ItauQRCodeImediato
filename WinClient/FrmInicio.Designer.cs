namespace WinClient
{
    partial class FrmInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGerarQRCodePix = new Button();
            pnlDadosAutenticacao = new Panel();
            txtClientSecret = new TextBox();
            lblClientSecret = new Label();
            txtClientId = new TextBox();
            lblClientID = new Label();
            lblDadosAutenticacao = new Label();
            lblDadosCobranca = new Label();
            pnlDadosCobranca = new Panel();
            txtPixCopiaCola = new TextBox();
            lblPixCopiaCola = new Label();
            txtDataHoraExpiracao = new TextBox();
            lblDataHoraExpiracao = new Label();
            txtIdentificador = new TextBox();
            lblIdentificador = new Label();
            txtValor = new TextBox();
            lblValor = new Label();
            txtChave = new TextBox();
            lblChave = new Label();
            pnlQRCodePix = new Panel();
            imgQRCodePix = new PictureBox();
            lblQRCodePix = new Label();
            lblAmbiente = new Label();
            cbxAmbiente = new ComboBox();
            pnlDadosAutenticacao.SuspendLayout();
            pnlDadosCobranca.SuspendLayout();
            pnlQRCodePix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgQRCodePix).BeginInit();
            SuspendLayout();
            // 
            // btnGerarQRCodePix
            // 
            btnGerarQRCodePix.Cursor = Cursors.Hand;
            btnGerarQRCodePix.FlatStyle = FlatStyle.Flat;
            btnGerarQRCodePix.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGerarQRCodePix.Location = new Point(711, 393);
            btnGerarQRCodePix.Name = "btnGerarQRCodePix";
            btnGerarQRCodePix.Size = new Size(124, 38);
            btnGerarQRCodePix.TabIndex = 6;
            btnGerarQRCodePix.Text = "Gerar QR Code";
            btnGerarQRCodePix.UseVisualStyleBackColor = true;
            btnGerarQRCodePix.Paint += btnGerarQRCodePix_Paint;
            // 
            // pnlDadosAutenticacao
            // 
            pnlDadosAutenticacao.Controls.Add(txtClientSecret);
            pnlDadosAutenticacao.Controls.Add(lblClientSecret);
            pnlDadosAutenticacao.Controls.Add(txtClientId);
            pnlDadosAutenticacao.Controls.Add(lblClientID);
            pnlDadosAutenticacao.Location = new Point(12, 53);
            pnlDadosAutenticacao.Name = "pnlDadosAutenticacao";
            pnlDadosAutenticacao.Size = new Size(497, 112);
            pnlDadosAutenticacao.TabIndex = 1;
            // 
            // txtClientSecret
            // 
            txtClientSecret.Location = new Point(7, 71);
            txtClientSecret.Name = "txtClientSecret";
            txtClientSecret.Size = new Size(444, 22);
            txtClientSecret.TabIndex = 3;
            // 
            // lblClientSecret
            // 
            lblClientSecret.AutoSize = true;
            lblClientSecret.Location = new Point(7, 54);
            lblClientSecret.Name = "lblClientSecret";
            lblClientSecret.Size = new Size(74, 14);
            lblClientSecret.TabIndex = 2;
            lblClientSecret.Text = "Client Secret";
            // 
            // txtClientId
            // 
            txtClientId.Location = new Point(7, 26);
            txtClientId.Name = "txtClientId";
            txtClientId.Size = new Size(444, 22);
            txtClientId.TabIndex = 1;
            // 
            // lblClientID
            // 
            lblClientID.AutoSize = true;
            lblClientID.Location = new Point(7, 9);
            lblClientID.Name = "lblClientID";
            lblClientID.Size = new Size(52, 14);
            lblClientID.TabIndex = 0;
            lblClientID.Text = "Client ID";
            // 
            // lblDadosAutenticacao
            // 
            lblDadosAutenticacao.AutoSize = true;
            lblDadosAutenticacao.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDadosAutenticacao.Location = new Point(12, 36);
            lblDadosAutenticacao.Name = "lblDadosAutenticacao";
            lblDadosAutenticacao.Size = new Size(130, 14);
            lblDadosAutenticacao.TabIndex = 0;
            lblDadosAutenticacao.Text = "Dados de Autenticação";
            // 
            // lblDadosCobranca
            // 
            lblDadosCobranca.AutoSize = true;
            lblDadosCobranca.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDadosCobranca.Location = new Point(12, 177);
            lblDadosCobranca.Name = "lblDadosCobranca";
            lblDadosCobranca.Size = new Size(131, 14);
            lblDadosCobranca.TabIndex = 2;
            lblDadosCobranca.Text = "Dados da Cobrança Pix";
            // 
            // pnlDadosCobranca
            // 
            pnlDadosCobranca.Controls.Add(txtPixCopiaCola);
            pnlDadosCobranca.Controls.Add(lblPixCopiaCola);
            pnlDadosCobranca.Controls.Add(txtDataHoraExpiracao);
            pnlDadosCobranca.Controls.Add(lblDataHoraExpiracao);
            pnlDadosCobranca.Controls.Add(txtIdentificador);
            pnlDadosCobranca.Controls.Add(lblIdentificador);
            pnlDadosCobranca.Controls.Add(txtValor);
            pnlDadosCobranca.Controls.Add(lblValor);
            pnlDadosCobranca.Controls.Add(txtChave);
            pnlDadosCobranca.Controls.Add(lblChave);
            pnlDadosCobranca.Location = new Point(12, 194);
            pnlDadosCobranca.Name = "pnlDadosCobranca";
            pnlDadosCobranca.Size = new Size(497, 193);
            pnlDadosCobranca.TabIndex = 3;
            // 
            // txtPixCopiaCola
            // 
            txtPixCopiaCola.Location = new Point(7, 113);
            txtPixCopiaCola.Multiline = true;
            txtPixCopiaCola.Name = "txtPixCopiaCola";
            txtPixCopiaCola.ReadOnly = true;
            txtPixCopiaCola.Size = new Size(476, 59);
            txtPixCopiaCola.TabIndex = 9;
            // 
            // lblPixCopiaCola
            // 
            lblPixCopiaCola.AutoSize = true;
            lblPixCopiaCola.Location = new Point(7, 96);
            lblPixCopiaCola.Name = "lblPixCopiaCola";
            lblPixCopiaCola.Size = new Size(96, 14);
            lblPixCopiaCola.TabIndex = 8;
            lblPixCopiaCola.Text = "Pix Copia e Cola";
            // 
            // txtDataHoraExpiracao
            // 
            txtDataHoraExpiracao.Location = new Point(314, 69);
            txtDataHoraExpiracao.Name = "txtDataHoraExpiracao";
            txtDataHoraExpiracao.ReadOnly = true;
            txtDataHoraExpiracao.Size = new Size(169, 22);
            txtDataHoraExpiracao.TabIndex = 7;
            txtDataHoraExpiracao.TextAlign = HorizontalAlignment.Center;
            // 
            // lblDataHoraExpiracao
            // 
            lblDataHoraExpiracao.AutoSize = true;
            lblDataHoraExpiracao.Location = new Point(314, 52);
            lblDataHoraExpiracao.Name = "lblDataHoraExpiracao";
            lblDataHoraExpiracao.Size = new Size(61, 14);
            lblDataHoraExpiracao.TabIndex = 6;
            lblDataHoraExpiracao.Text = "Expiração";
            // 
            // txtIdentificador
            // 
            txtIdentificador.Location = new Point(7, 69);
            txtIdentificador.Name = "txtIdentificador";
            txtIdentificador.ReadOnly = true;
            txtIdentificador.Size = new Size(301, 22);
            txtIdentificador.TabIndex = 5;
            // 
            // lblIdentificador
            // 
            lblIdentificador.AutoSize = true;
            lblIdentificador.Location = new Point(7, 52);
            lblIdentificador.Name = "lblIdentificador";
            lblIdentificador.Size = new Size(75, 14);
            lblIdentificador.TabIndex = 4;
            lblIdentificador.Text = "Identificador";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(372, 26);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(111, 22);
            txtValor.TabIndex = 3;
            txtValor.TextAlign = HorizontalAlignment.Right;
            txtValor.KeyPress += txtValor_KeyPress;
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(372, 9);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(61, 14);
            lblValor.TabIndex = 2;
            lblValor.Text = "Valor (R$)";
            // 
            // txtChave
            // 
            txtChave.Location = new Point(7, 26);
            txtChave.Name = "txtChave";
            txtChave.Size = new Size(359, 22);
            txtChave.TabIndex = 1;
            // 
            // lblChave
            // 
            lblChave.AutoSize = true;
            lblChave.Location = new Point(7, 9);
            lblChave.Name = "lblChave";
            lblChave.Size = new Size(114, 14);
            lblChave.TabIndex = 0;
            lblChave.Text = "Chave para Receber";
            // 
            // pnlQRCodePix
            // 
            pnlQRCodePix.Controls.Add(imgQRCodePix);
            pnlQRCodePix.Location = new Point(515, 53);
            pnlQRCodePix.Name = "pnlQRCodePix";
            pnlQRCodePix.Size = new Size(320, 334);
            pnlQRCodePix.TabIndex = 5;
            // 
            // imgQRCodePix
            // 
            imgQRCodePix.Image = Properties.Resources.pix_aguardando;
            imgQRCodePix.Location = new Point(10, 17);
            imgQRCodePix.Name = "imgQRCodePix";
            imgQRCodePix.Size = new Size(300, 300);
            imgQRCodePix.SizeMode = PictureBoxSizeMode.Zoom;
            imgQRCodePix.TabIndex = 0;
            imgQRCodePix.TabStop = false;
            // 
            // lblQRCodePix
            // 
            lblQRCodePix.AutoSize = true;
            lblQRCodePix.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQRCodePix.Location = new Point(515, 36);
            lblQRCodePix.Name = "lblQRCodePix";
            lblQRCodePix.Size = new Size(74, 14);
            lblQRCodePix.TabIndex = 4;
            lblQRCodePix.Text = "QR Code Pix";
            // 
            // lblAmbiente
            // 
            lblAmbiente.AutoSize = true;
            lblAmbiente.Font = new Font("Roboto", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAmbiente.Location = new Point(12, 10);
            lblAmbiente.Name = "lblAmbiente";
            lblAmbiente.Size = new Size(61, 14);
            lblAmbiente.TabIndex = 7;
            lblAmbiente.Text = "Ambiente:";
            // 
            // cbxAmbiente
            // 
            cbxAmbiente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxAmbiente.FormattingEnabled = true;
            cbxAmbiente.Location = new Point(79, 6);
            cbxAmbiente.Name = "cbxAmbiente";
            cbxAmbiente.Size = new Size(430, 22);
            cbxAmbiente.TabIndex = 8;
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 445);
            Controls.Add(cbxAmbiente);
            Controls.Add(lblAmbiente);
            Controls.Add(lblQRCodePix);
            Controls.Add(pnlQRCodePix);
            Controls.Add(lblDadosCobranca);
            Controls.Add(pnlDadosCobranca);
            Controls.Add(lblDadosAutenticacao);
            Controls.Add(pnlDadosAutenticacao);
            Controls.Add(btnGerarQRCodePix);
            Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerador de QR Code Pix Itaú";
            pnlDadosAutenticacao.ResumeLayout(false);
            pnlDadosAutenticacao.PerformLayout();
            pnlDadosCobranca.ResumeLayout(false);
            pnlDadosCobranca.PerformLayout();
            pnlQRCodePix.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imgQRCodePix).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGerarQRCodePix;
        private Panel pnlDadosAutenticacao;
        private Label lblDadosAutenticacao;
        private Label lblClientID;
        private TextBox txtClientId;
        private TextBox txtClientSecret;
        private Label lblClientSecret;
        private Label lblDadosCobranca;
        private Panel pnlDadosCobranca;
        private TextBox txtValor;
        private Label lblValor;
        private TextBox txtChave;
        private Label lblChave;
        private TextBox txtIdentificador;
        private Label lblIdentificador;
        private TextBox txtDataHoraExpiracao;
        private Label lblDataHoraExpiracao;
        private TextBox txtPixCopiaCola;
        private Label lblPixCopiaCola;
        private Panel pnlQRCodePix;
        private Label lblQRCodePix;
        private Label lblAmbiente;
        private ComboBox cbxAmbiente;
        private PictureBox imgQRCodePix;
    }
}
