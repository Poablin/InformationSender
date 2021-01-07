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
            var model = new DocumentModel();

            var rootElement = new XElement("File",
            new XElement("Owner", model.Owner),
            new XElement("DocType", model.DocType)
            );

            var fileElement =
            new XElement("FileInfo",
                new XElement("Filename", model.Filename),
                new XElement("InvoiceNumber", model.InvoiceNumber),
                new XElement("CustomerNumber", model.CustomerNumber),
                new XElement("Name", model.Name),
                new XElement("Addr1", model.Addr1),
                new XElement("ZipCode", model.ZipCode),
                new XElement("ZipName", model.ZipName),
                new XElement("CountryCode", model.CountryCode),
                new XElement("IssueDate", model.IssueDate),
                new XElement("DueDate", model.DueDate),
                new XElement("TotalAmount", model.TotalAmount)
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






//var xmlTree1 = new XElement("File",
//new XElement("Owner", 1),
//new XElement("DocType", 2)
//);

//var xmlTree2 =
//new XElement("FileInfo",
//    new XElement("Filename", 3),
//    new XElement("InvoiceNumber", 4),
//    new XElement("CustomerNumber", 5),
//    new XElement("Name", 6),
//    new XElement("Addr1", 7),
//    new XElement("ZipCode", 8),
//    new XElement("ZipName", 9),
//    new XElement("CountryCode", 10),
//    new XElement("IssueDate", 11),
//    new XElement("DueDate", 12),
//    new XElement("TotalAmount", 13)
//);
