using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using Org.BouncyCastle.Pqc.Crypto.Falcon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;


namespace SignatureVerification
{
    public partial class VerifyCert : Form
    {
        public VerifyCert()
        {
            InitializeComponent();
        }

        private void btn_urlSigned_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tb_urlSigned.Text = ofd.FileName;
            }
        }

        private void btn_verify_Click(object sender, EventArgs e)
        {
            try
            {
                ////////////////////////////////////////////
                string path = tb_urlSigned.Text;
                string cert = "";
                string signature = "";

                var SourceFileStream = File.OpenRead(path);
                var outputStream = new MemoryStream();
                var pdf = new PdfDocument(new PdfReader(SourceFileStream), new PdfWriter(outputStream));

                PdfAcroForm form = PdfAcroForm.GetAcroForm(pdf, false);

                IDictionary<string, PdfFormField> fields = form.GetAllFormFields();
                PdfFormField toset;

                fields.TryGetValue("Text Box 1", out toset);
                cert += toset.GetValueAsString();

                fields.TryGetValue("Text Box 2", out toset);
                cert += toset.GetValueAsString();

                fields.TryGetValue("Text Box 2_2", out toset);
                cert += toset.GetValueAsString();

                fields.TryGetValue("Text Box 2_3", out toset);
                cert += toset.GetValueAsString();

                fields.TryGetValue("Text Box 2_4", out toset);
                cert += toset.GetValueAsString();

                fields.TryGetValue("Text Box 3", out toset);
                cert += toset.GetValueAsString();
               
                fields.TryGetValue("Text Box 4", out toset);
                signature += toset.GetValueAsString();

                // Convert the cert string to a byte array for verify
                byte[] dataToVerify = Encoding.UTF8.GetBytes(cert);

                /////////////////////////////////////////////
                FalconPublicKeyParameters publicKeyParams = GetPublicKeyFromServer();

                FalconSigner signer = new FalconSigner();
                signer.Init(false, publicKeyParams);

                //////////////////////////////////////////////            
                // Decode the base64 string to get the byte array
                byte[] signatureBytes = Convert.FromBase64String(signature);

                //////////////////////////////////////////////
                bool result = signer.VerifySignature(dataToVerify, signatureBytes);
                if (result)
                    MessageBox.Show("ĐÃ XÁC THỰC THÀNH CÔNG.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("XÁC THỰC THẤT BẠI.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private static FalconPublicKeyParameters GetPublicKeyFromServer()
        {
            TcpClient client = new TcpClient();

            /*//Server Local
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 8000);
            client.Connect(iPEndPoint);*/

            //Server Internet
            client.Connect("0.tcp.ap.ngrok.io", 12929);
            SslStream sslStream = new SslStream(client.GetStream(), false);
            sslStream.AuthenticateAsClient("nguyenhoangtuanh.id.vn");
            sslStream.ReadTimeout = 5000;
            sslStream.WriteTimeout = 5000;
            //Console.WriteLine("Waiting for client message...");
            string messageData = ReceiveMessage(sslStream);
            //Console.WriteLine("Received: {0}", messageData);
            string base64String = messageData.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "").Replace(Environment.NewLine, "");
            byte[] pemBytes = Convert.FromBase64String(base64String);
            FalconPublicKeyParameters publicKeyParams = new FalconPublicKeyParameters(FalconParameters.falcon_512, pemBytes);
            return publicKeyParams;
        }

        static string ReceiveMessage(SslStream sslStream)
        {
            byte[] buffer = new byte[32768];
            MemoryStream memoryStream = new MemoryStream();

            int bytesRead;
            do
            {
                bytesRead = sslStream.Read(buffer, 0, buffer.Length);
                memoryStream.Write(buffer, 0, bytesRead);
            } while (bytesRead > 0);

            byte[] receivedBytes = memoryStream.ToArray();
            string response = Encoding.UTF8.GetString(receivedBytes);
            return response;
        }
    }
}
