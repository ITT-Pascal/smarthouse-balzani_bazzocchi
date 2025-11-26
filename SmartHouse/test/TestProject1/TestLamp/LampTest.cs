using BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp;
using ImageProcessor.Processors;
using System;

namespace TestProject1.TestLamp.LampTest
{
    public class LampTest
    {

        [Fact]
        public void Lamp_WhenCreatedTheLampIsOff()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            Lamp newLamp = new Lamp(createdAtUtc, random, id);

            //Assert
            Assert.Equal(DeviceStatus.Off, newLamp.Status);

        }

        [Fact]
        public void EcoLamp_IsLampOn_WhenLampIsOn_ReturnTrue()
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
        public void LampTurnOnOff_WhenTheLampIsOffTurnOn()
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
        public void LampTurnOnOff_WhenTheLampIsOnTurnOff()
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
        public void Lamp_ChangeBrightness_WhenBrightnessIsNegative_ThrowArgumentOutOfRangeException()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            Lamp newLamp = new Lamp(createdAtUtc, random, id);

            //Act
            newLamp.TurnOnOff();
            

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetIntensity(-1));


        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenBrightnessIsHigherThan0_BrightnessGetUpdated()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            Lamp newLamp = new Lamp(createdAtUtc, random, id);

            //Act
            newLamp.TurnOnOff();
            newLamp.SetIntensity(10);

            //Assert
            Assert.Equal(10, newLamp.Intensity);


        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenBrightnessIs0_BrightnessTurn0()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            Lamp newLamp = new Lamp(createdAtUtc, random, id);

            //Act
            newLamp.TurnOnOff();
            newLamp.SetIntensity(0);

            //Assert
            Assert.Equal(0, newLamp.Intensity);


        }
        [Fact]
        public void Lamp_ChangeBrightness_WhenTheLampIsOff_ThrowInvalidOperationException()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            Lamp newLamp = new Lamp(createdAtUtc, random, id);



            //Assert
            Assert.Throws<InvalidOperationException>(() => newLamp.SetIntensity(3));


        }



        

        [Fact]
        public void Lamp_ChangeBrightness_WhenBrightnessIsHigherThan100_ThrowArgumentOutOfRangeException()
        {
            DateTime createdAtUtc = DateTime.UtcNow;
            Random random = new Random();
            Guid id = Guid.NewGuid();
            Lamp newLamp = new Lamp(createdAtUtc, random, id);

            //Act
            newLamp.TurnOnOff();


            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.SetIntensity(102));


        }

    }
}
