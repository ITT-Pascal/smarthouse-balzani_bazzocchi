using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Door;
using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace TestProject1.DoorTest.DoorTest
{
    public class DoorTest
    {
        readonly Name name = new Name("door");
        readonly Guid id = Guid.NewGuid();
        readonly PIN lockCode = new PIN("1234");
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
            Door newDoor = new Door(new PIN("1234"), name, id);
            newDoor.Lock();
            Assert.Throws<InvalidOperationException>(() => newDoor.Open());
        }

        [Fact]
        public void Lock_IfTheDoorIsCloseLock()
        {
            Door newDoor = new Door(new PIN("1234"), name, id);

            newDoor.Close();

            Assert.Equal(DeviceStatus.Close, newDoor.Status);
        }
        [Fact]
        public void Lock_IfTheDoorIsOpenDoNotLock()
        {
            Door newDoor = new Door(new PIN("1234"), name, id);
            newDoor.Open();
            Assert.Throws<InvalidOperationException>(() => newDoor.Lock());
        }

        [Fact]
        public void Unlock_IfTheCodeIsCorrectUnlock()
        {
            Door newDoor = new Door(new PIN("1234"), name, id);
            newDoor.Lock();
            newDoor.Unlock(new PIN("1234"));
            Assert.True(newDoor.Status == DeviceStatus.Unlock);
        }

        [Fact]
        public void Unlock_IfTheCodeIsIncorrectDoNotUnlock()
        {
            Door newDoor = new Door(new PIN("1234"), name, id);
            newDoor.Lock();
            newDoor.Unlock(new PIN("9994"));
            Assert.False(newDoor.Status == DeviceStatus.Unlock);
        }

        [Fact]
        public void SetNewUnlockCode_IfTheDoorIsOpenSetNewCode()
        {
            Door newDoor = new Door(new PIN("1234"), name, id);
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
            Door newDoor = new Door(new PIN("1234"), name, id);
            newDoor.Close();
            newDoor.Lock();
            newDoor.SetNewUnlockCode(new PIN("9994"));
            newDoor.Unlock(new PIN("9994"));
            Assert.False(newDoor.Status == DeviceStatus.Unlock);
        }
    }
}
