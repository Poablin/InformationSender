using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace InformationSender
{
    class XmlCreationService
    {
        public XmlCreationService(DocumentModel model)
        {
            Model = model;
        }

        private DocumentModel Model { get; set; }

        public void CreateXml()
        {
            var rootElement =
            new XElement("File",
                new XElement("Owner", Model.Owner),
                new XElement("DocType", Model.DocType)
            );

            var fileElement =
            new XElement("FileInfo",
                new XElement("Filename", Model.Filename),
                new XElement("InvoiceNumber", Model.InvoiceNumber),
                new XElement("CustomerNumber", Model.CustomerNumber),
                new XElement("Name", Model.Name),
                new XElement("Addr1", Model.Addr1),
                new XElement("ZipCode", Model.ZipCode),
                new XElement("ZipName", Model.ZipName),
                new XElement("CountryCode", Model.CountryCode),
                new XElement("IssueDate", Model.IssueDate),
                new XElement("DueDate", Model.DueDate),
                new XElement("TotalAmount", Model.TotalAmount)
            );

            var doc = new XDocument(rootElement);
            doc.Root.Add(fileElement);

            //Kan legges til om Xml headern skal fjernes
            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.OmitXmlDeclaration = true;
            var sw = new StringWriter();
            using (XmlWriter xw = XmlWriter.Create(@"C:\Users\krist\Downloads\Test.xml"))
            {
                doc.Save(xw);
            }
            sw.Close();
        }
    }
}