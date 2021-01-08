﻿using System;
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
                var fileInfo = new FileModel();
                fileInfo.Owner = Random.Next(10001, 10003).ToString();
                fileInfo.DocType = "BOF";
                fileInfo.Filename = "2" + Random.Next(0000000, 9999999) + ".pdf";
                fileInfo.InvoiceNumber = "1" + Random.Next(000000, 999999);
                fileInfo.CustomerNumber = "000001";

                var mod10 = Mod10($"005{fileInfo.InvoiceNumber}");
                fileInfo.KID = $"005{fileInfo.InvoiceNumber}{mod10}";

                fileInfo.Name = RandomString(10);
                fileInfo.Addr1 = RandomString(6);
                fileInfo.ZipCode = Random.Next(0000, 9999).ToString();
                fileInfo.ZipName = RandomString(9);
                fileInfo.CountryCode = "NO";
                fileInfo.TotalAmount = Random.Next(00000, 99999);
                fileInfo.FileLocation = @"E:\Test\";
                fileInfo.BatchID = 001;

                var date = RandomDate();
                fileInfo.DueDate = date.ToString("dd.MM.yyyy");
                date = date.AddDays(-30);
                fileInfo.IssueDate = date.ToString("dd.MM.yyyy");

                if (!FileInfoFormatValidator.IsValid(fileInfo))
                {
                    Console.WriteLine($"Generated fileInfo not valid - Continuing");
                    i--;
                    continue;
                }

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
            var start = new DateTime(1990, 01, 01);
            var range = (DateTime.Today - start).Days;

            return start.AddDays(Random.Next(range));
        }

        private static int Mod10(string kid)
        {
            bool isOne = false;
            int controlNumber = 0;
            foreach (char number in kid.Reverse())
            {
                var intNumber = int.Parse(number.ToString());
                var sum = isOne ? intNumber : 2 * intNumber;
                if (sum > 9)
                {
                    sum = (sum % 10) + 1;
                }
                isOne = !isOne;
                controlNumber += sum;
            }
            return (10 - (controlNumber % 10)) % 10 == 0 ? 0 : 10 - (controlNumber % 10);
        }
    }
}