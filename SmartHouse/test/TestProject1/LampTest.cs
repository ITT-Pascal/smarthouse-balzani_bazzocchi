using BlaisePascal.SmartHouse.Domain;

namespace TestProject1
{
    public class LampTest
    {
        [Fact]
        public void Lamp_WhenCreatedTheLampIsOff()
        {
            //Arrange
            Lamp newLamp = new Lamp();

            //Assert
            Assert.False(newLamp.IsLampOn());

        }

        [Fact]
        public void EcoLamp_IsLampOn_WhenLampIsOn_ReturnTrue()
        {
            //Arrange
            Lamp newLamp = new Lamp();

            //Act
            newLamp.TurnOnOff();

            //Assert
            Assert.True(newLamp.IsOn);

        }

        [Fact]
        public void EcoLamp_IsLampOn_WhenLampIsOff_ReturnFalse()
        {
            //Arrange
            Lamp newLamp = new Lamp();

            //Act
            newLamp.TurnOnOff();
            newLamp.TurnOnOff();

            //Assert
            Assert.False(newLamp.IsOn);

        }

        [Fact]
        public void LampTurnOnOff_WhenTheLampIsOffTurnOn()
        {
            //Arrange
            Lamp newLamp = new Lamp();

            //Act
            newLamp.TurnOnOff();

            //Assert
            Assert.True(newLamp.IsLampOn());

        }
             
        [Fact]
        public void LampTurnOnOff_WhenTheLampIsOnTurnOff()
        {
            //Arrange
            Lamp newLamp = new Lamp();

            //Act
            newLamp.TurnOnOff();
            newLamp.TurnOnOff();


            //Assert
            Assert.False(newLamp.IsLampOn());

        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenBrightnessIsNegative_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            Lamp newLamp = new Lamp();

            //Act
            newLamp.TurnOnOff();
            

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.ChangeBrightness(-1));


        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenBrightnessIsHigherThan0_BrightnessGetUpdated()
        {
            //Arrange
            Lamp newLamp = new Lamp(8);

            //Act
            newLamp.TurnOnOff();
            newLamp.ChangeBrightness(10);

            //Assert
            Assert.Equal(10, newLamp.Brightness);


        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenBrightnessIs0_BrightnessTurn0()
        {
            //Arrange
            Lamp newLamp = new Lamp(8);

            //Act
            newLamp.TurnOnOff();
            newLamp.ChangeBrightness(0);

            //Assert
            Assert.Equal(0, newLamp.Brightness);


        }
        [Fact]
        public void Lamp_ChangeBrightness_WhenTheLampIsOff_ThrowInvalidOperationException()
        {
            //Arrange
            Lamp newLamp = new Lamp();



            //Assert
            Assert.Throws<InvalidOperationException>(() => newLamp.ChangeBrightness(3));


        }



        

        [Fact]
        public void Lamp_ChangeBrightness_WhenBrightnessIsHigherThan100_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            Lamp newLamp = new Lamp();

            //Act
            newLamp.TurnOnOff();


            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newLamp.ChangeBrightness(102));


        }

    }
}
