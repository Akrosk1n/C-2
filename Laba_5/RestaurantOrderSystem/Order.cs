using System;
using System.Collections.Generic;

namespace RestaurantOrderSystem
{
    public class Order
    {
        private List<IMenuItem> items = new List<IMenuItem>();

        public int Id { get; private set; }
        public int TableNumber { get; private set; }
        public OrderStatus Status { get; private set; }

        public Order(int id, int table)
        {
            Id = id;
            TableNumber = table;
            Status = OrderStatus.New;
        }

        public void AddItem(IMenuItem item)
        {
            items.Add(item);
            Console.WriteLine($"Додано: {item.Name}");
        }

        public void RemoveItem(string name)
        {
            IMenuItem found = items.Find(i => i.Name.ToLower() == name.ToLower());
            if (found != null)
            {
                items.Remove(found);
                Console.WriteLine($"Видалено: {found.Name}");
            }
            else
            {
                Console.WriteLine("Такої позиції немає.");
            }
        }

        public double GetTotalPrice()
        {
            double total = 0;
            foreach (var i in items)
                total += i.Price;
            return total;
        }

        public void ChangeStatus(OrderStatus st)
        {
            Status = st;
            Console.WriteLine("Статус змінено: " + st);
        }

        public void PrintShort()
        {
            Console.WriteLine($"ID {Id} | Стіл {TableNumber} | {Status} | {GetTotalPrice()} грн");
        }

        public void PrintDetails()
        {
            Console.WriteLine($"=== Замовлення ID {Id} ===");
            Console.WriteLine($"Стіл: {TableNumber}");
            Console.WriteLine($"Статус: {Status}");
            Console.WriteLine("Позиції:");

            if (items.Count == 0)
            {
                Console.WriteLine("  (пусто)");
            }
            else
            {
                int n = 1;
                foreach (var i in items)
                {
                    Console.WriteLine($"{n}. {i.Name} — {i.Price} грн");
                    n++;
                }
            }

            Console.WriteLine($"Сума: {GetTotalPrice()} грн");
        }
    }
}
