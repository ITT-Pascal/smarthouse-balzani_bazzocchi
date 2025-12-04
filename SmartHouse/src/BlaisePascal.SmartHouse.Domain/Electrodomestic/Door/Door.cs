using BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Door
{
    public class Door
    {
        public bool IsLocked { get; private set; }

        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public DeviceStatus Status { get; private set; }

        private readonly int _lockCode;

        public Door(int lockCode)
        {
            _lockCode = lockCode;
            IsLocked = false;
            Status = DeviceStatus.Off;
        }

        // Apre la porta (solo se non è chiusa a chiave)
        public void Open()
        {
            if (IsLocked == false)
                Status = DeviceStatus.On;

        }

        // Chiude la porta
        public void Close()
        {
            Status = DeviceStatus.Off;
        }

        // Chiude a chiave (solo se è chiusa)
        public void Lock(int code)
        {
            if (Status == DeviceStatus.Off && code == _lockCode)
                IsLocked = true;
        }

        // Sblocca la porta
        public void Unlock(int code)
        {
            if (code == _lockCode)
                IsLocked = false;
        }
    }

}
