using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace InformationSender
{
    internal class OwnerXElement
    {
        public OwnerXElement(string owner)
        {
            Doc = new XDocument(new XElement("File"));
            Doc.Root?.Add(new XElement("Owner", owner));
            Doc.Root?.Add(new XElement("DocType", "BOF"));
        }

        private XDocument Doc { get; }

        public void AddFileElement(FileModel fileInfo)
        {
            var fileElement =
                new XElement("FileInfo",
                    new XElement("Filename", fileInfo.Filename),
                    new XElement("InvoiceNumber", fileInfo.InvoiceNumber),
                    new XElement("CustomerNumber", fileInfo.CustomerNumber),
                    new XElement("KID", fileInfo.KID),
                    new XElement("Name", fileInfo.Name),
                    new XElement("Addr1", fileInfo.Addr1),
                    new XElement("ZipCode", fileInfo.ZipCode),
                    new XElement("ZipName", fileInfo.ZipName),
                    new XElement("CountryCode", fileInfo.CountryCode),
                    new XElement("IssueDate", fileInfo.IssueDate),
                    new XElement("DueDate", fileInfo.DueDate),
                    new XElement("TotalAmount", fileInfo.TotalAmount));
            Doc.Root?.Add(fileElement);
        }

        public void WriteXmlFile(string filename, string dirPath)
        {
            try
            {
                var sw = new StringWriter();
                using (var xw = XmlWriter.Create(dirPath + "\\" + filename + ".xml"))
                {
                    Doc.Save(xw);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}