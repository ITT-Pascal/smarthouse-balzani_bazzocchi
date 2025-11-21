using BlaisePascal.SmartHouse.Domain.Lamp;

namespace TestProject1;
public class TwoDeviceLampTest // prova
{
    [Fact]
    public void TurnOnOffLamp_WhenLampIsOffTurnOn()
    {
        //Arrange
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);

        //Act
        newTwoDeviceLamp.TurnOnOffLamp();

        //Assert
        Assert.Equal(DeviceStatus.On, newLamp.Status);
    }

    [Fact]
    public void TurnOnOffLamp_WhenLampIsOnTurnOff()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);

        //Act
        newTwoDeviceLamp.TurnOnOffLamp();
        newTwoDeviceLamp.TurnOnOffLamp();

        //Assert
        Assert.Equal(DeviceStatus.Off, newLamp.Status);
    }

    [Fact]
    public void TurnOnOffEcoLamp_WhenEcoLampIsOffTurnOn()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);

        //Act
        newTwoDeviceLamp.TurnOnOffEcoLamp();

        //Assert
        Assert.Equal(DeviceStatus.On, newLamp.Status);
    }

    [Fact]
    public void TurnOnOffEcoLamp_WhenEcoLampIsOnTurnOff()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);

        //Act
        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.TurnOnOffEcoLamp();

        //Assert
        Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
    }

    [Fact]
    public void TurnOnOffBoth_WhenEcoLampAndLampAreOffTurnItsOn()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);

        newTwoDeviceLamp.TurnOnOffBoth();

        Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
        Assert.Equal(DeviceStatus.On, newLamp.Status);
    }

    [Fact]
    public void TurnOffBoth_WhenEcoLampIsOnAndLampIsOffTurnEcoLampOffAndTurnLampOn()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);

        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.TurnOnOffBoth();

        Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        Assert.Equal(DeviceStatus.On, newLamp.Status);
    }

    [Fact]
    public void TurnOffBoth_WhenEcoLampIsOffAndLampIsOnTurnEcoLampOnAndTurnLampOff()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);

        newTwoDeviceLamp.TurnOnOffLamp();
        newTwoDeviceLamp.TurnOnOffBoth();

        Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
        Assert.Equal(DeviceStatus.Off, newLamp.Status);
    }

    [Fact]
    public void TurnOnOffBoth_WhenEcoLampAndLampAreOnTurnItsOff()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);

        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.TurnOnOffLamp();
        newTwoDeviceLamp.TurnOnOffBoth();

        Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        Assert.Equal(DeviceStatus.Off, newLamp.Status);
    }

    [Fact]
    public void ChangeEcoLampBrightness_WhenChangeTheEcoLampBrightnessTo17_ThenTheEcoLampBrightnessIs17()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);

        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.ChangeEcoLampBrightness(17);

        Assert.Equal(17, newTwoDeviceLamp.EcoLamp.Intensity);
    }

    [Fact]
    public void ChangeLampBrightness_WhenEcoLampBrightnessIsOver100_ThrowArgumentOutOfRangeException()
    {
        //Arrange
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);

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
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);

        //Act
        newTwoDeviceLamp.TurnOnOffLamp();

        //Assert
        Assert.Throws<InvalidOperationException>(() => newTwoDeviceLamp.EcoLamp.SetIntensity(4));
    }

    [Fact]
    public void ChangeLampBrightness_WhenLampBrightnessIsOver100_ThrowArgumentOutOfRangeException()
    {
        //Arrange
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);

        //Act
        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.TurnOnOffLamp();
        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => newTwoDeviceLamp.Lamp.SetIntensity(102));
    }

    [Fact]
    public void ChangeLampBrightness_WhenChangeTheLampBrightnessTo3_ThenTheLampBrightnessIs3()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);

        newTwoDeviceLamp.TurnOnOffLamp();
        newTwoDeviceLamp.ChangeLampBrightness(3);

        Assert.Equal(3, newTwoDeviceLamp.Lamp.Intensity);
    }

    [Fact]
    public void ChangeLampBrightness_WhenLampIsOff_ThrowInvalidOperationException()
    {
        //Arrange
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);
        //Act
        newTwoDeviceLamp.TurnOnOffEcoLamp();

        //Assert
        Assert.Throws<InvalidOperationException>(() => newTwoDeviceLamp.Lamp.SetIntensity(4));
    }

    [Fact]
    public void ChangeEcoLampAndLampBrightness_WhenChangeEcoLamp_AndLampBrightnessTo20_EcoLampAndLampBrightnessIs20()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);
        TwoDeviceLamp newTwoDeviceLamp = new TwoDeviceLamp(newLamp, newEcoLamp);

        newTwoDeviceLamp.TurnOnOffLamp();
        newTwoDeviceLamp.TurnOnOffEcoLamp();
        newTwoDeviceLamp.ChangeEcoLampAndLampBrightness(20);

        Assert.Equal(20, newTwoDeviceLamp.Lamp.Intensity);
        Assert.Equal(20, newTwoDeviceLamp.EcoLamp.Intensity);
    }

    
  




}
