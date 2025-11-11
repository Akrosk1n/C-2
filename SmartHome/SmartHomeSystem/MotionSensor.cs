using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHomeSystem
{
    public class MotionSensor : Device
    {
        public MotionSensor(string name) : base(name) { }
        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name} активовано.");
        }

        public override void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name} деактивовано.");
        }
    }
}
