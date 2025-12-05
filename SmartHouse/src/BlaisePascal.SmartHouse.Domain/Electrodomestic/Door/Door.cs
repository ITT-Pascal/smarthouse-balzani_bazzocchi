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

        private int _lockCode;

        public Door(int lockCode)
        {
            _lockCode = lockCode;
            IsLocked = false;
            Status = DeviceStatus.Close;
        }

        public Door() { }

        // Apre la porta (solo se non è chiusa a chiave)
        public void Open()
        {
            if (IsLocked == false)
                Status = DeviceStatus.Open;

        }

        // Chiude la porta
        public void Close()
        {
            Status = DeviceStatus.Close;
        }

        // Chiude a chiave (solo se è chiusa)
        public void Lock()
        {
            if (Status == DeviceStatus.Close)
                IsLocked = true;
        }

        // Sblocca la porta
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
