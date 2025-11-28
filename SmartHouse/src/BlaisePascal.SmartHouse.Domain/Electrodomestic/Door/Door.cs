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
        public bool IsOpen { get; private set; }
        public bool IsLocked { get; private set; }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DeviceStatus Status { get; private set; }

        private readonly string _lockCode;

        public Door(string lockCode)
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
        public void Lock(string code)
        {
            if (IsOpen == false && code == _lockCode)
                IsLocked = true;
        }

        // Sblocca la porta
        public void Unlock(string code)
        {
            if (code == _lockCode)
                IsLocked = false;
        }
    }

}
