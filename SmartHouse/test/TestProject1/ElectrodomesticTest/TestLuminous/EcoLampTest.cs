using BlaisePascal.SmartHouse.Domain.Electrodomestic;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.ElectrodomesticTest.TestLamp
{
    public class EcoLampTest
    {
        readonly Guid id = Guid.NewGuid();
        readonly Name name = new Name("Pippo");
        [Fact]
        public void EcoLamp_WhenCreatedTheEcoLampIsOff()
        {
            EcoLamp newEcoLamp = new EcoLamp(name);
            //Assert
            Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        }
        [Fact]
        public void EcoLamp_SwitchOn_WhenLampIsOn_ReturnTrue()
        {
            EcoLamp newEcoLamp = new EcoLamp(name);
            //Act
            newEcoLamp.SwitchOn();
            //Assert
            Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
        }

        [Fact]
        public void EcoLamp_SwitchOff_WhenLampIsOff_ReturnFalse()
        {
            EcoLamp newEcoLamp = new EcoLamp(name);
            //Act
            newEcoLamp.SwitchOn();
            newEcoLamp.SwitchOff();

            //Assert
            Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        }

        [Fact]
        public void EcoLampTurnOnOff_WhenTheEcoLampIsOffTurnOn()
        {
            EcoLamp newEcoLamp = new EcoLamp(name);
            //Act
            newEcoLamp.Toggle();
            //Assert
            Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
        }

        [Fact]
        public void EcoLampTurnOnOff_WhenTheEcoLampIsOnTurnOff()
        {
            EcoLamp newEcoLamp = new EcoLamp(name);
            //Act
            newEcoLamp.Toggle();
            newEcoLamp.Toggle();
            //Assert
            Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIsNegative_ThrowArgumentOutOfRangeException()
        {
            EcoLamp newEcoLamp = new EcoLamp(name);
            //Act
            newEcoLamp.Toggle();
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newEcoLamp.SetIntensity(new Intensity(-1)));
        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIsHigherThan0_BrightnessGetUpdated()
        {
            EcoLamp newEcoLamp = new EcoLamp(name);

            //Act
            newEcoLamp.Toggle();
            newEcoLamp.SetIntensity(new Intensity(10));

            //Assert
            Assert.Equal(10, newEcoLamp.Intensity.Value);
        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIs0_BrightnessTurn0()
        {
            EcoLamp newEcoLamp = new EcoLamp(name);
            //Act
            newEcoLamp.Toggle();
            newEcoLamp.SetIntensity(new Intensity(0));
            //Assert
            Assert.Equal(0, newEcoLamp.Intensity.Value);
        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenTheEcoLampIsOff_ThrowInvalidOperationException()
        {
            EcoLamp newEcoLamp = new EcoLamp(name);
            //Assert
            Assert.Throws<InvalidOperationException>(() => newEcoLamp.SetIntensity(new Intensity(3))); 
        }


        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIsHigherThan100_ThrowArgumentOutOfRangeException()
        {
            EcoLamp newEcoLamp = new EcoLamp(name);
            //Act
            newEcoLamp.Toggle();
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newEcoLamp.SetIntensity(new Intensity(102)));
        }

        [Fact]

        public void EcoLamp_AutoTurnOff_WhenTheLampIsOff_ThrowException()
        {
            EcoLamp newEcoLamp = new EcoLamp(name);
            //Act
            Assert.Throws<InvalidOperationException>(() => newEcoLamp.AutoTurnOff());
        }
    }
}

