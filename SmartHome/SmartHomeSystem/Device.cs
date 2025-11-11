using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHomeSystem
{
    public abstract class Device : ISwitchable
    {
        public string Name { get; set; }

        public bool IsOn { get; protected set; }

        public Device(string name){
        Name = name;
        IsOn = false;
}

        public abstract void TurnOn();
        public abstract void TurnOff();


        public void PrintStatus() {
            System.Console.WriteLine($"{Name}: {(IsOn ? "увімкнено" : "вимкнено")}");
        }
    }
}
