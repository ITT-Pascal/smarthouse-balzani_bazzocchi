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
            string lampName = "";
            EcoLamp newEcoLamp = new EcoLamp(lampName);

            //Assert
            Assert.False(newEcoLamp.IsLampOn());
        }

        [Fact]
        public void EcoLamp_IsLampOn_WhenLampIsOn_ReturnTrue()
        {
            string lampName = "";
            EcoLamp newEcoLamp = new EcoLamp(lampName);

            //Act
            newEcoLamp.TurnOnOff();

            //Assert
            Assert.True(newEcoLamp.IsOn);
        }

        [Fact]
        public void EcoLamp_IsLampOn_WhenLampIsOff_ReturnFalse()
        {
            string lampName = "";
            EcoLamp newEcoLamp = new EcoLamp(lampName);

            //Act
            newEcoLamp.TurnOnOff();
            newEcoLamp.TurnOnOff();

            //Assert
            Assert.False(newEcoLamp.IsOn);
        }

        [Fact]
        public void EcoLampTurnOnOff_WhenTheEcoLampIsOffTurnOn()
        {
            string lampName = "";
            EcoLamp newEcoLamp = new EcoLamp(lampName);

            //Act
            newEcoLamp.TurnOnOff();

            //Assert
            Assert.True(newEcoLamp.IsLampOn());
        }

        [Fact]
        public void EcoLampTurnOnOff_WhenTheEcoLampIsOnTurnOff()
        {
            string lampName = "";
            EcoLamp newEcoLamp = new EcoLamp(lampName);

            //Act
            newEcoLamp.TurnOnOff();
            newEcoLamp.TurnOnOff();


            //Assert
            Assert.False(newEcoLamp.IsLampOn());
        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIsNegative_ThrowArgumentOutOfRangeException()
        {
            string lampName = "";
            EcoLamp newEcoLamp = new EcoLamp(lampName);

            //Act
            newEcoLamp.TurnOnOff();


            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newEcoLamp.ChangeBrightness(-1));
        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIsHigherThan0_BrightnessGetUpdated()
        {
            string lampName = "";
            EcoLamp newEcoLamp = new EcoLamp(lampName);

            //Act
            newEcoLamp.TurnOnOff();
            newEcoLamp.SetIntensity(10);

            //Assert
            Assert.Equal(10, newEcoLamp.Brightness);
        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIs0_BrightnessTurn0()
        {
            string lampName = "";
            EcoLamp newEcoLamp = new EcoLamp(lampName);

            //Act
            newEcoLamp.TurnOnOff();
            newEcoLamp.SetIntensity(0);

            //Assert
            Assert.Equal(0, newEcoLamp.Brightness);
        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenTheEcoLampIsOff_ThrowInvalidOperationException()
        {
            string lampName = "";
            EcoLamp newEcoLamp = new EcoLamp(lampName);

            //Assert
            Assert.Throws<InvalidOperationException>(() => newEcoLamp.ChangeBrightness(3)); 
        }


        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIsHigherThan100_ThrowArgumentOutOfRangeException()
        {
            string lampName = "";
            EcoLamp newEcoLamp = new EcoLamp(lampName);

            //Act
            newEcoLamp.TurnOnOff();


            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newEcoLamp.ChangeBrightness(102));
        }

        [Fact]

        public void EcoLamp_AutoTurnOff_WhenTheLampIsOff_ThrowException()
        {
            string lampName = "";
            EcoLamp newEcoLamp = new EcoLamp(lampName);

            //Act
            Assert.Throws<InvalidOperationException>(() => newEcoLamp.AutoTurnOff());
        }

        [Fact]
        public void EcoLamp_AutoTurnOff_WhenTheLampIsOnFromMoreThan60Minutes_ReduceBrightness()
        {
            string lampName = "";
            
            //Arrange            
            DateTime _timeLampOn = DateTime.UtcNow.AddMinutes(-61);
            Guid guid = Guid.NewGuid();
            EcoLamp newEcoLamp = new EcoLamp(_timeLampOn, guid, lampName);


            //Act
            newEcoLamp.SetIntensity(30);
            newEcoLamp.AutoTurnOff();

            //Assert
            Assert.Equal(15, newEcoLamp.Intensity);
            
        }

        [Fact]
        public void EcoLamp_AutoTurnOff_WhenTheLampIsOnFromMoreThan120Minutes_TurnLampOff()
        {
            //Arrange
            string lampName = "";
            DateTime _timeLampOn = DateTime.UtcNow.AddMinutes(-121);
            Guid guid = Guid.NewGuid();
            EcoLamp newEcoLamp = new EcoLamp(_timeLampOn, guid, lampName);


            //Act
            newEcoLamp.SetIntensity(30);
            newEcoLamp.AutoTurnOff();

            //Assert
            Assert.Equal(0, newEcoLamp.Brightness);
            Assert.False(newEcoLamp.IsLampOn());

        }
    }
}

