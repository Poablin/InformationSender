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

        private FileModel FileInfo;

        private readonly List<string> UsedFilenames;

        private readonly List<string> UsedInvoiceNumbers;

        public bool IsValid(FileModel fileInfo)
        {
            if (fileInfo == null) return false;

            FileInfo = fileInfo;

            return IsCorrectFormat() 
                && IsValidDate()
                && StringNotUsed();
        }

        private bool IsCorrectFormat()
        {
            var filenameCorrectFormat = ValidFilenameRegex.Match(FileInfo.Filename);
            var invoiceNumberCorrectFormat = ValidInvoiceNumberRegex.Match(FileInfo.InvoiceNumber);
            var kidCorrectFormat = ValidKidRegex.Match(FileInfo.KID);
            var zipCorrectFormat = ValidZipCodeRegex.Match(FileInfo.ZipCode);

            var correctFormat = filenameCorrectFormat.Success 
                && invoiceNumberCorrectFormat.Success
                && kidCorrectFormat.Success
                && zipCorrectFormat.Success;

            return correctFormat;
        }

        private bool IsValidDate()
        {
            DateTime.TryParseExact(FileInfo.IssueDate, "dd.MM.yyyy",
                null, DateTimeStyles.AssumeLocal,
                out var validIssueDate);

            if ((DateTime.Now - validIssueDate).TotalDays < 30) return false;

            DateTime.TryParseExact(FileInfo.DueDate, "dd.MM.yyyy",
                null, DateTimeStyles.AssumeLocal,
                out var validDueDate);

            return (validDueDate - validIssueDate).TotalDays == 30;
        }

        private bool StringNotUsed()
        {
            if (UsedFilenames.Contains(FileInfo.Filename) || UsedInvoiceNumbers.Contains(FileInfo.InvoiceNumber))
            {
                return false;
            }

            UsedFilenames.Add(FileInfo.Filename);
            UsedInvoiceNumbers.Add(FileInfo.InvoiceNumber);

            return true;
        }
    }
}