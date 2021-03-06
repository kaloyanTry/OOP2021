namespace Telephony
{
    public class StationaryPhone : Phone
    {
        public override string Call(string number)
        {
            Validator.ThrowIfNumberInvalid(number);

            return $"Dialing... {number}";
        }
    }
}
