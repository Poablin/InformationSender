﻿using System;
using System.Linq;

namespace InformationSender.Utilities
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
            var start = new DateTime(2010, 01, 01);
            var range = (DateTime.Today - start).Days;

            return start.AddDays(Random.Next(range));
        }
    }
}