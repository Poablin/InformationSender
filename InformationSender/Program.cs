using System;
using System.Collections.Generic;
using System.Linq;

namespace InformationSender
{
    class Program
    {
        private static readonly Random random = new Random();
        static void Main(string[] args)
        {
            var model = new DocumentModel();
            var fileList = new DocumentModel[1];
            fileList[0] = model;


            var testList = new DocumentModel[random.Next(1000, 10000)];
            for (int i = 0; i < testList.Length; i++)
            {
                var testFile = new DocumentModel();
                testFile.Owner = random.Next(10001, 10002).ToString();
                testFile.Filename = "2" + random.Next(0000000, 9999999).ToString() + ".pdf";
                testFile.InvoiceNumber = "1" + random.Next(000000, 99999).ToString();
                //Husk Mod10 på CustomerNumber
                testFile.CustomerNumber = $"005{testFile.InvoiceNumber}6";
                testFile.KID = "2345676";
                testFile.Name = RandomString(10);
                testFile.Addr1 = RandomString(6);
                testFile.ZipCode = random.Next(9999).ToString();
                testFile.ZipName = RandomString(9);

                testList[i] = testFile;
            }

            var creationService = new XmlCreationService(fileList);
            creationService.CreateXml();
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}