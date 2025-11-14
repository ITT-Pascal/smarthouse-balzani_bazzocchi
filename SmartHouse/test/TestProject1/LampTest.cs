using BlaisePascal.SmartHouse.Domain;
using ImageProcessor.Processors;
using System;

namespace TestProject1
{
    public class LampTest
    {

        [Fact]
        public void Lamp_WhenCreatedTheLampIsOff()
        {
            string lampName = "";
            //Arrange
            Lamp newLamp = new Lamp(lampName);

            //Assert
            Assert.False(newLamp.IsLampOn());

        }

        [Fact]
        public void EcoLamp_IsLampOn_WhenLampIsOn_ReturnTrue()
        {
            string lampName = "";
            //Arrange
            Lamp newLamp = new Lamp(lampName);

            //Act
            newLamp.TurnOnOff();

            //Assert
            Assert.True(newLamp.IsOn);

        }

        [Fact]
        public void EcoLamp_IsLampOn_WhenLampIsOff_ReturnFalse()
        {
            string lampName = "";
            //Arrange
            Lamp newLamp = new Lamp(lampName);

            //Act
            newLamp.TurnOnOff();
            newLamp.TurnOnOff();

            //Assert
            Assert.False(newLamp.IsOn);

        }

        [Fact]
        public void LampTurnOnOff_WhenTheLampIsOffTurnOn()
        {
            string lampName = "";
            //Arrange
            Lamp newLamp = new Lamp(lampName);

            //Act
            newLamp.TurnOnOff();

            //Assert
            Assert.True(newLamp.IsLampOn());

        }
             
        [Fact]
        public void LampTurnOnOff_WhenTheLampIsOnTurnOff()
        {
            string lampName = "";
            //Arrange
            Lamp newLamp = new Lamp(lampName);

            //Act
            newLamp.TurnOnOff();
            newLamp.TurnOnOff();


            //Assert
            Assert.False(newLamp.IsLampOn());

        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenBrightnessIsNegative_ThrowArgumentOutOfRangeException()
        {
            string lampName = "";
            //Arrange
            Lamp newLamp = new Lamp(lampName);

            //Act
            newLamp.TurnOnOff();
            

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.ChangeBrightness(-1));


        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenBrightnessIsHigherThan0_BrightnessGetUpdated()
        {
            string lampName = "";
            //Arrange
            Lamp newLamp = new Lamp(lampName);

            //Act
            newLamp.TurnOnOff();
            newLamp.ChangeBrightness(10);

            //Assert
            Assert.Equal(10, newLamp.Brightness);


        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenBrightnessIs0_BrightnessTurn0()
        {
            string lampName = "";
            //Arrange
            Lamp newLamp = new Lamp(lampName);

            //Act
            newLamp.TurnOnOff();
            newLamp.ChangeBrightness(0);

            //Assert
            Assert.Equal(0, newLamp.Brightness);


        }
        [Fact]
        public void Lamp_ChangeBrightness_WhenTheLampIsOff_ThrowInvalidOperationException()
        {
            string lampName = "";
            //Arrange
            Lamp newLamp = new Lamp(lampName);



            //Assert
            Assert.Throws<InvalidOperationException>(() => newLamp.ChangeBrightness(3));


        }



        

        [Fact]
        public void Lamp_ChangeBrightness_WhenBrightnessIsHigherThan100_ThrowArgumentOutOfRangeException()
        {
            string lampName = "";
            //Arrange
            Lamp newLamp = new Lamp(lampName);

            //Act
            newLamp.TurnOnOff();


            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.ChangeBrightness(102));


        }

    }
}
