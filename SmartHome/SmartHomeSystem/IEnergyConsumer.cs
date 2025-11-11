using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHomeSystem
{
    public interface IEnergyConsumer
    {
        public string DeviceName { get; }
        public int PowerConsumption { get; }
        public double GetEnergyUsage(int hours);
    }
}
