using BlaisePascal.SmartHouse.Domain.Electrodomestic;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.ElectrodomesticTest.TestLamp;
public class TwoDeviceLampTest // prova
{
    readonly Name lampName = new Name("lamp");
    readonly Name ecoName = new Name("ecolamp");
    readonly Name twoName = new Name("twoName");
    [Fact]
    public void ToggleLamp_WhenLampIsOffTurnOn()
    {
        //Arrange
        Lamp newLamp = new Lamp( lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);
        //Act
        newTwoDeviceLamp.ToggleLamp();
        //Assert
        Assert.Equal(DeviceStatus.On, newLamp.Status);
    }
    [Fact]
    public void TurnOnOffLamp_WhenLampIsOnTurnOff()
    {
        Lamp newLamp = new Lamp(lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);

        //Act
        newTwoDeviceLamp.Toggle();
        newTwoDeviceLamp.Toggle();

        //Assert
        Assert.Equal(DeviceStatus.Off, newLamp.Status);
    }
    [Fact]
    public void TurnOnOffEcoLamp_WhenEcoLampIsOffTurnOn()
    {
        Lamp newLamp = new Lamp( lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);

        //Act
        newTwoDeviceLamp.ToggleEco();

        //Assert
        Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
    }
    [Fact]
    public void TurnOnOffEcoLamp_WhenEcoLampIsOnTurnOff()
    {
        Lamp newLamp = new Lamp(lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);

        //Act
        newTwoDeviceLamp.ToggleEco();
        newTwoDeviceLamp.ToggleEco();

        //Assert
        Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
    }
    [Fact]
    public void TurnOnOffBoth_WhenEcoLampAndLampAreOffTurnItsOn()
    {
        Lamp newLamp = new Lamp( lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);

        newTwoDeviceLamp.ToggleBoth();

        Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
        Assert.Equal(DeviceStatus.On, newLamp.Status);
    }
    [Fact]
    public void TurnOffBoth_WhenEcoLampIsOnAndLampIsOffTurnEcoLampOffAndTurnLampOn()
    {
        Lamp newLamp = new Lamp(lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);
        newTwoDeviceLamp.ToggleEco();
        newTwoDeviceLamp.ToggleBoth();

        Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        Assert.Equal(DeviceStatus.On, newLamp.Status);
    }
    [Fact]
    public void ToggleBoth_WhenEcoLampIsOffAndLampIsOnTurnEcoLampOnAndTurnLampOff()
    {
        Lamp newLamp = new Lamp( lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);
        newTwoDeviceLamp.ToggleLamp();
        newTwoDeviceLamp.ToggleBoth();

        Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
        Assert.Equal(DeviceStatus.Off, newLamp.Status);
    }
    [Fact]
    public void ToggleBoth_WhenEcoLampAndLampAreOnTurnOff()
    {
        Lamp newLamp = new Lamp( lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);
        newTwoDeviceLamp.ToggleEco();
        newTwoDeviceLamp.ToggleLamp();
        newTwoDeviceLamp.ToggleBoth();

        Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        Assert.Equal(DeviceStatus.Off, newLamp.Status);
    }
    [Fact]
    public void ChangeEcoLampIntensity_WhenChangeTheEcoLampBrightnessTo17_ThenTheEcoLampBrightnessIs17()
    {
        Lamp newLamp = new Lamp( lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);

        newTwoDeviceLamp.ToggleEco();
        newTwoDeviceLamp.SetEcoLampIntensity(new Intensity(17));

        Assert.Equal(17, newTwoDeviceLamp.EcoLamp.Intensity.Value);
    }
    [Fact]
    public void ChangeEcoLampIntensity_WhenEcoLampBrightnessIsOver100_ThrowArgumentOutOfRangeException()
    {
        //Arrange
        Lamp newLamp = new Lamp( lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);
        //Act
        newTwoDeviceLamp.ToggleEco();
        newTwoDeviceLamp.Toggle();
        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => newTwoDeviceLamp.EcoLamp.SetIntensity(new Intensity(102)));
    }
    [Fact]
    public void ChangeLampBrightness_WhenEcoLampIsOff_ThrowInvalidOperationException()
    {
        //Arrange
        DateTime createdAtUtc = DateTime.UtcNow;
        Lamp newLamp = new Lamp( lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);
        //Act
        newTwoDeviceLamp.Toggle();

        //Assert
        Assert.Throws<InvalidOperationException>(() => newTwoDeviceLamp.EcoLamp.SetIntensity(new Intensity(4)));
    }
    [Fact]
    public void ChangeLampBrightness_WhenLampBrightnessIsOver100_ThrowArgumentOutOfRangeException()
    {
        //Arrange
        Lamp newLamp = new Lamp( lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);
        //Act
        newTwoDeviceLamp.ToggleEco();
        newTwoDeviceLamp.ToggleLamp();
        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => newTwoDeviceLamp.SetLampIntensity(new Intensity(102)));
    }
    [Fact]
    public void SetLampIntensity_WhenChangeTheLampBrightnessTo3_ThenTheLampBrightnessIs3()
    {
        Lamp newLamp = new Lamp( lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);
        newTwoDeviceLamp.ToggleLamp();
        newTwoDeviceLamp.SetLampIntensity(new Intensity(3));

        Assert.Equal(3, newTwoDeviceLamp.Lamp.Intensity.Value);
    }
    [Fact]
    public void SetLampIntensity_WhenLampIsOff_ThrowInvalidOperationException()
    {
        //Arrange
        Lamp newLamp = new Lamp(lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);
        //Act
        newTwoDeviceLamp.ToggleEco();
        //Assert
        Assert.Throws<InvalidOperationException>(() => newTwoDeviceLamp.Lamp.SetIntensity(new Intensity(4)));
    }
    [Fact]
    public void SetBothIntensity_WhenChangeEcoLamp_AndLampBrightnessTo20_EcoLampAndLampBrightnessIs20()
    {
        Lamp newLamp = new Lamp( lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp);

        newTwoDeviceLamp.ToggleLamp();
        newTwoDeviceLamp.ToggleEco();
        newTwoDeviceLamp.SetBothIntensity(new Intensity(20));

        Assert.Equal(20, newTwoDeviceLamp.Lamp.Intensity.Value);
        Assert.Equal(20, newTwoDeviceLamp.EcoLamp.Intensity.Value);
    }
}
