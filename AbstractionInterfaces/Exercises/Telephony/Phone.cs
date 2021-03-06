namespace Telephony
{
    public abstract class Phone : ICallable
    {
        public abstract string Call(string number);
    }
}
