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

        public static bool IsValidFormat(FileModel fileinfo)
        {
            var filenameCorrectFormat = ValidFilenameRegex.Match(fileinfo.Filename);
            var invoiceNumberCorrectFormat = ValidInvoiceNumberRegex.Match(fileinfo.InvoiceNumber);

            var match = filenameCorrectFormat.Success
                && invoiceNumberCorrectFormat.Success;

            return match;
        }
    }
}
