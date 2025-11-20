using BlaisePascal.SmartHouse.Domain;

namespace TestProject1;
public class TwoDeviceLampTest // prova
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
    public void ChangeEcoLampBrightness_WhenChangeTheEcoLampBrightnessTo17_ThenTheEcoLampBrightnessIs17()
    {
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.ChangeEcoLampBrightness(17);

        Assert.Equal(17, newTwoDeviceLamp.EcoLamp.Intensity);
    }

    [Fact]
    public void ChangeLampBrightness_WhenEcoLampBrightnessIsOver100_ThrowArgumentOutOfRangeException()
    {
        //Arrange
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        //Act
        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.TurnOnOffLamp();
        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => newTwoDeviceLamp.EcoLamp.SetIntensity(102));
    }

    [Fact]
    public void ChangeLampBrightness_WhenEcoLampIsOff_ThrowInvalidOperationException()
    {
        //Arrange
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        //Act
        newTwoDeviceLamp.TurnOnOffLamp();

        //Assert
        Assert.Throws<InvalidOperationException>(() => newTwoDeviceLamp.EcoLamp.SetIntensity(4));
    }

    [Fact]
    public void ChangeLampBrightness_WhenLampBrightnessIsOver100_ThrowArgumentOutOfRangeException()
    {
        //Arrange
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        //Act
        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.TurnOnOffLamp();
        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => newTwoDeviceLamp.Lamp.SetIntensity(102));
    }

    [Fact]
    public void ChangeLampBrightness_WhenChangeTheLampBrightnessTo3_ThenTheLampBrightnessIs3()
    {
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        newTwoDeviceLamp.TurnOnOffLamp();
        newTwoDeviceLamp.ChangeLampBrightness(3);

        Assert.Equal(3, newTwoDeviceLamp.Lamp.Intensity);
    }

    [Fact]
    public void ChangeLampBrightness_WhenLampIsOff_ThrowInvalidOperationException()
    {
        //Arrange
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        //Act
        newTwoDeviceLamp.TurnOnOffEcoLamp();

        //Assert
        Assert.Throws<InvalidOperationException>(() => newTwoDeviceLamp.Lamp.SetIntensity(4));
    }

    [Fact]
    public void ChangeEcoLampAndLampBrightness_WhenChangeEcoLamp_AndLampBrightnessTo20_EcoLampAndLampBrightnessIs20()
    {
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        newTwoDeviceLamp.TurnOnOffLamp();
        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.ChangeEcoLampAndLampBrightness(20);

        Assert.Equal(20, newTwoDeviceLamp.Lamp.Intensity);
        Assert.Equal(20, newTwoDeviceLamp.EcoLamp.Intensity);
    }

    
  




}
