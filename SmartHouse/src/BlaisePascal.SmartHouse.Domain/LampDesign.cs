using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public abstract class LampDesign
    {
        public const int MaxBrightness = 100;
        public string LampName {  get; protected set; }
        public Guid Id { get; protected set; }
        public bool IsOn { get; protected set; }
        public int Brightness { get; protected set; }

        public abstract void TurnOnOff();
        public abstract bool IsLampOn();
        
        public void ChangeBrightness(int brightness)
        {
            if (!IsOn)

                throw new InvalidOperationException("Cannot change brightness if the lamp is off");


            if (brightness > MaxBrightness || brightness < 0)

                throw new ArgumentOutOfRangeException("Brightness must be in the range");

            Brightness = brightness;
        }




    }
}
