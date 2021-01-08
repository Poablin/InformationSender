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
        public FileCreationService()
        {
            FilesReadyToSend = new List<string>();
        }

        private string DirPath { get; set; }
        public List<string> FilesReadyToSend { get; }

        public void CreateFilesFromFileInfo(FileModel[] FileList, string OutputPath)
        {
            try
            {
                var ownerList = FileList.Select(x => x.Owner).Distinct();

                foreach (var owner in ownerList)
                {
                    DirPath = OutputPath + owner;
                    Directory.CreateDirectory(DirPath);

                    var ownerXElement = new OwnerXElement(owner);

                    var fileInfoToAddIntoXml = FileList.Where(x => x.Owner == owner);

                    foreach (var fileInfo in fileInfoToAddIntoXml)
                    {
                        ownerXElement.AddFileElement(fileInfo);
                        File.WriteAllText(DirPath + "\\" + fileInfo.Filename, "");
                    }

                    ownerXElement.WriteXmlFile(owner, DirPath);
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