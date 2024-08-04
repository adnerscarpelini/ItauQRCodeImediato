using QRCoder;
using System.Globalization;

namespace WinClient
{
    public partial class FrmInicio : Form
    {
        private Color azul = Color.FromArgb(25, 45, 100);
        private Color azulEscuro = Color.FromArgb(13, 23, 51);
        private Color laranja = Color.FromArgb(236, 112, 0);

        public FrmInicio()
        {
            InitializeComponent();
            setColorTheme();
            loadComboBoxAmbiente();
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
                Color.White;
        }

        private void loadComboBoxAmbiente()
        {
            Dictionary<int, string> values = new Dictionary<int, string>
            {
                { 1, "Sandbox (https://sandbox.devportal.itau.com.br/)" },
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
    }
}
