using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        public bool _isOn  = false;

        public Lamp()
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

        public bool IsOn()
        {
            return _isOn;
        }
    }
}
