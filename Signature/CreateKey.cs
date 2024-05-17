using System;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Pqc.Crypto.Falcon;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Utilities.Encoders;
using System.Security.Cryptography;

namespace Signature
{
    public partial class CreateKey : Form
    {
        public CreateKey()
        {
            InitializeComponent();
        }

        private void btn_createKey_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_password.Text != "")
                {
                    // Tạo khóa
                    SecureRandom random = new SecureRandom();
                    FalconKeyPairGenerator key = new FalconKeyPairGenerator();
                    key.Init(new FalconKeyGenerationParameters(random, FalconParameters.falcon_512));
                    AsymmetricCipherKeyPair keyPair = key.GenerateKeyPair();
                    var privateKey = keyPair.Private as FalconPrivateKeyParameters;
                    var publicKey = keyPair.Public as FalconPublicKeyParameters;

                    // Lưu private key vào file
                    SavePrivateKey(privateKey, tb_urlPrKey.Text, tb_password.Text);
                    MessageBox.Show("ĐÃ TẠO THÀNH CÔNG PRIVATE KEY.", "Seccessfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Lưu public key vào file
                    SavePublicKey(publicKey, tb_urlPuKey.Text);
                    MessageBox.Show("ĐÃ TẠO THÀNH CÔNG PUBLIC KEY.", "Seccessfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Password cannot be left blank!");                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        // Mã hóa và lưu trữ private key
        private static void SavePrivateKey(FalconPrivateKeyParameters privateKey, string filePath, string password)
        {
            byte[] privateKeyBytes = privateKey.GetEncoded();

            // Tạo khóa bí mật từ mật khẩu
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, salt, 10000);
            byte[] keyBytes = key.GetBytes(32); // 256-bit key AES

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.GenerateIV();
                byte[] iv = aesAlg.IV;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    memoryStream.Write(salt, 0, salt.Length);
                    memoryStream.Write(iv, 0, iv.Length);

                    //Ghi cipher của key Falcon
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(privateKeyBytes, 0, privateKeyBytes.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    byte[] pemBytes = memoryStream.ToArray();
                    string base64String = Convert.ToBase64String(pemBytes);
                    string pemString = "-----BEGIN PRIVATE KEY-----" + Environment.NewLine + base64String + Environment.NewLine + "-----END PRIVATE KEY-----";
                    File.WriteAllText(filePath, pemString);
                }
            }
        }        

        private static void SavePublicKey(FalconPublicKeyParameters publicKey, string filePath)
        {
            byte[] pemBytes = publicKey.GetEncoded();
            string base64String = Convert.ToBase64String(pemBytes);
            string pemString = "-----BEGIN PUBLIC KEY-----" + Environment.NewLine + base64String + Environment.NewLine + "-----END PUBLIC KEY-----";
            File.WriteAllText(filePath, pemString);
        }

        private void btn_urlSigned_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tb_urlPrKey.Text = folderBrowserDialog.SelectedPath + "\\private_key.pem";
                tb_urlPuKey.Text = folderBrowserDialog.SelectedPath + "\\public_key.pem";
            }
        }
    }
}
