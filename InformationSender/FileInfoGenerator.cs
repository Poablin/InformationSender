using InformationSender.Utilities;
using System.Collections.Generic;

namespace InformationSender
{
    internal class FileInfoGenerator
    {
        public List<FileModel> CreateFileInfoList()
        {
            var randomNum = Randomisation.RandomNumber(1000, 10000);

            var fileInfoList = new List<FileModel>(randomNum);
            var fileInfoValidator = new FileInfoValidator();

            while (fileInfoList.Count < fileInfoList.Capacity)
            {
                var fileInfo = new FileModel();

                if (!fileInfoValidator.IsValid(fileInfo)) continue;

                fileInfoList.Add(fileInfo);
            }

            return fileInfoList;
        }
    }
}