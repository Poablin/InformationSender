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

                var ownerList = FileList.GroupBy(x => x.Owner);

                foreach (var owner in ownerList)
                {
                    DirPath = Path.Combine(OutputPath, owner.Key);
                    if (Directory.Exists(DirPath)) continue;

                    Directory.CreateDirectory(DirPath);
                    var ownerXElement = new OwnerXElement(owner.Key);

                    var fileInfoToAddIntoXml = FileList.Where(x => x.Owner == owner.Key);

                    foreach (var fileInfo in fileInfoToAddIntoXml)
                    {
                        ownerXElement.AddFileElement(fileInfo);
                        CreateDummyPdf(fileInfo.Filename);
                    }

                    ownerXElement.WriteXmlFile(owner.Key, DirPath);
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
                File.WriteAllText(Path.Combine(DirPath, fileName), "");
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