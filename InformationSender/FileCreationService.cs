using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace InformationSender
{
    class FileCreationService
    {
        public FileCreationService(DocumentModel[] fileList)
        {
            FileList = fileList;
        }

        private readonly Random Random = new Random();
        private DocumentModel[] FileList { get; set; }

        public void CreateFilesFromFileInfo()
        {
            try
            {
                var ownerList = FileList.Select(x => x.Owner).Distinct();

                foreach (var owner in ownerList)
                {
                    Directory.CreateDirectory(@"E:\Test\" + owner);

                    var doc = new XDocument(new XElement("File"));
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
                           new XElement("TotalAmount", file.TotalAmount));
                        doc.Root.Add(fileElement);
                        File.WriteAllText(@"E:\Test\" + owner + "\\" + file.Filename, "");
                    }

                    var sw = new StringWriter();
                    using (XmlWriter xw = XmlWriter.Create(@"E:\Test\" + owner + "\\" + Random.Next(999999) + ".xml"))
                    {
                        doc.Save(xw);
                    }
                    sw.Close();

                    ZipFile.CreateFromDirectory(@"E:\Test\" + owner, @"E:\Test\" + owner + ".zip");
                    Directory.Delete(@"E:\Test\" + owner, true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}