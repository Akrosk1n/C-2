using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHomeSystem
{
    public interface ISwitchable
    {
        public void TurnOn();
        public void TurnOff();
        bool IsOn { get; }
    }
}
