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

        private static readonly Regex ValidInvoiceNumberRegex =
            new Regex(@"^1[\d]{6}$", RegexOptions.Compiled);

        private static readonly Regex ValidKidRegex =
            new Regex(@"^0051[\d]{6}\d$", RegexOptions.Compiled);

        private static readonly Regex ValidZipCodeRegex =
            new Regex(@"^[\d]{4}$", RegexOptions.Compiled);

        public static bool IsValidFormat(FileModel fileinfo)
        {
            var filenameCorrectFormat = ValidFilenameRegex.Match(fileinfo.Filename);
            var invoiceNumberCorrectFormat = ValidInvoiceNumberRegex.Match(fileinfo.InvoiceNumber);
            var kidCorrectFormat = ValidKidRegex.Match(fileinfo.KID);
            var zipCorrectFormat = ValidZipCodeRegex.Match(fileinfo.ZipCode);

            var match = filenameCorrectFormat.Success
                && invoiceNumberCorrectFormat.Success
                && kidCorrectFormat.Success
                && zipCorrectFormat.Success;

            return match;
        }
    }
}
