using SmartHomeSystem;
using System.Xml.Linq;

namespace SmartHome
{
  
    public class AirConditioner : Device, IEnergyConsumer
    {
        private const int POWER = 2000;

        public AirConditioner(string name) : base(name) { }

        public string DeviceName => Name;
        public int PowerConsumption => POWER;

        public override void TurnOn()
        {
            IsOn = true;
            System.Console.WriteLine($"{Name} почав охолодження.");
        }

        public override void TurnOff()
        {
            IsOn = false;
            System.Console.WriteLine($"{Name} зупинено.");
        }

        public double GetEnergyUsage(int hours)
        {
            if (!IsOn)
            {
                return 0.0;
            }
            return (double)PowerConsumption * hours / 1000.0;
        }
    }
}