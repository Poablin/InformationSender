using InformationSender.Utils;

namespace InformationSender
{
    internal static class FileInfoGenerator
    {
        public static FileModel[] CreateFileInfoList()
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