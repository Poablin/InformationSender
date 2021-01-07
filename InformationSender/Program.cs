using System;
using System.Collections.Generic;

namespace InformationSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new DocumentModel();
            var fileList = new DocumentModel[1];
            fileList[0] = model;


            var testList = new DocumentModel[1000];
            for (int i = 0; i < 1000; i++)
            {
                var randomNum = new Random();
                var testFile = new DocumentModel();
                testFile.Filename = "2" + randomNum.Next(0000000, 9999999).ToString() + ".pdf";
                testFile.InvoiceNumber = "1" + randomNum.Next(000000, 99999).ToString();
                testFile.CustomerNumber = "000001";
                testList[i] = testFile;
            }

            var creationService = new XmlCreationService("10002", fileList);
            creationService.CreateXml();
        }
    }
}