namespace RestaurantOrderSystem
{
    // Клас для напоїв.
    public class Drink : IMenuItem
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int VolumeMl { get; private set; }
        public bool IsAlcoholic { get; private set; }

        public Drink(string name, double price, int volumeMl, bool isAlcoholic)
        {
            Name = name;
            Price = price;
            VolumeMl = volumeMl;
            IsAlcoholic = isAlcoholic;
        }
    }
}
