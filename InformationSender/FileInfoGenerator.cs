using InformationSender.Utilities;
using System.Collections.Generic;

namespace InformationSender
{
    internal class FileInfoGenerator
    {
        public FileInfoGenerator()
        {
            UniqueFilenameNumber = 1000000;
            UniqueInvoiceNumber = 100000;
        }
        private int UniqueFilenameNumber { get; set; }
        private int UniqueInvoiceNumber { get; set; }
        private int ZipCode { get; set; }

        public List<FileModel> CreateFileInfoList()
        {
            var randomNum = Randomisation.RandomNumber(1000, 10000);

            var fileInfoList = new List<FileModel>(randomNum);
            var fileInfoValidator = new FileInfoValidator();

            while (fileInfoList.Count < fileInfoList.Capacity)
            {
                var fileInfo = new FileModel(UniqueFilenameNumber, UniqueInvoiceNumber);

                if (!fileInfoValidator.IsValid(fileInfo)) continue;

                UniqueFilenameNumber++;
                UniqueInvoiceNumber++;

                fileInfoList.Add(fileInfo);
            }

            return fileInfoList;
        }
    }
}