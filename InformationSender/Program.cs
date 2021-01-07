using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace InformationSender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileInfoList = FileInfoGenerator.GenerateFileInfoList();

            var FileCreationService = new FileCreationService(fileInfoList, @"E:\Test\");
            FileCreationService.CreateFilesFromFileInfo();

            SendFileToServer.Send(FileCreationService.FilesReadyToSend.ToString());
        }
    }
}