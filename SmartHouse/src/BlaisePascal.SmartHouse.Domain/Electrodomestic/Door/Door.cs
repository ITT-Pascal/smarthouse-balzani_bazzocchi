using BlaisePascal.SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Door
{
    public class Door: AbstractDevice, IOpenable, ILockable
    {
        private PIN _lockCode { get; set; }
        public Door(PIN lockCode, Name name):base(name)
        {
            _lockCode = lockCode;
            Status = DeviceStatus.Close;
        }
        public void Open()
        {
            if (Status == DeviceStatus.Lock)
                throw new InvalidOperationException("Cannot open a locked door.");
            Status = DeviceStatus.Open;

        }
        public void Close()
        {
            Status = DeviceStatus.Close;
        }

        public void Lock()
        {
            if (Status == DeviceStatus.Open)
                throw new InvalidOperationException("Cannot lock an open door.");
            if (Status == DeviceStatus.Close)
                Status = DeviceStatus.Lock;
        }
        public void Unlock(PIN code)
        {
            if (code == _lockCode)
            Status = DeviceStatus.Unlock;
        }
        public void SetNewUnlockCode(PIN newUnlockCode)
        {
            if (Status == DeviceStatus.Open)
                _lockCode = newUnlockCode;
            Status = DeviceStatus.Close;
        }
    }

}
