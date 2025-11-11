using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHomeSystem
{
    public class SmartHomeController
    {
        private readonly List<ISwitchable> switchableDevices = new List<ISwitchable>();
        private readonly List<IEnergyConsumer> energyConsumer = new List<IEnergyConsumer>();

        public void AddDevice(ISwitchable device)
        {
            switchableDevices.Add(device);
        }

        public void AddEnergyDevice(IEnergyConsumer device)
        {
            energyConsumer.Add(device);
        }

        public void TurnAllOn()
        {
            foreach (var device in switchableDevices)
            {
                device.TurnOn();
            }
        }

        public void TurnAllOff()
        {
            foreach (var device in switchableDevices)
            {
                device.TurnOff();
            }
        }

        public void ShowEnergyReport(int hours)
        {
            double totalConsumption = 0;
            const double pricePerKWh = 4.0;

            Console.WriteLine($"Звіт про споживання енергії за {hours} год:");

            foreach(var consumer in energyConsumer)
            {
                double usage = consumer.GetEnergyUsage(hours);
                totalConsumption += usage;
                Console.WriteLine($"{consumer.DeviceName}: {usage:F2} кВт·год (потужність: {consumer.PowerConsumption} Вт)");
            }

            double totalCost = totalConsumption * pricePerKWh;

            Console.WriteLine($"Загальне споживання: {totalConsumption:F2} кВт·год");
            Console.WriteLine($"Вартість (~{pricePerKWh} грн/кВт·год): {totalCost:F2} грн");

        }

        public IEnumerable<ISwitchable> GetAllDevices() => switchableDevices;
    }
}
