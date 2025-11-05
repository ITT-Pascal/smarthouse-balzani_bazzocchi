using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class TwoDeviceLamp

    {
        public const int MaxBrightness = 100;
        public bool IsOn { get; private set; }
        public int Brightness { get; private set; }
        public Lamp _lamp { get; private set; }
        
        public TwoDeviceLamp(int _brightness, Lamp lamp)
        {
            Brightness = _brightness;
            _lamp = new Lamp();
        }
        public void TurnOnOffLamp()
        {
            _lamp.TurnOnOff();
        }
    }
}
