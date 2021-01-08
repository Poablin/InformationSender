using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InformationSender
{
    static class FileInfoFormatValidator
    {
        private static readonly Regex ValidFilenameRegex =
            new Regex(@"^2[\d]{7}.pdf$", RegexOptions.Compiled);

        public static bool IsValidFormat(FileModel fileinfo)
        {
            var filenameCorrectFormat = ValidFilenameRegex.Match(fileinfo.Filename);

            return filenameCorrectFormat.Success;
        }
    }
}
