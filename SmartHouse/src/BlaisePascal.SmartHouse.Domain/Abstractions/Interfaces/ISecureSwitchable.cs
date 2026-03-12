using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstractions.Interfaces
{
    public interface ISecureSwitchable
    {
        void SecureSwitchOn(PIN code);
        void SecureSwitchOff(PIN code);
        void SecureToggle(PIN code);
        void SetNewSecurityCode(PIN newCode, PIN oldCode);
    }
}
