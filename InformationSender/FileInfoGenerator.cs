using InformationSender.Utilities;
using System.Collections.Generic;

namespace InformationSender
{
    internal class FileInfoGenerator
    {
        public List<FileModel> CreateFileInfoList()
        {
            var fileInfoList = new List<FileModel>();
            var fileInfoValidator = new FileInfoValidator();

            var randomNum = Randomisation.RandomNumber(1000, 10000);

            var count = 0;
            while (count < randomNum)
            {
                var fileInfo = new FileModel();

                if (!fileInfoValidator.IsValid(fileInfo)) continue;

                fileInfoValidator.AddUniqueStrings(fileInfo);

                fileInfoList.Add(fileInfo);

                count++;
            }

            return fileInfoList;
        }
    }
}