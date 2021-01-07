namespace InformationSender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileInfoList = FileInfoGenerator.GenerateFileInfoList();

            var FileCreationService = new FileCreationService(fileInfoList);
            FileCreationService.CreateFilesFromFileInfo();
        }
    }
}