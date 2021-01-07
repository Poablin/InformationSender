using System;
using System.Linq;

namespace InformationSender
{
    class FileInfoGenerator
    {
        private static readonly Random random = new Random();
        public FileModel[] GenerateFileInfoList()
        {
            var fileInfoList = new FileModel[random.Next(1000, 10000)];
            for (int i = 0; i < fileInfoList.Length; i++)
            {
                var date = RandomDate();
                var fileInfo = new FileModel();
                fileInfo.Owner = random.Next(10001, 10002).ToString();
                fileInfo.DocType = "BOF";
                fileInfo.Filename = "2" + random.Next(0000000, 9999999).ToString() + ".pdf";
                fileInfo.InvoiceNumber = "1" + random.Next(000000, 99999).ToString();
                //Husk Mod10 på CustomerNumber
                fileInfo.CustomerNumber = $"005{fileInfo.InvoiceNumber}6";
                fileInfo.KID = "2345676";
                fileInfo.Name = RandomString(10);
                fileInfo.Addr1 = RandomString(6);
                fileInfo.ZipCode = random.Next(0000, 9999).ToString();
                fileInfo.ZipName = RandomString(9);
                fileInfo.CountryCode = "NO";
                fileInfo.IssueDate = $"{date.Day}.{date.Month}.{date.Year}";
                date = date.AddDays(30);
                fileInfo.DueDate = $"{date.Day}.{date.Month}.{date.Year}";
                fileInfo.TotalAmount = random.Next(00000, 99999);
                fileInfo.FileLocation = @"E:\Test\";
                fileInfo.BatchID = 001;

                fileInfoList[i] = fileInfo;
            }

            return fileInfoList;
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
