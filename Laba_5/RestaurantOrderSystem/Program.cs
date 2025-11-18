using System;

namespace RestaurantOrderSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ресторан — система замовлень";
            Restaurant rest = new Restaurant();

            //Додаємо cтрави через dssh 
            rest.AddMenuItem(new Dish("Борщ український", 120, "Перше"));
            rest.AddMenuItem(new Dish("Солянка", 135, "Перше"));
            rest.AddMenuItem(new Dish("Піцца Маргарита", 180, "Гаряче"));
            rest.AddMenuItem(new Dish("Паста Карбонара", 160, "Гаряче"));
            rest.AddMenuItem(new Dish("Олів’є", 90, "Салат"));
            rest.AddMenuItem(new Dish("Цезар", 105, "Салат"));

            rest.AddMenuItem(new Drink("Лимонад", 55, 300, false));
            rest.AddMenuItem(new Drink("Кава", 45, 200, false));
            rest.AddMenuItem(new Drink("Чай чорний", 35, 250, false));
            rest.AddMenuItem(new Drink("Пиво світле", 70, 500, true));

            //Menu
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=========================================");
                Console.WriteLine("       СИСТЕМА ЗАМОВЛЕНЬ РЕСТОРАНУ");
                Console.WriteLine("=========================================");
                Console.ResetColor();

                Console.WriteLine("1 — Показати меню");
                Console.WriteLine("2 — Створити нове замовлення");
                Console.WriteLine("3 — Переглянути всі замовлення");
                Console.WriteLine("4 — Знайти замовлення по ID");
                Console.WriteLine("0 — Вийти");
                Console.Write("\nВаш вибір: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        rest.PrintMenu();
                        Pause();
                        break;

                    case "2":
                        CreateOrderWithChoosing(rest);
                        break;

                    case "3":
                        rest.PrintAllOrders();
                        Pause();
                        break;

                    case "4":
                        Console.Write("Введіть ID замовлення: ");
                        Pause();
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Невірний вибір!");
                        Pause();
                        break;
                }
            }
        }

        
        //cтворює заказ через ресторна і поки не буде нажата кнопка q цикл буде працювати 
        static void CreateOrderWithChoosing(Restaurant rest)
        {
            Console.Write("Введіть номер столика: ");
            int table = int.Parse(Console.ReadLine());

            Order order = rest.CreateOrder(table);

            bool selecting = true;

            while (selecting)
            {
                Console.Clear();
                Console.WriteLine("=== ВИБІР СТРАВ ===");
                rest.PrintMenu();

                Console.WriteLine("\nВведіть номер позиції, щоб додати.");
                Console.WriteLine("q — Закінчити вибір");
                Console.WriteLine("d — Видалити позицію");
                Console.Write("\nВаш вибір: ");
                // обробка вводу 
                string cho = Console.ReadLine();

                if (cho == "q")
                {
                    selecting = false;
                }
                else if (cho == "d")
                {
                    Console.Write("Введіть назву позиції для видалення: ");
                    string name = Console.ReadLine();
                    order.RemoveItem(name);
                    Pause();
                }
                else
                {
                    int index;
                    //int.TryParse()намагаємось перетворити ввід у число
                    if (int.TryParse(cho, out index))
                    {
                        IMenuItem item = rest.GetItemByIndex(index - 1);// -1 бо починаєсо з 0
                        if (item != null)//якщо номер правт=ильний вводимо, якщо ні то помилка
                        {
                            order.AddItem(item);
                        }
                        else
                        {
                            Console.WriteLine(" Помилка. Немає такого номера.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Невірний ввід.");
                    }
                    Pause();
                }
            }

            Console.WriteLine("\nЗамовлення створено!");
            order.PrintDetails();
            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nНатисніть будь-яку кнопку...");
            Console.ReadKey();
        }
    }
}
