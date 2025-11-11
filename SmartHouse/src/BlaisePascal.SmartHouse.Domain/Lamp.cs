using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp: LampDesign
    {
        public const int MaxBrightness = 100 ;
       
        public Lamp(int _brightness, Guid guid)
        {
            Brightness = _brightness;
            Id = guid;
        }

        public Lamp()               //overload del costruttore
        {

            Brightness = 0;
            IsOn = false;
            Id = new Guid();
        }

        public override void TurnOnOff()
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

        public override void ChangeBrightness(int brightness)
        {
            if (!IsOn)
            {
                throw new InvalidOperationException("Cannot change brightness if the lamp is off");
            }

            if (brightness > MaxBrightness || brightness < 0)
            {
                throw new ArgumentOutOfRangeException("Brightness must be in the range");
            }
            Brightness = brightness;
        }

        public override bool IsLampOn() 
        {
            return IsOn;
        }


    }
}
