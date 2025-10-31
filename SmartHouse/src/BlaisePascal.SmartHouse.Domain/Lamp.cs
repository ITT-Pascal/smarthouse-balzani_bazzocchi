using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        private bool _isOn  = false;
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
            if (_isOn == false)
            {
                _isOn = true;
            } else
            {
                _isOn = false;
            }
        }

        public void ChangeBrightness(int brightness)
        {
            if (brightness < 0)
            {
                Brightness = 0;
            }
            else if (_isOn == false)
            {
                Brightness = 0;
            }
            else
            {
                Brightness = brightness;
            }
            
        }

        public bool IsOn()
        {
            return _isOn;
        }
    }
}
