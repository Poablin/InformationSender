namespace InformationSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new DocumentModel();
            var modelList = new DocumentModel[1];
            modelList[0] = model;

            var creationService = new XmlCreationService(modelList);
            creationService.CreateXml();
        }
    }
}
