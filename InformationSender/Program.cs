using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace InformationSender
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentModel model = new DocumentModel();

            var xmlTree1 = new XElement("File",
            new XElement("Owner", 1),
            new XElement("DocType", 2)
            );

            var xmlTree2 =
            new XElement("FileInfo",
                new XElement("Filename", 3),
                new XElement("InvoiceNumber", 4),
                new XElement("CustomerNumber", 5),
                new XElement("Name", 6),
                new XElement("Addr1", 7),
                new XElement("ZipCode", 8),
                new XElement("ZipName", 9),
                new XElement("CountryCode", 10),
                new XElement("IssueDate", 11),
                new XElement("DueDate", 12),
                new XElement("TotalAmount", 13)
            );

           var doc = new XDocument(xmlTree1);
            doc.Root.Add(xmlTree2);

            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.OmitXmlDeclaration = true;
            var sw = new StringWriter();
            using (XmlWriter xw = XmlWriter.Create(@"C:\Users\krist\Downloads\Test.xml"))
            {
                doc.Save(xw);
            }
        }
    }
}
