using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Door;
using BlaisePascal.SmartHouse.Domain;

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
        public void Open_IfTheDoorIsLockedNoOpen()
        {
            Door newDoor = new Door(123);

            newDoor.Lock();
            newDoor.Open();

            Assert.Equal(DeviceStatus.Close, newDoor.Status);
        }

        [Fact]
        public void Lock_IfTheDoorIsCloseLock()
        {
            Door newDoor = new Door();

        }
    }
}
