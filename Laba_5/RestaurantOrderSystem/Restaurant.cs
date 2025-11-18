using System;
using System.Collections.Generic;

namespace RestaurantOrderSystem
{
    public class Restaurant
    {
        private List<IMenuItem> menu = new List<IMenuItem>();
        private List<Order> orders = new List<Order>();
        private int nextId = 1;

        public void AddMenuItem(IMenuItem item)
        {
            menu.Add(item);
        }

        public void PrintMenu()
        {
            Console.WriteLine("=== МЕНЮ РЕСТОРАНУ ===");

            if (menu.Count == 0)
            {
                Console.WriteLine("Меню пусте.");
                return;
            }

            int i = 1;
            foreach (var item in menu)
            {
                if (item is Dish d)// Dish d — якщо цей пункт меню є страва → виводимо як страву
                {
                    Console.WriteLine($"{i}. {d.Name} ({d.Category}) — {d.Price} грн");
                }
                else if (item is Drink dr)//анологічно до напоїв
                {
                    string alc = dr.IsAlcoholic ? "алк." : "без алк.";
                    Console.WriteLine($"{i}. {dr.Name} ({dr.VolumeMl} мл, {alc}) — {dr.Price} грн");
                }
                i++;
            }
        }

        public Order CreateOrder(int table)//створюємо замовлення
        {
            Order o = new Order(nextId, table);
            nextId++;
            orders.Add(o);

            Console.WriteLine($"Створено замовлення ID: {o.Id} для столика {table}");
            return o;
        }

        public IMenuItem GetItemByIndex(int index)//використовується при виборі страви за номером
        {
            if (index >= 0 && index < menu.Count)
                return menu[index];
            return null;
        }

        public void PrintAllOrders()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("Замовлень немає.");
                return;
            }

            Console.WriteLine("=== УСІ ЗАМОВЛЕННЯ ===");
            foreach (var o in orders)
            {
                o.PrintShort();
            }
        }

        public Order FindOrderById(int id)//Пошук замовлення
        {
            foreach (var o in orders)
            {
                if (o.Id == id)
                    return o;
            }
            return null;
        }
    }
}
