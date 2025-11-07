using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class LampsRow
    {
        public const int MaxBrightness = 100;
        public bool IsOn { get; private set; }
        public int Brightness { get; private set; }
        public Lamp Lamp { get; private set; }
        public EcoLamp EcoLamp { get; private set; }
        List <object> RowLamps;

        public LampsRow(int brightness, Lamp lamp, EcoLamp ecoLamp)
        {
            Brightness = brightness;
            Lamp = lamp;
            EcoLamp = ecoLamp;
            IsOn = false;
        }

        public LampsRow()
        {
            Brightness = 0;
            Lamp = new Lamp();
            EcoLamp = new EcoLamp();
            IsOn = false;
        }

    }
}
