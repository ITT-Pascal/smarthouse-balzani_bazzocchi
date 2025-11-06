using BlaisePascal.SmartHouse.Domain;

namespace TestProject1;
public class TwoDeviceLampTest 
{
    [Fact]
    public void TurnOnOffLamp_WhenLampIsOffTurnOn()
    {   
        //Arrange
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        //Act
        newTwoDeviceLamp.TurnOnOffLamp();

        //Assert
        Assert.True(newTwoDeviceLamp.IsLampOn());
    }

    [Fact]
    public void TurnOnOffLamp_WhenLampIsOnTurnOff()
    {
        //Arrange
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        //Act
        newTwoDeviceLamp.TurnOnOffLamp();
        newTwoDeviceLamp.TurnOnOffLamp();

        //Assert
        Assert.False(newTwoDeviceLamp.IsLampOn());
    }

    [Fact]
    public void TurnOnOffEcoLamp_WhenEcoLampIsOffTurnOn()
    {
        //Arrange
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        //Act
        newTwoDeviceLamp.TurnOnOffEcoLamp();

        //Assert
        Assert.True(newTwoDeviceLamp.IsEcoLampOn());
    }

    [Fact]
    public void TurnOnOffEcoLamp_WhenEcoLampIsOnTurnOff()
    {
        //Arrange
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        //Act
        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.TurnOnOffEcoLamp();

        //Assert
        Assert.False(newTwoDeviceLamp.IsEcoLampOn());
    }

    [Fact]
    public void TurnOnOffBoth_WhenEcoLampAndLampAreOffTurnItsOn()
    {
        
    }



}
