using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace InformationSender
{
    class XmlCreationService
    {
        public XmlCreationService(DocumentModel[] fileList)
        {
            OwnerList = new List<string>();
            FileList = fileList;
        }
        private List<string> OwnerList { get; set; }
        private DocumentModel[] FileList { get; set; }

        public void CreateXml()
        {
            var random = new Random();

            foreach (var file in FileList)
            {
                if (!OwnerList.Contains(file.Owner))
                {
                    OwnerList.Add(file.Owner);
                }
            }

            var doc = new XDocument(new XElement("File"));
            foreach (var owner in OwnerList)
            {
                doc.Root.Add(new XElement("Owner", owner));
                doc.Root.Add(new XElement("DocType", "BOF"));

                var filesToAddIntoXml = FileList.Where(x => x.Owner == owner);

                foreach (var file in filesToAddIntoXml)
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
                using (XmlWriter xw = XmlWriter.Create(@"E:\Test\" + random.Next(999999) + ".xml"))
                {
                    doc.Save(xw);
                }
                sw.Close();
            }
        }
    }
}