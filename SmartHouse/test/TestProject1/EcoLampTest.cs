using BlaisePascal.SmartHouse.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class EcoLampTest
    {

        [Fact]
        public void EcoLamp_WhenCreatedTheEcoLampIsOff()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

            //Assert
            Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        }

        [Fact]
        public void EcoLamp_IsLampOn_WhenLampIsOn_ReturnTrue()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

            //Act
            newEcoLamp.TurnOnOff();

            //Assert
            Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
        }

        [Fact]
        public void EcoLamp_IsLampOn_WhenLampIsOff_ReturnFalse()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            Lamp newLamp = new Lamp(createdAtUtc, random, id);

            //Act
            newLamp.TurnOnOff();
            newLamp.TurnOnOff();

            //Assert
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }

        [Fact]
        public void EcoLampTurnOnOff_WhenTheEcoLampIsOffTurnOn()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            Lamp newLamp = new Lamp(createdAtUtc, random, id);

            //Act
            newLamp.TurnOnOff();

            //Assert
            Assert.Equal(DeviceStatus.On, newLamp.Status);
        }

        [Fact]
        public void EcoLampTurnOnOff_WhenTheEcoLampIsOnTurnOff()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

            //Act
            newEcoLamp.TurnOnOff();
            newEcoLamp.TurnOnOff();


            //Assert
            Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIsNegative_ThrowArgumentOutOfRangeException()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

            //Act
            newEcoLamp.TurnOnOff();


            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newEcoLamp.SetIntensity(-1));
        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIsHigherThan0_BrightnessGetUpdated()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

            //Act
            newEcoLamp.TurnOnOff();
            newEcoLamp.SetIntensity(10);

            //Assert
            Assert.Equal(10, newEcoLamp.Intensity);
        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIs0_BrightnessTurn0()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

            //Act
            newEcoLamp.TurnOnOff();
            newEcoLamp.SetIntensity(0);

            //Assert
            Assert.Equal(0, newEcoLamp.Intensity);
        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenTheEcoLampIsOff_ThrowInvalidOperationException()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

            //Assert
            Assert.Throws<InvalidOperationException>(() => newEcoLamp.SetIntensity(3)); 
        }


        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIsHigherThan100_ThrowArgumentOutOfRangeException()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

            //Act
            newEcoLamp.TurnOnOff();


            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newEcoLamp.SetIntensity(102));
        }

        [Fact]

        public void EcoLamp_AutoTurnOff_WhenTheLampIsOff_ThrowException()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

            //Act
            Assert.Throws<InvalidOperationException>(() => newEcoLamp.AutoTurnOff());
        }

        [Fact]
        public void EcoLamp_AutoTurnOff_WhenTheLampIsOnFromMoreThan60Minutes_ReduceBrightness()
        {
            Random random = new Random();
            Guid id = Guid.NewGuid();         
            DateTime _timeLampOn = DateTime.UtcNow.AddMinutes(-61);
            Guid guid = Guid.NewGuid();
            EcoLamp newEcoLamp = new EcoLamp(_timeLampOn, random, id);


            //Act
            newEcoLamp.TurnOnOff();
            newEcoLamp.SetIntensity(30);
            newEcoLamp.AutoTurnOff();

            //Assert
            Assert.Equal(15, newEcoLamp.Intensity);
            
        }

        [Fact]
        public void EcoLamp_AutoTurnOff_WhenTheLampIsOnFromMoreThan120Minutes_TurnLampOff()
        {
            //Arrange
            Random random = new Random();
            Guid id = Guid.NewGuid();
            DateTime _timeLampOn = DateTime.UtcNow.AddMinutes(-121);
            Guid guid = Guid.NewGuid();
            EcoLamp newEcoLamp = new EcoLamp(_timeLampOn, random, id);


            //Act
            newEcoLamp.TurnOnOff();
            newEcoLamp.SetIntensity(30);
            newEcoLamp.AutoTurnOff();

            //Assert
            Assert.Equal(0, newEcoLamp.Intensity);
            Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);

        }
    }
}

