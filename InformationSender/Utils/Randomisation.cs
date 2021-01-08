using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationSender.Utils
{
    public static class Randomisation
    {
        private static readonly Random Random = new Random();

        public static int RandomNumber(int minValue, int maxValue)
        {
           return Random.Next(minValue, maxValue);
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static DateTime RandomDate()
        {
            var start = new DateTime(1990, 01, 01);
            var range = (DateTime.Today - start).Days;

            return start.AddDays(Random.Next(range));
        }
    }
}
