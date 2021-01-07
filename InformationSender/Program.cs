namespace InformationSender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileInfoGenerator = new FileInfoGenerator();
            var fileInfoList = fileInfoGenerator.GenerateFileInfoList();

            var XmlcreationService = new FileCreationService(fileInfoList);
            XmlcreationService.CreateFilesFromFileInfo();
        }
    }
}