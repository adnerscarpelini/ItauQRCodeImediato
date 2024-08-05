using Business.Services;
using Model.Entities;
using QRCoder;

namespace WinClient
{
    public partial class FrmInicio : Form
    {
        private Color azul = Color.FromArgb(25, 45, 100);
        private Color azulEscuro = Color.FromArgb(13, 23, 51);
        private Color laranja = Color.FromArgb(236, 112, 0);

        ItauQRCodeImediatoService itauQRCodeImediatoService = new ItauQRCodeImediatoService();

        public FrmInicio()
        {
            InitializeComponent();
            setColorTheme();
            loadComboBoxAmbiente();

            //Fixar valores para facilitar o teste
            txtClientId.Text = "";
            txtClientSecret.Text = "";
            txtChave.Text = "60701190000104";
        }

        private void setColorTheme()
        {
            this.BackColor = azul;
            btnGerarQRCodePix.BackColor = azul;
            btnGerarQRCodePix.ForeColor = laranja;

            pnlDadosAutenticacao.BackColor =
                pnlDadosCobranca.BackColor =
                pnlQRCodePix.BackColor = azulEscuro;


            lblDadosAutenticacao.ForeColor =
                lblAmbiente.ForeColor =
                lblClientID.ForeColor =
                lblClientSecret.ForeColor =
                lblDadosCobranca.ForeColor =
                lblChave.ForeColor =
                lblValor.ForeColor =
                lblIdentificador.ForeColor =
                lblDataHoraExpiracao.ForeColor =
                lblPixCopiaCola.ForeColor =
                lblQRCodePix.ForeColor =
                lblOutput.ForeColor =
                Color.White;
        }

        private void loadComboBoxAmbiente()
        {
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "sandbox", "Sandbox (https://sandbox.devportal.itau.com.br/)" },
            };

            var items = values.Select(kvp => new { Key = kvp.Key, Value = kvp.Value }).ToList();

            cbxAmbiente.DataSource = items;

            cbxAmbiente.DisplayMember = "Value";
            cbxAmbiente.ValueMember = "Key";
        }

        private void btnGerarQRCodePix_Paint(object sender, PaintEventArgs e)
        {
            // Define a cor da borda
            Color borderColor = laranja;

            // Desenha a borda ao redor do botão
            int borderThickness = 2; // espessura da borda
            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                Rectangle rect = new Rectangle(0, 0, btnGerarQRCodePix.Width, btnGerarQRCodePix.Height);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }


        private void generateQRCodeImage(string textoImagemQRCode)
        {
            try
            {
                imgQRCodePix.Image = null;

                if (!string.IsNullOrEmpty(textoImagemQRCode))
                {
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(textoImagemQRCode, QRCodeGenerator.ECCLevel.Q, true);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(72);
                    imgQRCodePix.Image = qrCodeImage;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Não foi possível gerar o QR Code. Detalhes: " + ex.Message);
            }
        }

        private void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                e.KeyChar = ',';

                if (txtValor.Text.Contains(","))
                    e.Handled = true;
            }
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private async void btnGerarQRCodePix_Click(object sender, EventArgs e)
        {
            try
            {
                clearFields();

                if (string.IsNullOrWhiteSpace(txtClientId.Text))
                {
                    ShowErrorMessage("Informe o Client Id!");
                    txtClientId.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtClientSecret.Text))
                {
                    ShowErrorMessage("Informe o Client Secret!");
                    txtClientSecret.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtChave.Text))
                {
                    ShowErrorMessage("Informe a Chave para Receber!");
                    txtChave.Focus();
                    return;
                }

                decimal valor = 0;
                if (!decimal.TryParse(txtValor.Text, out valor))
                {
                    ShowErrorMessage("O Valor informado é inválido!");
                    txtValor.Focus();
                    return;
                }

                if (valor <= 0)
                {
                    ShowErrorMessage("O Valor informado é inválido!");
                    txtValor.Focus();
                    return;
                }

                generateLogMessage("Autenticando...");
                OAuth2 oAuth2;
                oAuth2 = await itauQRCodeImediatoService.Authenticate(
                                ambiente: (string)cbxAmbiente.SelectedValue!,
                                clientId: txtClientId.Text,
                                clientSecret: txtClientSecret.Text);

                if (oAuth2 != null)
                {
                    generateLogMessage("Token recebido: " + oAuth2.access_token);

                    generateLogMessage("Criando Cobrança Imediata via API...");
                    QRCodeImediato qRCodeImediatoResponse = await itauQRCodeImediatoService.PostQRCodeImediato(
                                    ambiente: (string)cbxAmbiente.SelectedValue!,
                                    clientId: txtClientId.Text,
                                    oAuth2: oAuth2,
                                    chave: txtChave.Text,
                                    valor: txtValor.Text);

                    if (qRCodeImediatoResponse != null)
                    {
                        generateLogMessage("Cobrança Imediata via API gerada");
                        generateLogMessage("Identificador da Cobrança Imediata via API gerada: " + qRCodeImediatoResponse.txid);

                        generateLogMessage("Gerando imagem do QR Code...");
                        loadFieldsQRCodeImediato(qRCodeImediatoResponse);
                        generateLogMessage("Processo finalizado com sucesso!");

                    }
                }

            }
            catch (Exception ex)
            {
                generateLogMessage(ex.Message);
                ShowErrorMessage(ex.Message);
            }
        }

        private void clearFields()
        {
            txtOutput.Text = string.Empty;
            txtIdentificador.Text = string.Empty;
            txtDataHoraExpiracao.Text = string.Empty;
            txtPixCopiaCola.Text = string.Empty;
            imgQRCodePix.Image = Properties.Resources.pix_aguardando;
        }

        private void loadFieldsQRCodeImediato(QRCodeImediato qrCodeImediato)
        {
            txtIdentificador.Text = qrCodeImediato.txid;

            DateTime? dataHoraCriacao = null;

            if (qrCodeImediato.calendario != null)
            {
                if (qrCodeImediato.calendario.criacao.HasValue)
                {
                    dataHoraCriacao = qrCodeImediato.calendario.criacao.Value;
                    DateTime dataHoraExpiracao = dataHoraCriacao.Value;

                    if (qrCodeImediato.calendario.expiracao.HasValue)
                        dataHoraExpiracao = dataHoraExpiracao.AddSeconds(qrCodeImediato.calendario.expiracao.Value);

                    txtDataHoraExpiracao.Text = dataHoraExpiracao.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }

            if (!dataHoraCriacao.HasValue)
                generateLogMessage("A API não retornou a Data de Criação da Cobrança...");

            if (!string.IsNullOrEmpty(qrCodeImediato.pixCopiaECola))
            {
                txtPixCopiaCola.Text = qrCodeImediato.pixCopiaECola;

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeImediato.pixCopiaECola, QRCodeGenerator.ECCLevel.Q, true);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(72);
                imgQRCodePix.Image = qrCodeImage;
            }
            else
                generateLogMessage("A API não retornou os dados do Pix Copia e Cola...");

        }

        private void generateLogMessage(string message)
        {
            txtOutput.Text += message + "\n\n";
            Application.DoEvents();
        }

    }
}
