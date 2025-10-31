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
            Assert.False(newLamp.IsOn());

        }

        [Fact]
        public void LampTurnOnOff_WhenTheLampIsOffTurnOn()
        {
            //Arrange
            Lamp newLamp = new Lamp();

            //Act
            newLamp.TurnOnOff();

            //Assert
            Assert.True(newLamp.IsOn());

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
            Assert.False(newLamp.IsOn());

        }

        [Fact]
        public void Lamp_ChangeBrightness_WhenBrightnessIsLowerThan0_BrightnessIs0()
        {
            //Arrange
            Lamp newLamp = new Lamp();

            //Act
            newLamp.ChangeBrightness(-1);

            //
            Assert.Equal()


        }
    }
}
