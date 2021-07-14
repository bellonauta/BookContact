using BookContactControl.Common;
using System;
using System.Text.RegularExpressions;

namespace BookContactControl.Common.Validators
{
    public class PhoneAssertionConcern
    {
        public static void AssertIsValid(string phone, string message)
        {
            if (!Regex.IsMatch(phone, @"^\([1-9]{2}\)(?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", RegexOptions.IgnoreCase))
                throw new InvalidOperationException(message);
        }
    }
}