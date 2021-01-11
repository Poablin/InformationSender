using InformationSender.Utilities;
using System.Collections.Generic;

namespace InformationSender
{
    internal class FileInfoGenerator
    {
        public List<FileModel> CreateFileInfoList()
        {
            var fileInfoList = new List<FileModel>();

            for (var i = 0; i < Randomisation.RandomNumber(1000, 10000); i++)
            {
                var fileInfo = new FileModel();

                if (!FileInfoValidator.IsValid(fileInfo)) continue;

                fileInfoList.Add(fileInfo);
            }

            return fileInfoList;
        }
    }
}