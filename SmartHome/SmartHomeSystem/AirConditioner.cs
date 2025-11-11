using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHomeSystem
{
    public class AirConditioner : Device, IEnergyConsumer
    {
        public const int POWER = 2000;

        public AirConditioner(string name) : base(name) { }

        public string DeviceName => Name;
        public int PowerConsumption => POWER;

        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name} почав охолодження");
        }

        public override void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name} зупинено");
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
