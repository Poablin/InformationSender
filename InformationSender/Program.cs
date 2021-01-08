using InformationSender.Utils;

namespace InformationSender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileInfoList = FileInfoGenerator.CreateFileInfoList();

            var FileCreationService = new FileCreationService();
            FileCreationService.CreateFiles(fileInfoList, @"D:\");

            foreach (var file in FileCreationService.FilesReadyToSend)
            {
                SendFileToServer.Send(file);
            }
        }
    }
}