namespace InformationSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new DocumentModel();
            var fileList = new DocumentModel[1];
            fileList[0] = model;

            var creationService = new XmlCreationService("10002", fileList);
            creationService.CreateXml();
        }
    }
}