using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        public const int MaxBrightness = 100 ;
        public bool IsOn {  get; private set; }
        public int Brightness { get; private set; }

        public Lamp(int _brightness)
        {
            Brightness = _brightness;
        }

        public Lamp()               //overload del costruttore
        {

        }

        public void TurnOnOff()
        {
            if (IsOn == false)
            {
                IsOn = true;
                Brightness = MaxBrightness;
            } else
            {
                IsOn = false;
                Brightness = 0;
            }
        }

        public void ChangeBrightness(int brightness)
        {
            if (brightness > MaxBrightness || brightness < 0)
            {
                throw new ArgumentOutOfRangeException("Brightness must be in the range");
            }
            Brightness = brightness;
        }

        public bool IsLampOn()
        {
            return IsOn;
        }


    }
}
