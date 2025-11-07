using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        public const int MaxBrightness = 100 ;
        public bool IsOn {  get; private set; }
        public int Brightness { get; private set; }
        private Random Random { get; set; }
        public int Guid { get; private set; } = 0;

        public Lamp(int _brightness, Random random)
        {
            Brightness = _brightness;
            Random = random;
        }

        public Lamp()               //overload del costruttore
        {
            Brightness = 0;
            IsOn = false;
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

        public bool IsLampOn()
        {
            return IsOn;
        }

        public void GenerateGUID(Random random)
        {
            if (Guid != 0)
            {
                throw new InvalidOperationException("GUID already generated");
            }
            Guid = (Random.Next(10000, 100000));
           
        }


    }
}
