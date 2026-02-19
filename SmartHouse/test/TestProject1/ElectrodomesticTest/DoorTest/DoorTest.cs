using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Door.Entities;

namespace TestProject1.DoorTest.DoorTest
{
    public class DoorTest
    {
        readonly Name name = new Name("door");
        readonly PIN lockCode = new PIN("1234");
        [Fact]
        public void Open_IfTheDoorIsUnlockedOpen()
        {
            Door newDoor = new Door(lockCode, name);
            newDoor.Open();
            Assert.Equal(DeviceStatus.Open, newDoor.Status);
        }

        [Fact]
        public void Open_IfTheDoorIsLockedDoNotOpen()
        {
            Door newDoor = new Door(new PIN("1234"), name);
            newDoor.Lock();
            Assert.Throws<InvalidOperationException>(() => newDoor.Open());
        }

        [Fact]
        public void Lock_IfTheDoorIsCloseLock()
        {
            Door newDoor = new Door(new PIN("1234"), name);

            newDoor.Close();

            Assert.Equal(DeviceStatus.Close, newDoor.Status);
        }
        [Fact]
        public void Lock_IfTheDoorIsOpenDoNotLock()
        {
            Door newDoor = new Door(new PIN("1234"), name);
            newDoor.Open();
            Assert.Throws<InvalidOperationException>(() => newDoor.Lock());
        }

        [Fact]
        public void Unlock_IfTheCodeIsCorrectUnlock()
        {
            Door newDoor = new Door(new PIN("1234"), name);
            newDoor.Lock();
            newDoor.Unlock(new PIN("1234"));
            Assert.True(newDoor.Status == DeviceStatus.Unlock);
        }

        [Fact]
        public void Unlock_IfTheCodeIsIncorrectDoNotUnlock()
        {
            Door newDoor = new Door(new PIN("1234"), name);
            newDoor.Lock();
            newDoor.Unlock(new PIN("9994"));
            Assert.False(newDoor.Status == DeviceStatus.Unlock);
        }

        [Fact]
        public void SetNewUnlockCode_IfTheDoorIsOpenSetNewCode()
        {
            Door newDoor = new Door(new PIN("1234"), name);
            newDoor.Open();
            newDoor.SetNewUnlockCode(new PIN("9994"));
            newDoor.Close();
            newDoor.Lock();
            newDoor.Unlock(new PIN("9994"));
            Assert.True(newDoor.Status == DeviceStatus.Unlock);
        }
        [Fact]
        public void SetNewUnlockCode_IfTheDoorIsClosedDoNotSetNewCode()
        {
            Door newDoor = new Door(new PIN("1234"), name);
            newDoor.Close();
            newDoor.Lock();
            newDoor.SetNewUnlockCode(new PIN("9994"));
            newDoor.Unlock(new PIN("9994"));
            Assert.False(newDoor.Status == DeviceStatus.Unlock);
        }
    }
}
