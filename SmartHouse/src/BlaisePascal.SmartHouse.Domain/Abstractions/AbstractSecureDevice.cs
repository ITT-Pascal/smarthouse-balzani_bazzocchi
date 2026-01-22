using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstractions
{
    public abstract class AbstractSecureDevice:AbstractDevice, ISecureSwitchable
    {
        private int SecurityCode { get; set; }
        protected AbstractSecureDevice(string name, Guid id, int securityCode) : base(name, id)
        {
            SecurityCode = securityCode;
        }
        public virtual void SecureSwitchOn(int code)
        {
            if (code == SecurityCode)
                base.SwitchOn();
        }
        public virtual void SecureSwitchOff(int code)
        {
            if (code == SecurityCode)
                base.SwitchOff();
        }
        public virtual void SecureToggle(int code)
        {
            if (code == SecurityCode)
                base.Toggle();
        }
        public virtual void SetNewSecurityCode(int newCode, int oldCode)
        {
            if (oldCode == SecurityCode)
                SecurityCode = newCode;
        }
    }
}
