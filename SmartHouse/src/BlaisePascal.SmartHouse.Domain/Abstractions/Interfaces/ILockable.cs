using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstractions.Interfaces
{
    public interface ILockable
    {
        void Lock();
        void Unlock(PIN code);
        void SetNewUnlockCode(PIN oldCode, PIN newUnlockCode);
    }
}
