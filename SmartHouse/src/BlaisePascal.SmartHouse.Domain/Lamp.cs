using System;
using System.Collections.Generic;
using System.Globalization;
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
        public Guid Id { get; private set; }

        public Lamp(int _brightness, Random random, Guid guid)
        {
            Brightness = _brightness;
            Random = random;
            Id = guid;
        }

        public Lamp()               //overload del costruttore
        {
            Brightness = 0;
            IsOn = false;
            Id = new Guid();
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

        public bool IsLampOn() // prova
        {
            return IsOn;
        }


    }
}
