using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstractions
{
    public abstract class AbstractSecureDevice:AbstractDevice, ISecureSwitchable
    {
        private PIN SecurityCode { get; set; }
        protected AbstractSecureDevice(Name name, PIN securityCode) : base(name)
        {
            SecurityCode = securityCode;
        }
        public virtual void SecureSwitchOn(PIN code)
        {
            if (code == SecurityCode)
                base.SwitchOn();
        }
        public virtual void SecureSwitchOff(PIN code)
        {
            if (code == SecurityCode)
                base.SwitchOff();
        }
        public virtual void SecureToggle(PIN code)
        {
            if (code == SecurityCode)
                base.Toggle();
        }
        public virtual void SetNewSecurityCode(PIN newCode, PIN oldCode)
        {
            if (oldCode == SecurityCode)
                SecurityCode = newCode;
        }
    }
}
