using System;
using System.Linq;

namespace Telephony
{
    public class SmartPhone : Phone, IBrowsable
    {
        public override string Call(string number)
        {
            Validator.ThrowIfNumberInvalid(number);

            return $"Calling... {number}";
        }
        public string Browse(string url)
        {
            if (url.Any(n => char.IsDigit(n)))
            {
                throw new InvalidOperationException("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }
    }
}
