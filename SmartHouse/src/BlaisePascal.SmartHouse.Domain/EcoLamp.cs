using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp
    {
        public const int MaxBrightness = 100;
        private bool _isOn = false;
        public int Brightness { get; private set; }
        public DateTime LampOn { get; private set; }

        public EcoLamp(int _brightness)
        {
            Brightness = _brightness;
        }

        public EcoLamp()               //overload del costruttore
        {

        }

        public void TurnOnOff()
        {
            if (_isOn == false)
            {
                _isOn = true;
                LampOn = DateTime.UtcNow;
                Brightness = MaxBrightness;

            }
            else
            {
                _isOn = false;
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
            return _isOn;
        }

        public void autoTurnOff()
        {
            DateTime _now = DateTime.UtcNow;

            if (_now - LampOn > TimeSpan.FromMinutes(60))
            {
                Brightness = Brightness / 2;
            }

            if (_now - LampOn > TimeSpan.FromMinutes(120))
            {
                _isOn = false;
                Brightness = 0;
            }
        }

        
    }
}