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
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        newTwoDeviceLamp.TurnOnOffBoth();

        Assert.True(newTwoDeviceLamp.IsEcoLampOn());
        Assert.True(newTwoDeviceLamp.IsLampOn());
    }

    [Fact]
    public void TurnOffBoth_WhenEcoLampIsOnAndLampIsOffTurnEcoLampOffAndTurnLampOn()
    {
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.TurnOnOffBoth();

        Assert.False(newTwoDeviceLamp.IsEcoLampOn());
        Assert.True(newTwoDeviceLamp.IsLampOn());
    }

    [Fact]
    public void TurnOffBoth_WhenEcoLampIsOffAndLampIsOnTurnEcoLampOnAndTurnLampOff()
    {
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        newTwoDeviceLamp.TurnOnOffLamp();
        newTwoDeviceLamp.TurnOnOffBoth();

        Assert.True(newTwoDeviceLamp.IsEcoLampOn());
        Assert.False(newTwoDeviceLamp.IsLampOn());
    }

    [Fact]
    public void TurnOnOffBoth_WhenEcoLampAndLampAreOnTurnItsOff()
    {
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.TurnOnOffLamp();
        newTwoDeviceLamp.TurnOnOffBoth();

        Assert.False(newTwoDeviceLamp.IsEcoLampOn());
        Assert.False(newTwoDeviceLamp.IsLampOn());
    }

    [Fact]
    public void ChangeEcoLampBrightness_IfYouChangeTheEcoLampBrightnessTo17ThenTheEcoLampBrightnessIsAt17()
    {
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.ChangeEcoLampBrightness(17);

        Assert.Equal(17, newTwoDeviceLamp._ecoLamp.Brightness);
    }

    [Fact]
    public void ChangeLampBrightness_IfYouChangeTheLampBrightnessTo3ThenTheLampBrightnessIsAt3()
    {
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        newTwoDeviceLamp.TurnOnOffLamp();
        newTwoDeviceLamp.ChangeLampBrightness(3);

        Assert.Equal(3, newTwoDeviceLamp._lamp.Brightness);
    }

    [Fact]
    public void ChangeEcoLampAndLampBrightness_IfYouChangeEcoLampAndLampBrightnessTo20ThenEcoLampAndLampBrightnessIsAt20()
    {
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        newTwoDeviceLamp.TurnOnOffLamp();
        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.ChangeEcoLampAndLampBrightness(20);

        Assert.Equal(20, newTwoDeviceLamp._lamp.Brightness);
        Assert.Equal(20, newTwoDeviceLamp._ecoLamp.Brightness);
    }




}
