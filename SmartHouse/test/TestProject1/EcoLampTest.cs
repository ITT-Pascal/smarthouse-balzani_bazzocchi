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
            //Arrange
            EcoLamp newEcoLamp = new EcoLamp();

            //Assert
            Assert.False(newEcoLamp.IsLampOn());

        }

        [Fact]
        public void EcoLampTurnOnOff_WhenTheEcoLampIsOffTurnOn()
        {
            //Arrange
            EcoLamp newEcoLamp = new EcoLamp();

            //Act
            newEcoLamp.TurnOnOff();

            //Assert
            Assert.True(newEcoLamp.IsLampOn());

        }

        [Fact]
        public void EcoLampTurnOnOff_WhenTheEcoLampIsOnTurnOff()
        {
            //Arrange
            EcoLamp newEcoLamp = new EcoLamp();

            //Act
            newEcoLamp.TurnOnOff();
            newEcoLamp.TurnOnOff();


            //Assert
            Assert.False(newEcoLamp.IsLampOn());

        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIsNegative_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            EcoLamp newEcoLamp = new EcoLamp();

            //Act
            newEcoLamp.TurnOnOff();


            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newEcoLamp.ChangeBrightness(-1));


        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIsHigherThan0_BrightnessGetUpdated()
        {
            //Arrange
            EcoLamp newEcoLamp = new EcoLamp();

            //Act
            newEcoLamp.TurnOnOff();
            newEcoLamp.ChangeBrightness(10);

            //Assert
            Assert.Equal(10, newEcoLamp.Brightness);


        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIs0_BrightnessTurn0()
        {
            //Arrange
            EcoLamp newEcoLamp = new EcoLamp();

            //Act
            newEcoLamp.TurnOnOff();
            newEcoLamp.ChangeBrightness(0);

            //Assert
            Assert.Equal(0, newEcoLamp.Brightness);


        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenTheEcoLampIsOff_BrightnessIs0()
        {
            //Arrange
            EcoLamp newEcoLamp = new EcoLamp();

            //Act
            newEcoLamp.ChangeBrightness(0);

            //Assert
            Assert.Equal(0, newEcoLamp.Brightness);


        }

        [Fact]
        public void EcoLamp_ChangeBrightness_WhenBrightnessIsHigherThan100_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            EcoLamp newEcoLamp = new EcoLamp();

            //Act
            newEcoLamp.TurnOnOff();


            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newEcoLamp.ChangeBrightness(102));


        }

        [Fact]

        public void EcoLamp_AutoTurnOff_WhenTheLampIsOff_ThrowException()
        {
            //Arrange
            EcoLamp newEcoLamp = new EcoLamp();

            //Act
            Assert.Throws<InvalidOperationException>(() => newEcoLamp.AutoTurnOff());
        }

        [Fact]
        public void EcoLamp_AutoTurnOff_WhenTheLampIsOnFromMoreThan60Minutes_ReduceBrightness()
        {
            //Arrange
            
            DateTime _timeLampOn = DateTime.UtcNow.AddMinutes(-61);
            EcoLamp newEcoLamp = new EcoLamp(_timeLampOn);


            //Act
            newEcoLamp.ChangeBrightness(30);
            newEcoLamp.AutoTurnOff();

            //Assert
            Assert.Equal(15, newEcoLamp.Brightness);
            
        }
    }
}

