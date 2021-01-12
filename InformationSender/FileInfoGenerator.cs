using InformationSender.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public List<FileModel> CreateFileInfoList()
        {
            var randomNum = Randomisation.RandomNumber(1000, 10000);

            var fileInfoList = new List<FileModel>(randomNum);
            var fileInfoValidator = new FileInfoValidator();

            Parallel.For(0, randomNum,
                index =>
                {
                    FileModel fileInfo;
                    lock (this)
                    {
                        fileInfo = new FileModel(UniqueFilenameNumber, UniqueInvoiceNumber);
                        UniqueFilenameNumber++;
                        UniqueInvoiceNumber++;
                    }

                    if (!fileInfoValidator.IsValid(fileInfo)) return;

                    fileInfoList.Add(fileInfo);
                });

            //for (int i = 0; i < randomNum; i++)
            //{
            //    var fileInfo = new FileModel(UniqueFilenameNumber, UniqueInvoiceNumber);

            //    if (!fileInfoValidator.IsValid(fileInfo)) continue;

            //    UniqueFilenameNumber++;
            //    UniqueInvoiceNumber++;

            //    fileInfoList.Add(fileInfo);
            //}

            return fileInfoList;
        }
    }
}