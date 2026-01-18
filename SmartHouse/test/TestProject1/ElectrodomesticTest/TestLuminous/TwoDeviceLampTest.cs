using BlaisePascal.SmartHouse.Domain.Electrodomestic;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.ElectrodomesticTest.TestLamp;
public class TwoDeviceLampTest // prova
{
    Guid idL = Guid.NewGuid();
    Guid idE = Guid.NewGuid();
    Guid idTwo = Guid.NewGuid();
    string lampName = "lamp";
    string ecoName = "ecolamp";
    string twoName = "twoName";
    [Fact]
    public void ToggleLamp_WhenLampIsOffTurnOn()
    {
        //Arrange
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);
        //Act
        newTwoDeviceLamp.ToggleLamp();
        //Assert
        Assert.Equal(DeviceStatus.On, newLamp.Status);
    }
    [Fact]
    public void TurnOnOffLamp_WhenLampIsOnTurnOff()
    {
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);

        //Act
        newTwoDeviceLamp.Toggle();
        newTwoDeviceLamp.Toggle();

        //Assert
        Assert.Equal(DeviceStatus.Off, newLamp.Status);
    }
    [Fact]
    public void TurnOnOffEcoLamp_WhenEcoLampIsOffTurnOn()
    {
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);

        //Act
        newTwoDeviceLamp.ToggleEco();

        //Assert
        Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
    }
    [Fact]
    public void TurnOnOffEcoLamp_WhenEcoLampIsOnTurnOff()
    {
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);

        //Act
        newTwoDeviceLamp.ToggleEco();
        newTwoDeviceLamp.ToggleEco();

        //Assert
        Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
    }
    [Fact]
    public void TurnOnOffBoth_WhenEcoLampAndLampAreOffTurnItsOn()
    {
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);

        newTwoDeviceLamp.ToggleBoth();

        Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
        Assert.Equal(DeviceStatus.On, newLamp.Status);
    }
    [Fact]
    public void TurnOffBoth_WhenEcoLampIsOnAndLampIsOffTurnEcoLampOffAndTurnLampOn()
    {
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);
        newTwoDeviceLamp.ToggleEco();
        newTwoDeviceLamp.ToggleBoth();

        Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        Assert.Equal(DeviceStatus.On, newLamp.Status);
    }
    [Fact]
    public void ToggleBoth_WhenEcoLampIsOffAndLampIsOnTurnEcoLampOnAndTurnLampOff()
    {
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);
        newTwoDeviceLamp.ToggleLamp();
        newTwoDeviceLamp.ToggleBoth();

        Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
        Assert.Equal(DeviceStatus.Off, newLamp.Status);
    }
    [Fact]
    public void ToggleBoth_WhenEcoLampAndLampAreOnTurnOff()
    {
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);
        newTwoDeviceLamp.ToggleEco();
        newTwoDeviceLamp.ToggleLamp();
        newTwoDeviceLamp.ToggleBoth();

        Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        Assert.Equal(DeviceStatus.Off, newLamp.Status);
    }
    [Fact]
    public void ChangeEcoLampIntensity_WhenChangeTheEcoLampBrightnessTo17_ThenTheEcoLampBrightnessIs17()
    {
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);

        newTwoDeviceLamp.ToggleEco();
        newTwoDeviceLamp.SetEcoLampIntensity(17);

        Assert.Equal(17, newTwoDeviceLamp.EcoLamp.Intensity);
    }
    [Fact]
    public void ChangeEcoLampIntensity_WhenEcoLampBrightnessIsOver100_ThrowArgumentOutOfRangeException()
    {
        //Arrange
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);
        //Act
        newTwoDeviceLamp.ToggleEco();
        newTwoDeviceLamp.Toggle();
        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => newTwoDeviceLamp.EcoLamp.SetIntensity(102));
    }
    [Fact]
    public void ChangeLampBrightness_WhenEcoLampIsOff_ThrowInvalidOperationException()
    {
        //Arrange
        DateTime createdAtUtc = DateTime.UtcNow;
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);
        //Act
        newTwoDeviceLamp.Toggle();

        //Assert
        Assert.Throws<InvalidOperationException>(() => newTwoDeviceLamp.EcoLamp.SetIntensity(4));
    }
    [Fact]
    public void ChangeLampBrightness_WhenLampBrightnessIsOver100_ThrowArgumentOutOfRangeException()
    {
        //Arrange
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);
        //Act
        newTwoDeviceLamp.ToggleEco();
        newTwoDeviceLamp.Toggle();
        //Assert
        Assert.Throws<InvalidOperationException>(() => newTwoDeviceLamp.SetLampIntensity(102));
    }
    [Fact]
    public void SetLampIntensity_WhenChangeTheLampBrightnessTo3_ThenTheLampBrightnessIs3()
    {
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);
        newTwoDeviceLamp.ToggleLamp();
        newTwoDeviceLamp.SetLampIntensity(3);

        Assert.Equal(3, newTwoDeviceLamp.Lamp.Intensity);
    }
    [Fact]
    public void SetLampIntensity_WhenLampIsOff_ThrowInvalidOperationException()
    {
        //Arrange
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);
        //Act
        newTwoDeviceLamp.ToggleEco();
        //Assert
        Assert.Throws<InvalidOperationException>(() => newTwoDeviceLamp.Lamp.SetIntensity(4));
    }
    [Fact]
    public void SetBothIntensity_WhenChangeEcoLamp_AndLampBrightnessTo20_EcoLampAndLampBrightnessIs20()
    {
        Lamp newLamp = new Lamp(idL, lampName);
        EcoLamp newEcoLamp = new EcoLamp(ecoName, idE);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(twoName, newLamp, newEcoLamp, idTwo);

        newTwoDeviceLamp.ToggleLamp();
        newTwoDeviceLamp.ToggleEco();
        newTwoDeviceLamp.SetBothIntensity(20);

        Assert.Equal(20, newTwoDeviceLamp.Lamp.Intensity);
        Assert.Equal(20, newTwoDeviceLamp.EcoLamp.Intensity);
    }
}
