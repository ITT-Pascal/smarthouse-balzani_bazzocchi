using BlaisePascal.SmartHouse.Domain.Electrodomestic;
using ImageProcessor.Processors;
using System;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.ElectrodomesticTest.TestLamp
{
    public class LampTest
    {
        readonly Guid id = Guid.NewGuid();
        readonly Name name = new Name("Pippo");

        [Fact]
        public void Lamp_WhenCreatedTheLampIsOff()
        {
            Lamp newLamp = new Lamp( name);
            //Assert
            Assert.Equal(DeviceStatus.Off, newLamp.Status);

        }
        [Fact]
        public void Lamp_SwitchOn_WhenLampIsOn_ReturnTrue()
        {
            Lamp newLamp = new Lamp( name);
            //Act
            newLamp.SwitchOn();
            //Assert
            Assert.Equal(DeviceStatus.On, newLamp.Status);
        }
        [Fact]
        public void Lamp_SwitchOff_WhenLampIsOff_ReturnFalse()
        {
            Lamp newLamp = new Lamp( name);

            //Act
            newLamp.SwitchOn();
            newLamp.SwitchOff();

            //Assert
            Assert.Equal(DeviceStatus.Off, newLamp.Status);

        }
        [Fact]
        public void Lamp_Toggle_WhenTheLampIsOffTurnOn()
        {
            Lamp newLamp = new Lamp( name);

            //Act
            newLamp.Toggle();

            //Assert
            Assert.Equal(DeviceStatus.On, newLamp.Status);

        }
        [Fact]
        public void Lamp_Toggle_WhenTheLampIsOnTurnOff()
        {
            Lamp newLamp = new Lamp( name);

            //Act
            newLamp.Toggle();
            newLamp.Toggle();


            //Assert
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }

        [Fact]
        public void Lamp_SetIntensity_WhenIntensityIsNegative_ThrowArgumentOutOfRangeException()
        {
            Lamp newLamp = new Lamp( name);
            //Act
            newLamp.Toggle();
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetIntensity(new Intensity(-1)));
        }

        [Fact]
        public void Lamp_SetIntensity_WhenNewIntensityIsHigherThan0_IntensityGetUpdated()
        {
            Lamp newLamp = new Lamp( name);
            //Act
            newLamp.Toggle();
            newLamp.SetIntensity(new Intensity(10));
            //Assert
            Assert.Equal(10, newLamp.Intensity.Value);
        }
        [Fact]
        public void Lamp_SetIntensity_WhenNewIntensityIs0_IntensityTurn0()
        {
            Lamp newLamp = new Lamp( name);
            //Act
            newLamp.Toggle();
            newLamp.SetIntensity(new Intensity(0));
            //Assert
            Assert.Equal(0, newLamp.Intensity.Value);
        }
        [Fact]
        public void Lamp_ChangeBrightness_WhenTheLampIsOff_ThrowInvalidOperationException()
        {
            Lamp newLamp = new Lamp( name);
            //Assert
            Assert.Throws<InvalidOperationException>(() => newLamp.SetIntensity(new Intensity(3)));
        }
        [Fact]
        public void Lamp_SetIntensity_WhenIntensityIsHigherThan100_ThrowArgumentOutOfRangeException()
        {
            Lamp newLamp = new Lamp( name);
            //Act
            newLamp.Toggle();
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetIntensity(new Intensity(102)));
        }
    }
}
