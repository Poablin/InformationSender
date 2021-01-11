namespace InformationSender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileInfoGenerator = new FileInfoGenerator();
            var fileInfoList = fileInfoGenerator.CreateFileInfoList();

            var FileCreationService = new FileCreationService();
            FileCreationService.CreateFiles(fileInfoList, @"Output path here");

            foreach (var file in FileCreationService.FilesReadyToSend)
            {
                FileSendingService.Send(file);
            }
        }
    }
}