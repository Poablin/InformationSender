using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace InformationSender
{
    internal class FileCreationService
    {
        public FileCreationService()
        {
            FilesReadyToSend = new List<string>();
        }

        private string DirPath { get; set; }
        public List<string> FilesReadyToSend { get; }

        public void CreateFiles(List<FileModel> FileList, string OutputPath)
        {
            try
            {
                if (!Directory.Exists(OutputPath)) return;

                var ownerList = FileList.Select(x => x.Owner)
                    .Distinct();

                foreach (var owner in ownerList)
                {
                    DirPath = Path.Combine(OutputPath, owner);
                    if (Directory.Exists(DirPath)) continue;

                    Directory.CreateDirectory(DirPath);
                    var ownerXElement = new OwnerXElement(owner);

                    var fileInfoToAddIntoXml = FileList.Where(x => x.Owner == owner);

                    foreach (var fileInfo in fileInfoToAddIntoXml)
                    {
                        ownerXElement.AddFileElement(fileInfo);
                        CreateDummyPdf(fileInfo.Filename);
                    }

                    ownerXElement.WriteXmlFile(owner, DirPath);
                    CreateZipFile();
                    FilesReadyToSend.Add($"{DirPath}.zip");
                    Directory.Delete(DirPath, true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void CreateDummyPdf(string fileName)
        {
            try
            {
                File.WriteAllText($"{DirPath}\\{fileName}", "");
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
                ZipFile.CreateFromDirectory(DirPath, $"{DirPath}.zip");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}