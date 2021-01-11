using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace InformationSender
{
    internal class FileInfoValidator
    {
        public FileInfoValidator()
        {
            UsedFilenames = new List<string>();
            UsedInvoiceNumbers = new List<string>();
        }

        private static readonly Regex ValidFilenameRegex =
            new Regex(@"^2[\d]{7}.pdf$", RegexOptions.Compiled);

        private static readonly Regex ValidInvoiceNumberRegex =
            new Regex(@"^1[\d]{6}$", RegexOptions.Compiled);

        private static readonly Regex ValidKidRegex =
            new Regex(@"^0051[\d]{6}\d$", RegexOptions.Compiled);

        private static readonly Regex ValidZipCodeRegex =
            new Regex(@"^[\d]{4}$", RegexOptions.Compiled);

        private readonly List<string> UsedFilenames;

        private readonly List<string> UsedInvoiceNumbers;

        public bool IsValid(FileModel fileInfo)
        {
            if (fileInfo == null) return false;

            return IsCorrectFormat(fileInfo) && IsValidDate(fileInfo.IssueDate, fileInfo.DueDate) 
                && StringNotUsed(fileInfo.Filename, fileInfo.InvoiceNumber);
        }

        public bool StringNotUsed(string filename, string invoiceNumber)
        {
            if (UsedFilenames.Contains(filename) || UsedInvoiceNumbers.Contains(invoiceNumber))
            {
                return false;
            }

            return true;
        }

        public bool IsCorrectFormat(FileModel fileInfo)
        {
            var filenameCorrectFormat = ValidFilenameRegex.Match(fileInfo.Filename);
            var invoiceNumberCorrectFormat = ValidInvoiceNumberRegex.Match(fileInfo.InvoiceNumber);
            var kidCorrectFormat = ValidKidRegex.Match(fileInfo.KID);
            var zipCorrectFormat = ValidZipCodeRegex.Match(fileInfo.ZipCode);

            var correctFormat = filenameCorrectFormat.Success
                && invoiceNumberCorrectFormat.Success 
                && kidCorrectFormat.Success
                && zipCorrectFormat.Success;

            return correctFormat;
        }

        public bool IsValidDate(string issueDate, string dueDate)
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

        public void AddUniqueStrings(FileModel fileInfo)
        {
            UsedFilenames.Add(fileInfo.Filename);
            UsedInvoiceNumbers.Add(fileInfo.InvoiceNumber);
        }
    }
}