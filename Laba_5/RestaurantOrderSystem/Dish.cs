namespace RestaurantOrderSystem
{
    // Клас для страв.
    public class Dish : IMenuItem
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public string Category { get; private set; }

        public Dish(string name, double price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
}
