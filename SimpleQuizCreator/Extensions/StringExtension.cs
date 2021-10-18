using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Extensions
{
    public static class StringExtension
    {
        public static bool IsNumeric(this string value) => value.All(char.IsNumber);

        public static bool IsNumericN(this string text) => double.TryParse(text, out _);
    }
}
