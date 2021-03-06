using System;
using System.Linq;

namespace Telephony
{
    static class Validator
    {
        public static void ThrowIfNumberInvalid(string number)
        {
            if (number.Any(n => !char.IsDigit(n)))
            {
                throw new InvalidOperationException("Invalid number!");
            }
        }
    }
}
