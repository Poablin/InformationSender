using Renci.SshNet;
using System;

namespace InformationSender
{
    public static class SendFileToServer
    {
        // Enter your host name or IP here
        private static string host = "127.0.0.1";
        // Enter your sftp username here
        private static string username = "sftp";
        // Enter your sftp password here
        private static string password = "12345";
        public static int Send(string fileName)
        {
            try
            {
                var connectionInfo = new ConnectionInfo(host, 22, "sftp", new PasswordAuthenticationMethod(username, password));
                // Upload File
                using (var sftp = new SftpClient(connectionInfo))
                {

                    sftp.Connect();
                    //sftp.ChangeDirectory("/MyFolder");
                    using (var uplfileStream = System.IO.File.OpenRead(fileName))
                    {
                        sftp.UploadFile(uplfileStream, fileName, true);
                    }
                    sftp.Disconnect();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }
    }
}