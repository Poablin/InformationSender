namespace InformationSender
{
    public class FileModel
    {
        // Either: 10001 or 10002
        public string Owner { get; set; }

        // Always "BOF"
        public string DocType { get; set; }

        // Unique number + .pdf in format 2XXXXXXX.pdf
        public string Filename { get; set; }

        // Unique number in format 1XXXXXX 
        public string InvoiceNumber { get; set; }

        // Always 000001
        public string CustomerNumber { get; set; }

        // A valid KID using MOD 10 check digit, in format 005{invoiceNumber}{checkDigit}
        public string KID { get; set; }

        // A random sequence of alpha characters
        public string Name { get; set; }

        // A random sequence of alpha characters
        public string Addr1 { get; set; }

        // A random 4 digit number
        public string ZipCode { get; set; }

        // A random sequence of alpha characters
        public string ZipName { get; set; }

        // Always NO
        public string CountryCode { get; set; }

        // A random date, minimum 30 days back
        public string IssueDate { get; set; }

        // Always IssueDate + 30 days
        public string DueDate { get; set; }

        // A random number
        public double TotalAmount { get; set; }

        // Some local path
        public string FileLocation { get; set; }

        // Always 001
        public long BatchID { get; set; }

    }
}
