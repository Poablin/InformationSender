using InformationSender.Utils;

namespace InformationSender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileInfoList = FileInfoGenerator.CreateFileInfoList();

            var FileCreationService = new FileCreationService();
            FileCreationService.CreateFiles(fileInfoList, @"Output path here");

            foreach (var file in FileCreationService.FilesReadyToSend)
            {
                SendFileToServer.Send(file);
            }
        }
    }
}