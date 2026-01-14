using BlaisePascal.SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Door
{
    public class Door: AbstractDevice
    {
        public bool IsLocked { get; private set; }
        private int _lockCode;

        public Door(int lockCode, string name, Guid id):base( name, id)
        {
            _lockCode = lockCode;
            IsLocked = false;
            Status = DeviceStatus.Close;
        }
        public override void Open()
        {
            if (IsLocked)
                throw new InvalidOperationException("Cannot open a locked door.");
           base.Open();

        }
        public override void Close() => base.Close();

        public void Lock()
        {
            if (Status == DeviceStatus.Open)
                throw new InvalidOperationException("Cannot lock an open door.");
            if (Status == DeviceStatus.Close)
                IsLocked = true;
        }
        public void Unlock(int code)
        {
            if (code == _lockCode)
                IsLocked = false;
        }
        public void SetNewUnlockCode(int newUnlockCode)
        {
            if (Status == DeviceStatus.Open)
                _lockCode = newUnlockCode;
        }
    }

}
