using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationSender
{
    class FileInfoGenerator
    {
        private static readonly Random random = new Random();
        public DocumentModel[] GenerateFileInfoList()
        {
            var testList = new DocumentModel[random.Next(1000, 10000)];
            for (int i = 0; i < testList.Length; i++)
            {
                var date = RandomDate();
                var testFile = new DocumentModel();
                testFile.Owner = random.Next(10001, 10003).ToString();
                testFile.DocType = "BOF";
                testFile.Filename = "2" + random.Next(0000000, 9999999).ToString() + ".pdf";
                testFile.InvoiceNumber = "1" + random.Next(000000, 99999).ToString();
                //Husk Mod10 på CustomerNumber
                testFile.CustomerNumber = $"005{testFile.InvoiceNumber}6";
                testFile.KID = "2345676";
                testFile.Name = RandomString(10);
                testFile.Addr1 = RandomString(6);
                testFile.ZipCode = random.Next(9999).ToString();
                testFile.ZipName = RandomString(9);
                testFile.CountryCode = "NO";
                testFile.IssueDate = $"{date.Day}.{date.Month}.{date.Year}";
                date = date.AddDays(30);
                testFile.DueDate = $"{date.Day}.{date.Month}.{date.Year}";
                testFile.TotalAmount = random.Next(99999);
                testFile.FileLocation = @"C:\Users\krist\Downloads\test";
                testFile.BatchID = 001;

                testList[i] = testFile;
            }

            return testList;
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static DateTime RandomDate()
        {
            DateTime start = new DateTime(1990, 1, 1);
            int range = (DateTime.Today.AddDays(-30) - start).Days;
            return start.AddDays(random.Next(range));
        }
    }
}
