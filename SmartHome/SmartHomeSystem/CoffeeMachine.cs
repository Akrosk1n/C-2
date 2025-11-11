using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHomeSystem
{
    public class CoffeeMachine : Device, IEnergyConsumer
    {
        public const int POWER = 1000;

        public CoffeeMachine(string name) : base(name) { }

        public string DeviceName => Name;
        public int PowerConsumption => POWER;

        public override void TurnOn()
        {
            IsOn = true;
            Console.Write($"{Name} почала готувати каву.");
        }

        public override void TurnOff()
        {
            IsOn = false;
            Console.Write($"{Name} завершила роботу.");
        }

        public double GetEnergyUsage(int hours)
        {
            if (!IsOn)
            {
                return 0.0;
            }

            return PowerConsumption * hours / 1000.0;
        }
    }
}
