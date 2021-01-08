namespace InformationSender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileInfoList = FileInfoGenerator.GenerateFileInfoList();

            var FileCreationService = new FileCreationService(fileInfoList, @"E:\Test\");
            FileCreationService.CreateFilesFromFileInfo();

            foreach (var file in FileCreationService.FilesReadyToSend)
            {
                SendFileToServer.Send(file);
            }
        }
    }
}