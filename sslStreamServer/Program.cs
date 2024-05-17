using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace SslStreamServerCS
{
    public sealed class SslTcpServer

    {
        static X509Certificate2 serverCertificate = null;

        // The certificate parameter specifies the name of the file containing the machine certificate.
        public static void RunServer(string certificate, string key)
        {
            X509Certificate sCertificate = X509Certificate.CreateFromCertFile(certificate);
            serverCertificate = new X509Certificate2(sCertificate);

            // Create a TCP/IP (IPv4) socket and listen for incoming connections.
            TcpListener listener = new TcpListener(IPAddress.Any, 8000);
            listener.Start();

            while (true)
            {
                Console.WriteLine("I'm {0} at 8000...", IPAddress.Any); 
                Console.WriteLine("Waiting for a client to connect...");

                // Application blocks while waiting for an incoming connection. Press CNTL-C to terminate the server.
                TcpClient client = listener.AcceptTcpClient();
                ProcessClient(client);
            }
        }

        static void ProcessClient(TcpClient client)
        {
            // A client has connected. Create the SslStream using the client's network stream.
            SslStream sslStream = new SslStream(client.GetStream(), false);

            // Authenticate the server but don't require the client to authenticate.
            try
            {
                sslStream.AuthenticateAsServer(serverCertificate, false, SslProtocols.Tls, true);

                // Display the properties and settings for the authenticated stream.
                DisplaySecurityLevel(sslStream);
                DisplaySecurityServices(sslStream);
                DisplayCertificateInformation(sslStream);
                DisplayStreamProperties(sslStream);

                // Set timeouts for the read and write to 5 seconds.
                sslStream.ReadTimeout = 5000;
                sslStream.WriteTimeout = 5000;

                //Receive a message from client
                //Console.WriteLine("Waiting for client message...");
                //string messageData = ReceiveMessage(sslStream);
                //Console.WriteLine("Received: {0}", messageData);

                // Send a message to client.
                Console.WriteLine("Sending message to client...");
                string messageData = SendMessage(sslStream);
                Console.WriteLine("Send: {0}", messageData);

                //Create pdf from bytes
                //byte[] buffer = File.ReadAllBytes(@"D:\\ConsoleApp1\\message.txt");
                //System.IO.File.WriteAllBytes("hello.pdf", buffer);
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                if (e.InnerException != null) 
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message); 
                Console.WriteLine("Authentication failed - closing the connection.");
                sslStream.Close();
                client.Close();
                return;
            }
            finally
            {
                // The client stream will be closed with the sslStream because we specified this behavior when creating the sslStream.
                sslStream.Close();
                client.Close();
            }
        }

        static string SendMessage(SslStream sslStream)
        {
            byte[] buffer = File.ReadAllBytes(@"D:\\sslStreamServer\\public_key.pem");

            // Read the client's test message.
            sslStream.Flush();
            sslStream.Write(buffer, 0, buffer.Length);

            return Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        }

        static string ReceiveMessage(SslStream sslStream)
        {
            byte[] buffer = new byte[2048];
            //StringBuilder messageData = new StringBuilder();
            int bytes = -1;
           
            sslStream.Flush();
            bytes = sslStream.Read(buffer, 0, buffer.Length);

            string response = Encoding.UTF8.GetString(buffer, 0, bytes);
            if (response.IndexOf("<EOF>") != -1)
                Console.WriteLine("\n\nReceived!\n\n");
            return response;
        }

        static void DisplaySecurityLevel(SslStream stream)
        {
            Console.WriteLine("Cipher: {0} strength {1}", stream.CipherAlgorithm, stream.CipherStrength);
            Console.WriteLine("Hash: {0} strength {1}", stream.HashAlgorithm, stream.HashStrength);
            Console.WriteLine("Key exchange: {0} strength {1}", stream.KeyExchangeAlgorithm, stream.KeyExchangeStrength);
            Console.WriteLine("Protocol: {0}", stream.SslProtocol);
        }

        static void DisplaySecurityServices(SslStream stream)
        {
            Console.WriteLine("Is authenticated: {0} as server? {1}", stream.IsAuthenticated, stream.IsServer);
            Console.WriteLine("IsSigned: {0}", stream.IsSigned);
            Console.WriteLine("Is Encrypted: {0}", stream.IsEncrypted);
        }

        static void DisplayStreamProperties(SslStream stream)
        {
            Console.WriteLine("Can read: {0}, write {1}", stream.CanRead, stream.CanWrite);
            Console.WriteLine("Can timeout: {0}", stream.CanTimeout);
        }

        static void DisplayCertificateInformation(SslStream stream)
        {
            Console.WriteLine("Certificate revocation list checked: {0}", stream.CheckCertRevocationStatus);
            X509Certificate localCertificate = stream.LocalCertificate;
            if (stream.LocalCertificate != null)
            {
                Console.WriteLine("Local cert was issued to {0} and is valid from {1} until {2}.",
                    localCertificate.Subject,   
                    localCertificate.GetEffectiveDateString(),
                    localCertificate.GetExpirationDateString());
            }
            else Console.WriteLine("Local certificate is null.");

            // Display the properties of the client's certificate.
            X509Certificate remoteCertificate = stream.RemoteCertificate;
            if (stream.RemoteCertificate != null)
            {
                Console.WriteLine("Remote cert was issued to {0} and is valid from {1} until {2}.",
                    remoteCertificate.Subject,
                    remoteCertificate.GetEffectiveDateString(),
                    remoteCertificate.GetExpirationDateString());
            }
            else Console.WriteLine("Remote certificate is null."); 
        }

        private static void DisplayUsage()
        {
            Console.WriteLine("To start the server specify:");
            Console.WriteLine("executable_name certificateFile.cer");
            Environment.Exit(1);
        }

        public static int Main()
        {
            string certificate = "D:\\sslStreamServer\\nguyenhoangtuanh.id.vn.pfx";
            string key = "D:\\sslStreamServer\\ec-private-key.pem";
            RunServer(certificate, key);
            return 0;
        }
    }
}