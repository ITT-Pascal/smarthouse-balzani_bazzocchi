using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstractions
{
    public interface ILockable
    {
        void Lock();
        void Unlock(int code);
        void SetNewUnlockCode(int newUnlockCode);
    }
}
