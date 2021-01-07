using System;
using System.Linq;

namespace InformationSender
{
    internal static class FileInfoGenerator
    {
        private static readonly Random Random = new Random();

        public static FileModel[] GenerateFileInfoList()
        {
            var fileInfoList = new FileModel[Random.Next(1000, 10000)];
            for (var i = 0; i < fileInfoList.Length; i++)
            {
                var date = RandomDate();
                var fileInfo = new FileModel();
                fileInfo.Owner = Random.Next(10001, 10003).ToString();
                fileInfo.DocType = "BOF";
                fileInfo.Filename = "2" + Random.Next(0000000, 9999999) + ".pdf";
                fileInfo.InvoiceNumber = "1" + Random.Next(00000, 99999);
                fileInfo.CustomerNumber = "000001";
                //Husk Mod10 på KID
                fileInfo.KID = $"005{fileInfo.InvoiceNumber}6";
                fileInfo.Name = RandomString(10);
                fileInfo.Addr1 = RandomString(6);
                fileInfo.ZipCode = Random.Next(0000, 9999).ToString();
                fileInfo.ZipName = RandomString(9);
                fileInfo.CountryCode = "NO";
                fileInfo.IssueDate = $"{date.Day}.{date.Month}.{date.Year}";
                date = date.AddDays(30);
                fileInfo.DueDate = $"{date.Day}.{date.Month}.{date.Year}";
                fileInfo.TotalAmount = Random.Next(00000, 99999);
                fileInfo.FileLocation = @"E:\Test\";
                fileInfo.BatchID = 001;

                //if (!FileInfoFormatValidator.IsValidFormat(fileInfo)) continue;

                fileInfoList[i] = fileInfo;
            }

            return fileInfoList;
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        private static DateTime RandomDate()
        {
            var start = new DateTime(1990, 1, 1);
            var range = (DateTime.Today.AddDays(-30) - start).Days;
            return start.AddDays(Random.Next(range));
        }
    }
}