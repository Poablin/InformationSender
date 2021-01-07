using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace InformationSender
{
    class XmlCreationService
    {
        public XmlCreationService(DocumentModel[] fileList)
        {
            FileList = fileList;
        }
        private DocumentModel[] FileList { get; set; }

        public void CreateXml()
        {
            foreach (var file in FileList)
            {
                var rootElement =
                new XElement("File",
                    new XElement("Owner", file.Owner),
                    new XElement("DocType", "BOF/inkassodokument")
                );

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
                using (XmlWriter xw = XmlWriter.Create(@"C:\Users\krist\Downloads\test\" + file.Filename))
                {
                    doc.Save(xw);
                }
                sw.Close();
            }
        }
    }
}