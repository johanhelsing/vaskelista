using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vaskelista.Models
{
    public static class StringExtensions
    {
        public static string CapitalizeFirstLetter(this String input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            return input.Substring(0, 1).ToUpper() + input.Substring(1, input.Length - 1);
        }
    }
}