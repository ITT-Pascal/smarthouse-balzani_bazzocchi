using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Door
{
    public class Door // DA RIFARE
    {
        public bool IsOpen { get; private set; }
        public bool IsLocked { get; private set; }

        private readonly string _lockCode;

        public Door(string lockCode)
        {
            _lockCode = lockCode;
            IsOpen = false;
            IsLocked = false;
        }

        // Apre la porta (solo se non è chiusa a chiave)
        public bool Open()
        {
            if (IsLocked)
                return false;

            IsOpen = true;
            return true;
        }

        // Chiude la porta
        public void Close()
        {
            IsOpen = false;
        }

        // Chiude a chiave (solo se è chiusa)
        public bool Lock(string code)
        {
            if (IsOpen)
                return false;

            if (code == _lockCode)
            {
                IsLocked = true;
                return true;
            }

            return false;
        }

        // Sblocca la porta
        public bool Unlock(string code)
        {
            if (code == _lockCode)
            {
                IsLocked = false;
                return true;
            }

            return false;
        }
    }

}
