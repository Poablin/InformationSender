namespace InformationSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new DocumentModel();
            var creationService = new XmlCreationService(model);
            creationService.CreateXml();
        }
    }
}
