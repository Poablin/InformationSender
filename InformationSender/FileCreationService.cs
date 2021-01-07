using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace InformationSender
{
    internal class FileCreationService
    {
        private readonly Random _random = new Random();

        public FileCreationService(FileModel[] fileList, string outputPath)
        {
            OutputPath = outputPath;
            FileList = fileList;
            FilesReadyToSend = new List<string>();
        }

        private string OutputPath { get; }
        private string DirPath { get; set; }
        public List<string> FilesReadyToSend { get; }
        private FileModel[] FileList { get; }

        public void CreateFilesFromFileInfo()
        {
            try
            {
                var ownerList = FileList.Select(x => x.Owner).Distinct();

                foreach (var owner in ownerList)
                {
                    DirPath = OutputPath + owner;
                    Directory.CreateDirectory(DirPath);

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
                                new XElement("KID", fileInfo.KID),
                                new XElement("Name", fileInfo.Name),
                                new XElement("Addr1", fileInfo.Addr1),
                                new XElement("ZipCode", fileInfo.ZipCode),
                                new XElement("ZipName", fileInfo.ZipName),
                                new XElement("CountryCode", fileInfo.CountryCode),
                                new XElement("IssueDate", fileInfo.IssueDate),
                                new XElement("DueDate", fileInfo.DueDate),
                                new XElement("TotalAmount", fileInfo.TotalAmount));
                        doc.Root?.Add(fileElement);
                        File.WriteAllText(DirPath + "\\" + fileInfo.Filename, "");
                    }

                    WriteXmlFile(doc);
                    CreateZipFile();
                    FilesReadyToSend.Add(DirPath + ".zip");
                    Directory.Delete(DirPath, true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void WriteXmlFile(XDocument doc)
        {
            try
            {
                var sw = new StringWriter();
                using (var xw = XmlWriter.Create(DirPath + "\\" + _random.Next(999999) + ".xml"))
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

        private void CreateZipFile()
        {
            try
            {
                ZipFile.CreateFromDirectory(DirPath, DirPath + ".zip");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}