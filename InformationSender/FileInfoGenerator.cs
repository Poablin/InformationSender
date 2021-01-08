﻿using InformationSender.Utils;
using System;
using System.Linq;

namespace InformationSender
{
    internal static class FileInfoGenerator
    {
        public static FileModel[] GenerateFileInfoList()
        {
            var fileInfoList = new FileModel[Randomisation.RandomNumber(1000, 10000)];

            var count = 0;
            while (count < fileInfoList.Length)
            {
                var fileInfo = new FileModel();

                if (!FileInfoFormatValidator.IsValid(fileInfo))
                {
                    Console.WriteLine($"Generated fileInfo not valid - Continuing");
                    continue;
                }

                fileInfoList[count] = fileInfo;
                count++;
            }

            return fileInfoList;
        }
    }
}