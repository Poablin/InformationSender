using InformationSender.Utils;

namespace InformationSender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileInfoList = FileInfoGenerator.GenerateFileInfoList();

            var FileCreationService = new FileCreationService();
            FileCreationService.CreateFilesFromFileInfo(fileInfoList, @"E:\Test\");

            foreach (var file in FileCreationService.FilesReadyToSend)
            {
                SendFileToServer.Send(file);
            }
        }
    }
}