using System.Linq;
using InformationSender.Utils;

namespace InformationSender
{
    public class FileModel
    {
        // Either: 10001 or 10002
        public string Owner { get; private set; }

        // Always "BOF"
        public string DocType { get; private set; }

        // Unique number + .pdf in format 2XXXXXXX.pdf
        public string Filename { get; private set; }

        // Unique number in format 1XXXXXX 
        public string InvoiceNumber { get; private set; }

        // Always 000001
        public string CustomerNumber { get; private set; }

        // A valid KID using MOD 10 check digit, in format 005{invoiceNumber}{checkDigit}
        public string KID { get; private set; }

        // A random sequence of alpha characters
        public string Name { get; private set; }

        // A random sequence of alpha characters
        public string Addr1 { get; private set; }

        // A random 4 digit number
        public string ZipCode { get; private set; }

        // A random sequence of alpha characters
        public string ZipName { get; private set; }

        // Always NO
        public string CountryCode { get; private set; }

        // A random date, minimum 30 days back
        public string IssueDate { get; private set; }

        // Always IssueDate + 30 days
        public string DueDate { get; private set; }

        // A random number
        public double TotalAmount { get; private set; }

        // Some local path
        public string FileLocation { get; private set; }

        // Always 001
        public long BatchID { get; private set; }

        public void CreateFromRandomValues()
        {
            Owner = Randomisation.RandomNumber(10001, 10003).ToString();
            DocType = "BOF";
            Filename = "2" + Randomisation.RandomNumber(0000000, 9999999) + ".pdf";
            InvoiceNumber = "1" + Randomisation.RandomNumber(000000, 999999);
            CustomerNumber = "000001";

            var mod10 = Mod10($"005{InvoiceNumber}");
            KID = $"005{InvoiceNumber}{mod10}";

            Name = Randomisation.RandomString(10);
            Addr1 = Randomisation.RandomString(6);
            ZipCode = Randomisation.RandomNumber(0000, 9999).ToString();
            ZipName = Randomisation.RandomString(9);
            CountryCode = "NO";
            TotalAmount = Randomisation.RandomNumber(00000, 99999);
            FileLocation = @"E:\Test\";
            BatchID = 001;

            var date = Randomisation.RandomDate();
            DueDate = date.ToString("dd.MM.yyyy");
            date = date.AddDays(-30);
            IssueDate = date.ToString("dd.MM.yyyy");
        }

        private static int Mod10(string kid)
        {
            var isOne = false;
            var controlNumber = 0;
            foreach (var number in kid.Reverse())
            {
                var intNumber = int.Parse(number.ToString());
                var sum = isOne ? intNumber : 2 * intNumber;
                if (sum > 9) sum = sum % 10 + 1;
                isOne = !isOne;
                controlNumber += sum;
            }

            return (10 - controlNumber % 10) % 10 == 0 ? 0 : 10 - controlNumber % 10;
        }
    }
}