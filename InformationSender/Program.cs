using System;
using System.Linq;

namespace InformationSender
{
    class Program
    {

        static void Main(string[] args)
        {
            var fileInfoGenerator = new FileInfoGenerator();
            var fileInfoList = fileInfoGenerator.GenerateFileInfoList();

            var XmlcreationService = new XmlCreationService(fileInfoList);
            XmlcreationService.CreateXmlFilesFromFileInfo();
        }


    }
}