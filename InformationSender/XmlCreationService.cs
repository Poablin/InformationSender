using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace InformationSender
{
    class XmlCreationService
    {
        public XmlCreationService(string owner, DocumentModel[] model)
        {
            Owner = owner;
            Model = model;
        }
        private string Owner { get; set; }
        private DocumentModel[] Model { get; set; }

        public void CreateXml()
        {
            var rootElement =
            new XElement("File",
                new XElement("Owner", Owner),
                new XElement("DocType", "BOF/inkassodokument")
            );

            foreach (var file in Model)
            {
                var fileElement =
                new XElement("FileInfo",
                   new XElement("Filename", file.Filename),
                   new XElement("InvoiceNumber", file.InvoiceNumber),
                   new XElement("CustomerNumber", file.CustomerNumber),
                   new XElement("Name", file.Name),
                   new XElement("Addr1", file.Addr1),
                   new XElement("ZipCode", file.ZipCode),
                   new XElement("ZipName", file.ZipName),
                   new XElement("CountryCode", file.CountryCode),
                   new XElement("IssueDate", file.IssueDate),
                   new XElement("DueDate", file.DueDate),
                   new XElement("TotalAmount", file.TotalAmount)
                );
                var doc = new XDocument(rootElement);
                doc.Root.Add(fileElement);

                var sw = new StringWriter();
                using (XmlWriter xw = XmlWriter.Create(@"C:\Users\krist\Downloads\Test.xml"))
                {
                    doc.Save(xw);
                }
                sw.Close();
            }
        }
    }
}