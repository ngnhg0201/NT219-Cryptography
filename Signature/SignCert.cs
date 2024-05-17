using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using iText.Kernel.Colors;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pqc.Crypto.Falcon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using Net.Codecrete.QrCodeGenerator;
using iText.Layout;
using iText.IO.Image;
using System.Drawing;
using Org.BouncyCastle.OpenSsl;

namespace Signature
{
    public partial class SignCert : Form
    {
        public SignCert()
        {
            InitializeComponent();
        }

        private void btn_urlCert_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tb_urlCert.Text = ofd.FileName;
            }
        }

        private void btn_urlKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tb_urlKey.Text = ofd.FileName;
            }
        }

        private void btn_urlSigned_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_urlSigned.Text = fbd.SelectedPath;
            }
        }
        private static AsymmetricKeyParameter GetPrivateKeyFromPem(string privateKeyFilePath)
        {
            using (StreamReader reader = File.OpenText(privateKeyFilePath))
            {
                PemReader pemReader = new PemReader(reader);
                object keyObject = pemReader.ReadObject();
                if (keyObject is AsymmetricCipherKeyPair keyPair)
                {
                    return keyPair.Private;
                }
                throw new InvalidOperationException("Invalid private key");
            }
        }

        private void btn_sign_Click(object sender, EventArgs e)
        {
            try
            {
                ///////////////////////////////////////
                string path = tb_urlCert.Text;
                string cert = "";
                string SignPath = tb_urlSigned.Text + @"\";
                string dataQR = "";

                var SourceFileStream = File.OpenRead(path);
                var outputStream = new MemoryStream();
                var pdf = new PdfDocument(new PdfReader(SourceFileStream), new PdfWriter(outputStream));

                PdfAcroForm form = PdfAcroForm.GetAcroForm(pdf, false);

                IDictionary<string, PdfFormField> fields = form.GetAllFormFields();
                PdfFormField toset;

                fields.TryGetValue("Text Box 1", out toset);
                cert += toset.GetValueAsString();
                dataQR += "Tên: " + toset.GetValueAsString();

                fields.TryGetValue("Text Box 2", out toset);
                cert += toset.GetValueAsString();
                SignPath += toset.GetValueAsString();
                dataQR += ", MSSV: " + toset.GetValueAsString();

                //chương trình
                fields.TryGetValue("Text Box 2_2", out toset);
                cert += toset.GetValueAsString();
                dataQR += ", Chương trình: " + toset.GetValueAsString();

                //ngành
                fields.TryGetValue("Text Box 2_3", out toset);
                cert += toset.GetValueAsString();
                dataQR += ", Ngành: " + toset.GetValueAsString();

                //loại
                fields.TryGetValue("Text Box 2_4", out toset);
                cert += toset.GetValueAsString();
                dataQR += ", Loại: " + toset.GetValueAsString();

                //ngày kí
                fields.TryGetValue("Text Box 3", out toset);
                cert += toset.GetValueAsString();
                dataQR += ", Kí: " + toset.GetValueAsString();

                pdf.Close();
                // Convert the cert string to a byte array for signing
                byte[] dataToSign = Encoding.UTF8.GetBytes(cert);

                /////////////////////////////////////////////                
                FalconPrivateKeyParameters privateKeyParams = LoadPrivateKey(tb_urlKey.Text, tb_password.Text);

                FalconSigner signer = new FalconSigner();
                signer.Init(true, privateKeyParams);
                byte[] sign = signer.GenerateSignature(dataToSign);
                string signature = Convert.ToBase64String(sign);

                dataQR += ", Chữ kí: " + signature;
                ///////////////////////////////////////////////////////
                // Tạo QR code
                var segments = QrSegment.MakeSegments(dataQR);
                var qrCode = QrCode.EncodeSegments(segments, QrCode.Ecc.High, 40, 40, 7, false);

                // Chuyển đổi QR code thành đối tượng Bitmap
                var bitmap = ToBitmap(qrCode, 1, 5);
                ///////////////////////////////////////////////////
                // Chèn chữ ký vào chứng chỉ PDF
                using (PdfReader reader = new PdfReader(tb_urlCert.Text))
                using (PdfWriter writer = new PdfWriter(SignPath + ".pdf"))
                using (PdfDocument document = new PdfDocument(reader, writer))
                {
                    PdfAcroForm form1 = PdfAcroForm.GetAcroForm(document, false);

                    // Set giá trị của ô chữ ký
                    PdfFormField signatureField = form1.GetField("Text Box 4");
                    signatureField.SetValue(signature);
                    signatureField.SetFontSize(1);
                    signatureField.SetColor(ColorConstants.WHITE);

                    using (var Pdf = new Document(document))
                    {
                        // Chuyển đổi đối tượng Bitmap thành đối tượng Image iText 7
                        var qrCodeImage = new iText.Layout.Element.Image(ImageDataFactory.Create(bitmap, null));

                        qrCodeImage.SetFixedPosition(40, 40);

                        // Chèn ảnh QR code vào PDF
                        Pdf.Add(qrCodeImage);
                    }
                    // Lưu tài liệu đã ký
                    document.Close();
                }
                MessageBox.Show("ĐÃ KÍ THÀNH CÔNG.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
        // Đọc và giải mã private key
        private static FalconPrivateKeyParameters LoadPrivateKey(string filePath, string password)
        {
            byte[] encryptedData;
            byte[] salt = new byte[16];
            byte[] iv = new byte[16];

            string pemString = File.ReadAllText(filePath);
            string base64String = pemString.Replace("-----BEGIN PRIVATE KEY-----", "").Replace("-----END PRIVATE KEY-----", "").Replace(Environment.NewLine, "");
            byte[] pemBytes = Convert.FromBase64String(base64String);

            using (MemoryStream memoryStream = new MemoryStream(pemBytes))
            {
                memoryStream.Read(salt, 0, salt.Length);
                memoryStream.Read(iv, 0, iv.Length);

                encryptedData = new byte[memoryStream.Length - salt.Length - iv.Length];
                memoryStream.Read(encryptedData, 0, encryptedData.Length);
            }

            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, salt, 10000);
            byte[] keyBytes = key.GetBytes(32); // 256-bit key

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = iv;

                using (MemoryStream decryptedStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(decryptedStream, aesAlg.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(encryptedData, 0, encryptedData.Length);
                        cryptoStream.FlushFinalBlock();

                        byte[] decryptedData = decryptedStream.ToArray();
                        FalconPrivateKeyParameters privateKey = new FalconPrivateKeyParameters(FalconParameters.falcon_512, decryptedData, null, null, null);

                        return privateKey;
                    }
                }
            }
        }
        private void lb_create_Click(object sender, EventArgs e)
        {
            new CreateKey().ShowDialog();
        }

        static Bitmap ToBitmap(QrCode qrCode, int moduleSize, int quietZoneModules)
        {
            int qrCodeSize = qrCode.Size;
            int imageSize = (qrCodeSize + quietZoneModules * 2) * moduleSize;
            Bitmap bitmap = new Bitmap(imageSize, imageSize);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(System.Drawing.Color.White);

                for (int y = 0; y < qrCodeSize; y++)
                {
                    for (int x = 0; x < qrCodeSize; x++)
                    {
                        bool module = qrCode.GetModule(x, y);
                        System.Drawing.Color color = module ? System.Drawing.Color.Black : System.Drawing.Color.White;

                        int moduleX = (x + quietZoneModules) * moduleSize;
                        int moduleY = (y + quietZoneModules) * moduleSize;

                        graphics.FillRectangle(new SolidBrush(color), moduleX, moduleY, moduleSize, moduleSize);
                    }
                }
            }

            return bitmap;
        }

    }
}
