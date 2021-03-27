namespace Bakery.Models.BakedFoods
{
    public class Bread : Food
    {
        private const int InitialBreadPortion = 200;

        public Bread(string name, decimal price) 
            : base(name, InitialBreadPortion, price)
        {
        }
    }
}
