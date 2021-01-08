﻿using System;

namespace InformationSender.Utils
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

                fileInfo.CreateFromRandomValues();

                if (!FileInfoValidator.IsValid(fileInfo)) continue;

                fileInfoList[count] = fileInfo;
                count++;
            }

            return fileInfoList;
        }
    }
}