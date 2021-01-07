using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace InformationSender
{
    internal class FileCreationService
    {
        private const string OutputPath = @"E:\Test\";

        private readonly Random _random = new Random();

        public FileCreationService(FileModel[] fileList)
        {
            FileList = fileList;
        }

        private FileModel[] FileList { get; }

        public void CreateFilesFromFileInfo()
        {
            try
            {
                var ownerList = FileList.Select(x => x.Owner).Distinct();

                foreach (var owner in ownerList)
                {
                    Directory.CreateDirectory(OutputPath + owner);

                    var doc = new XDocument(new XElement("File"));
                    doc.Root?.Add(new XElement("Owner", owner));
                    doc.Root?.Add(new XElement("DocType", "BOF"));

                    var fileInfoToAddIntoXml = FileList.Where(x => x.Owner == owner);

                    foreach (var fileInfo in fileInfoToAddIntoXml)
                    {
                        var fileElement =
                            new XElement("FileInfo",
                                new XElement("Filename", fileInfo.Filename),
                                new XElement("InvoiceNumber", fileInfo.InvoiceNumber),
                                new XElement("CustomerNumber", fileInfo.CustomerNumber),
                                new XElement("Name", fileInfo.Name),
                                new XElement("Addr1", fileInfo.Addr1),
                                new XElement("ZipCode", fileInfo.ZipCode),
                                new XElement("ZipName", fileInfo.ZipName),
                                new XElement("CountryCode", fileInfo.CountryCode),
                                new XElement("IssueDate", fileInfo.IssueDate),
                                new XElement("DueDate", fileInfo.DueDate),
                                new XElement("TotalAmount", fileInfo.TotalAmount));
                        doc.Root?.Add(fileElement);
                        File.WriteAllText(OutputPath + owner + "\\" + fileInfo.Filename, "");
                    }

                    WriteXmlFile(owner, doc);
                    CreateZipFile(owner);
                    Directory.Delete(OutputPath + owner, true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void WriteXmlFile(string owner, XDocument doc)
        {
            try
            {
                var sw = new StringWriter();
                using (var xw = XmlWriter.Create(OutputPath + owner + "\\" + _random.Next(999999) + ".xml"))
                {
                    doc.Save(xw);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void CreateZipFile(string owner)
        {
            try
            {
                ZipFile.CreateFromDirectory(OutputPath + owner, OutputPath + owner + ".zip");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}