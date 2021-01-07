namespace InformationSender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileInfoGenerator = new FileInfoGenerator();
            var fileInfoList = fileInfoGenerator.GenerateFileInfoList();

            var FileCreationService = new FileCreationService(fileInfoList);
            FileCreationService.CreateFilesFromFileInfo();
        }
    }
}