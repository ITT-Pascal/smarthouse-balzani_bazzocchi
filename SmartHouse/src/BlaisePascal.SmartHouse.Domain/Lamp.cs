using ImageProcessor.Processors;
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
        public Lamp(int _brightness, Guid guid, string lampName)
        {
            Brightness = _brightness;
            Id = guid;
            LampName = lampName;
        }

        public Lamp() { }

        public Lamp(string lampName)               //overload del costruttore
        {

            Brightness = 0;
            IsOn = false;
            Id = new Guid();
            LampName = lampName;
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

        public override bool IsLampOn() 
        {
            return IsOn;
        }


    }
}
