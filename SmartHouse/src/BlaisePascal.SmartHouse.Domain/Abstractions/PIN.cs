using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstractions
{
    public record PIN
    {
        public string SecurityCode { get; init; }

        public PIN(string securityCode)
        {
            if (string.IsNullOrWhiteSpace(securityCode) || securityCode.Length != 4 || !securityCode.All(char.IsDigit))
                throw new ArgumentException(nameof(securityCode), "Il codice di sicurezza inserito non è valido.");
            SecurityCode = securityCode;
        }
    }

}
