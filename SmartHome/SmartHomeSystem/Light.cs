using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHomeSystem
{
    public class Light : Device, IEnergyConsumer
    {
        public const int POWER = 60;

        public Light(string name) : base(name) { }

        public string DeviceName => Name;
        public int PowerConsumption => POWER;

        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name} засвітилася.");
        }

        public override void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name} вимкнена.");
        }

        public double GetEnergyUsage(int hours)
        {
            if(!IsOn)
            {
                return 0.0;
            }

            return PowerConsumption * hours / 1000.0;
        }
    }
}
