using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Door;
using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace TestProject1.DoorTest.DoorTest
{
    public class DoorTest
    {
        string name = "door";
        Guid id = Guid.NewGuid();
        int lockCode = 123;
        [Fact]
        public void Open_IfTheDoorIsUnlockedOpen()
        {
            Door newDoor = new Door(lockCode, name, id);
            newDoor.Open();
            Assert.Equal(DeviceStatus.Open, newDoor.Status);
        }

        [Fact]
        public void Open_IfTheDoorIsLockedDoNotOpen()
        {
            Door newDoor = new Door(123, name, id);
            newDoor.Lock();
            Assert.Throws<InvalidOperationException>(() => newDoor.Open());
        }

        [Fact]
        public void Lock_IfTheDoorIsCloseLock()
        {
            Door newDoor = new Door(123, name, id);

            newDoor.Close();

            Assert.Equal(DeviceStatus.Close, newDoor.Status);
        }
        [Fact]
        public void Lock_IfTheDoorIsOpenDoNotLock()
        {
            Door newDoor = new Door(123, name, id);
            newDoor.Open();
            Assert.Throws<InvalidOperationException>(() => newDoor.Lock());
        }

        [Fact]
        public void Unlock_IfTheCodeIsCorrectUnlock()
        {
            Door newDoor = new Door(123, name, id);
            newDoor.Lock();
            newDoor.Unlock(123);
            Assert.True(newDoor.Status == DeviceStatus.Unlock);
        }

        [Fact]
        public void Unlock_IfTheCodeIsIncorrectDoNotUnlock()
        {
            Door newDoor = new Door(123, name, id);
            newDoor.Lock();
            newDoor.Unlock(999);
            Assert.False(newDoor.Status == DeviceStatus.Unlock);
        }

        [Fact]
        public void SetNewUnlockCode_IfTheDoorIsOpenSetNewCode()
        {
            Door newDoor = new Door(123, name, id);
            newDoor.Open();
            newDoor.SetNewUnlockCode(999);
            newDoor.Close();
            newDoor.Lock();
            newDoor.Unlock(999);
            Assert.True(newDoor.Status == DeviceStatus.Unlock);
        }
        [Fact]
        public void SetNewUnlockCode_IfTheDoorIsCloseDoNotSetNewCode()
        {
            Door newDoor = new Door(123, name, id);
            newDoor.Close();
            newDoor.SetNewUnlockCode(999);
            newDoor.Lock();
            newDoor.Unlock(999);
            Assert.False(newDoor.Status == DeviceStatus.Unlock);
        }
    }
}
