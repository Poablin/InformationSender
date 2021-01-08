using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace InformationSender
{
    internal static class FileInfoValidator
    {
        private static readonly Regex ValidFilenameRegex =
            new Regex(@"^2[\d]{7}.pdf$", RegexOptions.Compiled);

        private static readonly Regex ValidInvoiceNumberRegex =
            new Regex(@"^1[\d]{6}$", RegexOptions.Compiled);

        private static readonly Regex ValidKidRegex =
            new Regex(@"^0051[\d]{6}\d$", RegexOptions.Compiled);

        private static readonly Regex ValidZipCodeRegex =
            new Regex(@"^[\d]{4}$", RegexOptions.Compiled);

        public static bool IsValid(FileModel fileinfo)
        {
            if (fileinfo == null) return false;

            var filenameCorrectFormat = ValidFilenameRegex.Match(fileinfo.Filename);
            var invoiceNumberCorrectFormat = ValidInvoiceNumberRegex.Match(fileinfo.InvoiceNumber);
            var kidCorrectFormat = ValidKidRegex.Match(fileinfo.KID);
            var zipCorrectFormat = ValidZipCodeRegex.Match(fileinfo.ZipCode);

            var correctFormat = filenameCorrectFormat.Success
                                && invoiceNumberCorrectFormat.Success
                                && kidCorrectFormat.Success
                                && zipCorrectFormat.Success;

            return correctFormat && IsValidDate(fileinfo.IssueDate, fileinfo.DueDate);
        }

        public static bool IsValidDate(string issueDate, string dueDate)
        {
            DateTime.TryParseExact(issueDate, "dd.MM.yyyy",
                null, DateTimeStyles.AssumeLocal,
                out var validIssueDate);

            if ((DateTime.Now - validIssueDate).TotalDays < 30) return false;

            DateTime.TryParseExact(dueDate, "dd.MM.yyyy",
                null, DateTimeStyles.AssumeLocal,
                out var validDueDate);

            return (validDueDate - validIssueDate).TotalDays == 30;
        }
    }
}