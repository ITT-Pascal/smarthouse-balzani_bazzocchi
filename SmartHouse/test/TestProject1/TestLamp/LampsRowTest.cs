using BlaisePascal.SmartHouse.Domain.Electrodomestic;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp;

namespace TestProject1.TestLamp.LampTest;

public class LampsRowTest
{
    //Add/Remove Lamp Tests
    [Fact]
    public void AddLamp_WhenAddLamp()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "foca";
        LampsRow newLampsRow = new LampsRow(LampList, name);

        newLampsRow.AddLamp(newLamp);

        Assert.IsType<Lamp>(newLampsRow.lamps[0]); // new nel costruttore nuovo.
    }

    [Fact]
    public void AddEcoLamp_WhenAddEcoLamp()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "ciao";
        LampsRow newLampsRow = new LampsRow(LampList, name);
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

        newLampsRow.AddEcoLamp(newEcoLamp);

        Assert.IsType<EcoLamp>(newLampsRow.lamps[0]);
    }

    [Fact]
    public void AddLampInPosition_WhenAddLampInPositionDoItProperly()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "hello";
        LampsRow newLampsRow = new LampsRow(LampList, name);
        newLampsRow.AddLampInPosition(newLamp, 0);
        Assert.IsType<Lamp>(newLampsRow.lamps[0]);
    }

    [Fact]
    public void RemoveLamp_WhenRemoveLampById()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "miao";
        LampsRow newLampsRow = new LampsRow(LampList, name);
        newLampsRow.AddLamp(newLamp);
        newLampsRow.RemoveLampDevice(id);
        Assert.Empty(newLampsRow.lamps);
    }
    [Fact]
    public void RemoveLamp_WhenRemoveLampByName()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "gatto";
        newLamp.Name = name;
        LampsRow newLampsRow = new LampsRow(LampList, name);
        newLampsRow.AddLamp(newLamp);
        newLampsRow.RemoveLampDevice(name);
        Assert.Empty(newLampsRow.lamps);
    }
    [Fact]
    public void RemoveLampInPosition_WhenRemoveLampInPositionDoItProperly()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "topo";
        LampsRow newLampsRow = new LampsRow(LampList, name);
        newLampsRow.AddLampInPosition(newLamp, 0);
        newLampsRow.RemoveLampInPosition(0);
        Assert.Empty(newLampsRow.lamps);
    }   

    //TurnOnOffAllLamps Tests
    [Fact]
    public void TurnOnOffAllLamps_WhenAllLampsAreOn()
    {

        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "bibi";
        LampsRow newLampsRow = new LampsRow(LampList, name);

        newLampsRow.ToggleAllLamps(); // on
        newLampsRow.ToggleAllLamps(); // off

        for (int i = 0; i < LampList.Count; i++)
        {
            if (LampList[i] is Lamp)
            Assert.Equal(DeviceStatus.Off, LampList[i].Status);
        }
    }

    [Fact]
    public void TurnOnOffAllLamps_WhenAllLampsAreOff()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "wow";
        LampsRow newLampsRow = new LampsRow(LampList, name);

        newLampsRow.ToggleAllLamps();

        for (int i = 0; i < LampList.Count; i++)
        {
            if (LampList[i] is Lamp)
                Assert.Equal(DeviceStatus.On, LampList[i].Status);
        }
    }

    [Fact]
    public void TurnOnOffAllEcoLamps_WhenAllEcoLampsAreOn()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "hi";
        LampsRow newLampsRow = new LampsRow(LampList, name);

        newLampsRow.ToggleAllEcoLamps(); // on
        newLampsRow.ToggleAllEcoLamps(); // off

        for (int i = 0; i < LampList.Count; i++)
        {
            if (LampList[i] is EcoLamp)
                Assert.Equal(DeviceStatus.Off, LampList[i].Status);
        }
    }

    [Fact]
    public void TurnOnOffAllEcoLamps_WhenAllEcoLampsAreOff()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        string name = "Luca";
        LampsRow newLampsRow = new LampsRow(LampList, name);

        newLampsRow.ToggleAllEcoLamps();

        for (int i = 0; i < LampList.Count; i++)
        {
            if (LampList[i] is EcoLamp)
                Assert.Equal(DeviceStatus.On, LampList[i].Status);
        }
    }

    [Fact]
    public void TurnOnOffAllDevices_WhenAllDevicesAreOn()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "Io";
        LampsRow newLampsRow = new LampsRow(LampList, name);

        newLampsRow.ToggleAllLamps();
        newLampsRow.ToggleAllEcoLamps();

        for (int i = 0; i < LampList.Count; i++)
        {
            Assert.Equal(DeviceStatus.Off, LampList[i].Status);
        }
    }

    [Fact]
    public void TurnOnOffAllDevices_WhenAllDevicesAreOff()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "No";
        LampsRow newLampsRow = new LampsRow(LampList, name);

        newLampsRow.ToggleAllLamps();

        for (int i = 0; i < LampList.Count; i++)
        {
            Assert.Equal(DeviceStatus.On, LampList[i].Status);
        }
    }

    //SetIntensityTests
    [Fact]
    public void SetIntensityForLamp_WhenSetLampIntensityByIdTo25_ThenBrightnessIs25()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "pallone";
        LampsRow newLampsRow = new LampsRow(LampList, name);
        newLampsRow.SetIntensityForLamp(id, 25);
        for (int i = 0; i < LampList.Count; i++)
        {
            if (newLampsRow.lamps[i].Id == id)
                Assert.Equal(25, newLampsRow.lamps[i].Intensity);
        }
    }
    [Fact]
    public void SetIntensityForLamp_WhenSetLampIntensityByNameTo50_ThenBrightnessIs50()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "pallina";
        newLamp.Name = name;
        LampsRow newLampsRow = new LampsRow(LampList, name);
        newLampsRow.SetIntensityForLamp(name, 50);
        for (int i = 0; i < LampList.Count; i++)
        {
            if (newLampsRow.lamps[i].Name == name)
                Assert.Equal(50, newLampsRow.lamps[i].Intensity);
        }
    }
    [Fact]
    public void SetIntensityForAllLamps_WhenChangeAllDevicesBrightnessTo17_ThenBrightnessIs17()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "pallina";
        LampsRow newLampsRow = new LampsRow(LampList, name);

        newLampsRow.SetIntensityForAllLamps(17);

        for (int i = 0; i < LampList.Count; i++)
        {
            Assert.Equal(17, newLampsRow.lamps[i].Intensity);
        }
    }
    //SwitchOn Tests
    [Fact]
    public void SwitchOn_WhenSwitchOnAllLamps_ThenAllLampsAreOn()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "pallone";
        LampsRow newLampsRow = new LampsRow(LampList, name);
        
        for (int i = 0; i < LampList.Count; i++)
        {
            newLampsRow.SwitchOn();
            Assert.Equal(DeviceStatus.On, newLampsRow.lamps[i].Status);
        }
    }

    [Fact]
    public void SwitchOn_WhenSwitchOnLampById_ThenLampIsOn()
    {
        Guid id = Guid.NewGuid();
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "palla";
        LampsRow newLampsRow = new LampsRow(LampList, name);
        newLampsRow.SwitchOn(id);
        for (int i = 0; i < LampList.Count; i++)
        {
            if (newLampsRow.lamps[i].Id == id)
                Assert.Equal(DeviceStatus.On, newLampsRow.lamps[i].Status);
        }
    }
    [Fact]
    public void SwitchOn_WhenSwitchOnByName_ThenLampIsOn()
    {
        Guid id = Guid.NewGuid();
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "pallina";
        LampsRow newLampsRow = new LampsRow(LampList, name);
        newLampsRow.SwitchOn(name);
        for (int i = 0; i < LampList.Count; i++)
        {
            if (newLampsRow.lamps[i].Name == name)
                Assert.Equal(DeviceStatus.On, newLampsRow.lamps[i].Status);
        }
    }
    [Fact]
    public void SwitchOff_WhenSwitchOffLampById_ThenLampIsOff()
    {
        Guid id = Guid.NewGuid();
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "pacco";
        LampsRow newLampsRow = new LampsRow(LampList, name);
        newLampsRow.SwitchOn(id); // prima lo accendo
        newLampsRow.SwitchOff(id); // poi lo spengo
        for (int i = 0; i < LampList.Count; i++)
        {
            if (newLampsRow.lamps[i].Id == id)
                Assert.Equal(DeviceStatus.Off, newLampsRow.lamps[i].Status);
        }
    }

    [Fact]
    public void SwitchOff_WhenSwitchOffByName_ThenLampIsOff()
    {
        Guid id = Guid.NewGuid();
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "pacco";
        LampsRow newLampsRow = new LampsRow(LampList, name);
        newLampsRow.SwitchOn(name); // prima lo accendo
        newLampsRow.SwitchOff(name); // poi lo spengo
        for (int i = 0; i < LampList.Count; i++)
        {
            if (newLampsRow.lamps[i].Name == name)
                Assert.Equal(DeviceStatus.Off, newLampsRow.lamps[i].Status);
        }
    }
    [Fact]
    public void FindAllOn_FindAllOnLamps_ReturnOnlyOnLamps()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "pacco";
        LampsRow newLampsRow = new LampsRow(LampList, name);
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
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);
        string name = "pacco";
        LampsRow newLampsRow = new LampsRow(LampList, name);
        var offLamps = newLampsRow.FindAllOff();
        foreach (var lamp in offLamps)
        {
            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }
    }

}
