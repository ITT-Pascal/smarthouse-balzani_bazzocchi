using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Door;
using BlaisePascal.SmartHouse.Domain.Electrodomestic;

namespace TestProject1.DoorTest.DoorTest
{
    public class DoorTest
    {
        [Fact]
        public void Open_IfTheDoorIsUnlockedOpen()
        {
            Door newDoor = new Door();

            newDoor.Open();

            Assert.Equal(DeviceStatus.Open, newDoor.Status);
        }

        [Fact]
        public void Open_IfTheDoorIsLockedDoNotOpen()
        {
            Door newDoor = new Door(123);

            newDoor.Lock();

            Assert.Throws<InvalidOperationException>(() => newDoor.Open());
        }

        [Fact]
        public void Lock_IfTheDoorIsCloseLock()
        {
            Door newDoor = new Door();

            newDoor.Close();

            Assert.Equal(DeviceStatus.Close, newDoor.Status);
        }
        [Fact]
        public void Lock_IfTheDoorIsOpenDoNotLock()
        {
            Door newDoor = new Door(123);
            newDoor.Open();
            Assert.Throws<InvalidOperationException>(() => newDoor.Lock());
        }

        [Fact]
        public void Unlock_IfTheCodeIsCorrectUnlock()
        {
            Door newDoor = new Door(123);
            newDoor.Lock();
            newDoor.Unlock(123);
            Assert.False(newDoor.IsLocked);
        }

        [Fact]
        public void Unlock_IfTheCodeIsIncorrectDoNotUnlock()
        {
            Door newDoor = new Door(123);
            newDoor.Lock();
            newDoor.Unlock(999);
            Assert.True(newDoor.IsLocked);
        }

        [Fact]
        public void SetNewUnlockCode_IfTheDoorIsOpenSetNewCode()
        {
            Door newDoor = new Door(123);
            newDoor.Open();
            newDoor.SetNewUnlockCode(999);
            newDoor.Close();
            newDoor.Lock();
            newDoor.Unlock(999);
            Assert.False(newDoor.IsLocked);
        }
        [Fact]
        public void SetNewUnlockCode_IfTheDoorIsCloseDoNotSetNewCode()
        {
            Door newDoor = new Door(123);
            newDoor.Close();
            newDoor.SetNewUnlockCode(999);
            newDoor.Lock();
            newDoor.Unlock(999);
            Assert.True(newDoor.IsLocked);
        }
    }
}
