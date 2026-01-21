using BlaisePascal.SmartHouse.Domain.Electrodomestic;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.ElectrodomesticTest.TestLamp;

public class LampsRowTest
{
    readonly string name = "pippo";
    readonly Guid id = Guid.NewGuid();
    readonly Guid idLamp = Guid.NewGuid();
    readonly string nameLamp = "name";
    readonly Lamp lamp1 = new Lamp(Guid.NewGuid(), "lamp1");
    readonly Lamp lamp2 = new Lamp(Guid.NewGuid(), "lamp2");
    readonly AbstractLamp ecoLamp1 = new EcoLamp("ecoLamp1", Guid.NewGuid());
    readonly EcoLamp ecoLamp2 = new EcoLamp("ecoLamp2", Guid.NewGuid());
    //Add/Remove Lamp Tests
    [Fact]
    public void AddLamp_WhenAddLampAddProperly()
    {
        LampsRow lampsRow = new LampsRow(name, id);
        lampsRow.AddLamp(lamp1);
        Assert.IsType<Lamp>(lampsRow.lamps[0]); // new nel costruttore nuovo.
    }
    [Fact]
    public void AddEcoLamp_WhenAddEcoLamp()
    {
        LampsRow lampsRow = new LampsRow(name, id);
        lampsRow.AddEcoLamp(ecoLamp1);
        Assert.IsType<EcoLamp>(lampsRow.lamps[0]);
    }
    [Fact]
    public void AddLampInPosition_WhenAddLampInPositionDoItProperly()
    {
        LampsRow lampsRow = new LampsRow(name, id);
        int position = 0;
        lampsRow.AddLampInPosition(lamp1, position);
        Assert.IsType<Lamp>(lampsRow.lamps[0]);
    }
    [Fact]
    public void RemoveLamp_WhenRemoveLampById_RemoveProperly()
    {
        LampsRow lampsRow = new LampsRow(name, id);
        lampsRow.AddLamp(lamp1);
        lampsRow.RemoveLampDevice(lamp1.Id);
        Assert.Empty(lampsRow.lamps);
    }
    [Fact]
    public void RemoveLamp_WhenRemoveLampByName()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLamp(lamp1);
        newLampsRow.RemoveLampDevice(lamp1.Name);
        Assert.Empty(newLampsRow.lamps);
    }
    [Fact]
    public void RemoveLampInPosition_WhenRemoveLampInPositionDoItProperly()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLampInPosition(lamp1, 0);
        newLampsRow.RemoveLampInPosition(0);
        Assert.Empty(newLampsRow.lamps);
    }   
    //TurnOnOffAllLamps Tests
    [Fact]
    public void ToggleAllLamps_WhenAllLampsAreOnTurnOff()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLamp(lamp1);
        newLampsRow.AddLamp(lamp2);
        newLampsRow.ToggleAllLamps(); // on
        newLampsRow.ToggleAllLamps(); // off
        for (int i = 0; i < newLampsRow.lamps.Count; i++)
        {
            if (newLampsRow.lamps[i] is Lamp)
            Assert.Equal(DeviceStatus.Off, newLampsRow.lamps[i].Status);
        }
    }

    [Fact]
    public void ToggleAllLamps_WhenAllLampsAreOffTurnOn()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLamp(lamp1);
        newLampsRow.AddLamp(lamp2);
        newLampsRow.ToggleAllLamps();
        for (int i = 0; i < newLampsRow.lamps.Count; i++)
        {
            if (newLampsRow.lamps[i] is Lamp)
                Assert.Equal(DeviceStatus.On, newLampsRow.lamps[i].Status);
        }
    }

    [Fact]
    public void ToggleAllEcoLamps_WhenAllEcoLampsAreOnTurnOff()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddEcoLamp(ecoLamp1);
        newLampsRow.AddEcoLamp(ecoLamp2);
        newLampsRow.ToggleAllEcoLamps(); // on
        newLampsRow.ToggleAllEcoLamps(); // off

        for (int i = 0; i < newLampsRow.lamps.Count; i++)
        {
            if (newLampsRow.lamps[i] is EcoLamp)
                Assert.Equal(DeviceStatus.Off, newLampsRow.lamps[i].Status);
        }
    }

    [Fact]
    public void ToggleAllEcoLamps_WhenAllEcoLampsAreOffTurnOn()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddEcoLamp(ecoLamp1);
        newLampsRow.AddEcoLamp(ecoLamp2);
        newLampsRow.ToggleAllEcoLamps();
        for (int i = 0; i < newLampsRow.lamps.Count; i++)
        {
            if (newLampsRow.lamps[i] is EcoLamp)
                Assert.Equal(DeviceStatus.On, newLampsRow.lamps[i].Status);
        }
    }

    [Fact]
    public void ToggleAllDevices_WhenAllDevicesAreOnTurnOff()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLamp(lamp1);
        newLampsRow.AddEcoLamp(ecoLamp1);
        newLampsRow.ToggleAll(); // on
        newLampsRow.ToggleAll(); // off
        for (int i = 0; i < newLampsRow.lamps.Count; i++)
        {
            Assert.Equal(DeviceStatus.Off, newLampsRow.lamps[i].Status);
        }
    }

    [Fact]
    public void ToggleAllDevices_WhenAllDevicesAreOffTurnOn()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLamp(lamp1);
        newLampsRow.AddEcoLamp(ecoLamp1);
        newLampsRow.ToggleAll(); // on
        for (int i = 0; i < newLampsRow.lamps.Count; i++)
        {
            Assert.Equal(DeviceStatus.On, newLampsRow.lamps[i].Status);
        }
    }

    //SetIntensityTests
    [Fact]
    public void SetIntensityForLamp_WhenSetLampIntensityByIdTo25_ThenBrightnessIs25()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLamp(lamp1);
        newLampsRow.AddLamp(lamp2);
        newLampsRow.SetIntensityForLamp(id, 25);
        for (int i = 0; i < newLampsRow.lamps.Count; i++)
        {
            if (newLampsRow.lamps[i].Id == id)
                Assert.Equal(25, newLampsRow.lamps[i].Intensity);
        }
    }
    [Fact]
    public void SetIntensityForLamp_WhenSetLampIntensityByNameTo50_ThenBrightnessIs50()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLamp(lamp1);
        newLampsRow.AddLamp(lamp2);
        newLampsRow.SetIntensityForLamp(name, 50);
        for (int i = 0; i < newLampsRow.lamps.Count; i++)
        {
            if (newLampsRow.lamps[i].Name == name)
                Assert.Equal(50, newLampsRow.lamps[i].Intensity);
        }
    }
    [Fact]
    public void SetIntensityForAllLamps_WhenChangeAllDevicesBrightnessTo17_ThenBrightnessIs17()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLamp(lamp1);
        newLampsRow.AddLamp(lamp2);
        newLampsRow.ToggleAllLamps();
        newLampsRow.SetIntensityForAllLamps(17);
        for (int i = 0; i <newLampsRow.lamps.Count; i++)
        {
            Assert.Equal(17, newLampsRow.lamps[i].Intensity);
        }
    }
    //SwitchOn Tests
    [Fact]
    public void SwitchOn_WhenSwitchOnAllLamps_ThenAllLampsAreOn()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLamp(lamp1);
        newLampsRow.AddLamp(lamp2);
        for (int i = 0; i < newLampsRow.lamps.Count; i++)
        {
            newLampsRow.SwitchOn();
            Assert.Equal(DeviceStatus.On, newLampsRow.lamps[i].Status);
        }
    }
    [Fact]
    public void SwitchOn_WhenSwitchOnLampById_ThenLampIsOn()
    {
       
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLamp(lamp1);
        newLampsRow.AddLamp(lamp2);
        newLampsRow.SwitchOn(id);
        for (int i = 0; i < newLampsRow.lamps.Count; i++)
        {
            if (newLampsRow.lamps[i].Id == id)
                Assert.Equal(DeviceStatus.On, newLampsRow.lamps[i].Status);
        }
    }
    [Fact]
    public void SwitchOn_WhenSwitchOnByName_ThenLampIsOn()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLamp(lamp1);
        newLampsRow.AddLamp(lamp2);
        newLampsRow.SwitchOn(name);
        for (int i = 0; i < newLampsRow.lamps.Count; i++)
        {
            if (newLampsRow.lamps[i].Name == name)
                Assert.Equal(DeviceStatus.On, newLampsRow.lamps[i].Status);
        }
    }
    [Fact]
    public void SwitchOff_WhenSwitchOffLampById_ThenLampIsOff()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.SwitchOn(id); // prima lo accendo
        newLampsRow.SwitchOff(id); // poi lo spengo
        for (int i = 0; i < newLampsRow.lamps.Count; i++)
        {
            if (newLampsRow.lamps[i].Id == id)
                Assert.Equal(DeviceStatus.Off, newLampsRow.lamps[i].Status);
        }
    }
    [Fact]
    public void SwitchOff_WhenSwitchOffByName_ThenLampIsOff()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLamp(lamp1);
        newLampsRow.AddLamp(lamp2);
        newLampsRow.SwitchOn(name); // prima lo accendo
        newLampsRow.SwitchOff(name); // poi lo spengo
        for (int i = 0; i < newLampsRow.lamps.Count; i++)
        {
            if (newLampsRow.lamps[i].Name == name)
                Assert.Equal(DeviceStatus.Off, newLampsRow.lamps[i].Status);
        }
    }
    [Fact]
    public void FindAllOn_FindAllOnLamps_ReturnOnlyOnLamps()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLamp(lamp1);
        newLampsRow.AddLamp(lamp2);
        newLampsRow.SwitchOn(id); // accendo la lampada
        var onLamps = newLampsRow.FindAllOn();
        foreach (var lamp in onLamps)
        {
            Assert.Equal(DeviceStatus.On, lamp.Status);
        }
    }
    [Fact]
    public void FindAllOff_FindAllOffLamps_ReturnOnlyOffLamps()
    {
        LampsRow newLampsRow = new LampsRow(name, id);
        newLampsRow.AddLamp(lamp1);
        newLampsRow.AddLamp(lamp2);
        var offLamps = newLampsRow.FindAllOff();
        foreach (var lamp in offLamps)
        {
            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }
    }

}
