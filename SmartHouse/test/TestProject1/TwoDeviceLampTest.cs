using BlaisePascal.SmartHouse.Domain;

namespace TestProject1;
public class TwoDeviceLampTest
{
    [Fact]
    public void TurnOnOffLamp_WhenLampIsOffTurnOn()
    {
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        newTwoDeviceLamp.TurnOnOffLamp();

        Assert.True(newTwoDeviceLamp.IsLampOn());
    }

    [Fact]
    public void TurnOnOffLamp_WhenLampIsOnTurnOff()
    {
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        newTwoDeviceLamp.TurnOnOffLamp();
        newTwoDeviceLamp.TurnOnOffLamp();

        Assert.False(newTwoDeviceLamp.IsLampOn());
    }

    [Fact]
    public void TurnOnOffEcoLamp_WhenEcoLampIsOffTurnOn()
    {
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        newTwoDeviceLamp.TurnOnOffEcoLamp();

        Assert.True(newTwoDeviceLamp.IsEcoLampOn());
    }

    [Fact]
    public void TurnOnOffEcoLamp_WhenEcoLampIsOnTurnOff()
    {
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp();

        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.TurnOnOffEcoLamp();

        Assert.False(newTwoDeviceLamp.IsEcoLampOn());
    }

    [Fact]
    public void TurnOnOffBoth_WhenEcoLampAndLampAreOffTurnItsOn()
    {
        
    }



}
