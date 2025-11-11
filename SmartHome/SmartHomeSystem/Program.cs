using System.Linq;
using System;

namespace SmartHomeSystem
{
    class Program
    {
        public static void Main()
        {
            var controller = new SmartHomeController();

            var light = new Light("Лампа у вітальні");
            var ac = new AirConditioner("Кондиціонер у спальні");
            var cm = new CoffeeMachine("Кавомашина на кухні");
            var ms = new MotionSensor("Датчик руху у коридорі");
            controller.AddDevice(light);
            controller.AddDevice(ac);
            controller.AddDevice(cm);
            controller.AddDevice(ms);

            controller.AddEnergyDevice(light);
            controller.AddEnergyDevice(ac);
            controller.AddEnergyDevice(cm);

            controller.TurnAllOn();

            Console.WriteLine();
            foreach (var device in controller.GetAllDevices().Cast<Device>())
            {
                device.PrintStatus();
            }

            controller.ShowEnergyReport(5);

            Console.WriteLine();
            controller.TurnAllOff();
        }
    }
}
