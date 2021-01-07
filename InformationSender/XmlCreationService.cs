using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace InformationSender
{
    class XmlCreationService
    {
        public XmlCreationService(string owner, string docType, DocumentModel[] fileList)
        {
            Owner = owner;
            DocType = docType;
            FileList = fileList;
        }

        private string Owner { get; set; }
        private string DocType { get; set; }
        private DocumentModel[] FileList { get; set; }

        public void CreateXml()
        {
            var random = new Random();
            var rootElement =
            new XElement("File",
                new XElement("Owner", Owner),
                new XElement("DocType", DocType)
);
            var doc = new XDocument(rootElement);
            foreach (var file in FileList)
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
                doc.Root.Add(fileElement);
            }

            var sw = new StringWriter();
            using (XmlWriter xw = XmlWriter.Create(@"E:\Test\" + random.Next(999999)))
            {
                doc.Save(xw);
            }
            sw.Close();
        }
    }
}