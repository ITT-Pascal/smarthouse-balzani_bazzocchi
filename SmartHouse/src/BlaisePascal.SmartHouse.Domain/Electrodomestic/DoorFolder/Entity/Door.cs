using BlaisePascal.SmartHouse.Domain.Abstractions.AbstractClasses;
using BlaisePascal.SmartHouse.Domain.Abstractions.Interfaces;
using BlaisePascal.SmartHouse.Domain.Abstractions.Status;
using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;
using System;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.DoorFolder.Entities
{
    public class Door : AbstractDevice, IOpenable, ILockable
    {
        public PIN _lockCode { get; private set; }
        public AccesibilityStatus Accessibility { get; private set; }
        public LockingStatus LockingStatus { get; private set; }

        public Door(PIN lockCode, Name name) : base(name)
        {
            _lockCode = lockCode;
            Accessibility = AccesibilityStatus.Close;
            LockingStatus = LockingStatus.Unlock;
        }

        public void Open()
        {
            if (LockingStatus == LockingStatus.Lock)
                throw new InvalidOperationException("Cannot open a locked door.");

            if (Accessibility == AccesibilityStatus.Open)
                return; 

            Accessibility = AccesibilityStatus.Open;
        }

        public void Close()
        {
            if (Accessibility == AccesibilityStatus.Close)
                return;

            Accessibility = AccesibilityStatus.Close;
        }

        public void Lock()
        {
            if (Accessibility == AccesibilityStatus.Open)
                throw new InvalidOperationException("Cannot lock an open door.");

            if (LockingStatus == LockingStatus.Lock)
                return;

            LockingStatus = LockingStatus.Lock;
        }

        public void Unlock(PIN code)
        {
            if (code == _lockCode)
            {
                if (LockingStatus == LockingStatus.Unlock)
                    return;
                LockingStatus = LockingStatus.Unlock;
            }
        }

        public void SetNewUnlockCode(PIN oldCode, PIN newUnlockCode)
        {
            if (this._lockCode == oldCode)
            {
                _lockCode = newUnlockCode;
                Close();
                Lock();  
            }
            else
            {
                throw new InvalidOperationException("Il vecchio PIN inserito non è corretto.");
            }
        }
    }
}