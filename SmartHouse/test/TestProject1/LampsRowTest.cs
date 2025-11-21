using BlaisePascal.SmartHouse.Domain.Lamp;

namespace TestProject1;

public class LampsRowTest
{
    //private LampDesign _lamp = new Lamp();
    //private LampDesign _ecoLamp = new EcoLamp();

    
    /*Lamp newLamp = new Lamp(lampName);
    EcoLamp newEcoLamp = new EcoLamp(lampName);
    LampsRow newLampsRow = new LampsRow();
    List<LampDesign> LampList = new List<LampDesign>();*/

    [Fact]
    public void AddLamp_WhenAddLamp()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);

        newLampsRow.AddLamp(newLamp);

        Assert.IsType<Lamp>(newLampsRow.LampList[0]); // new nel costruttore nuovo.
    }

    [Fact]
    public void AddEcoLamp_WhenAddEcoLamp()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

        newLampsRow.AddEcoLamp(newEcoLamp);

        Assert.IsType<EcoLamp>(newLampsRow.LampList[0]);
    }

    [Fact]
    public void TurnOnOffAllLamps_WhenAllLampsAreOn()
    {

        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);

        newLampsRow.TurnOnOffAllLamps(); // on
        newLampsRow.TurnOnOffAllLamps(); // off

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
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp(createdAtUtc, random, id);

        newLampsRow.TurnOnOffAllLamps();

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
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

        newLampsRow.TurnOnOffAllEcoLamps(); // on
        newLampsRow.TurnOnOffAllEcoLamps(); // off

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
        Random random = new Random();
        Guid id = Guid.NewGuid();
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

        newLampsRow.TurnOnOffAllEcoLamps();

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
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

        newLampsRow.TurnOnOffAllLamps();
        newLampsRow.TurnOnOffAllEcoLamps();

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
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

        newLampsRow.TurnOnOffAllLamps();

        for (int i = 0; i < LampList.Count; i++)
        {
            Assert.Equal(DeviceStatus.On, LampList[i].Status);
        }
    }

    [Fact]
    public void ChangeBrightnessAllDevices_WhenChangeAllDevicesBrightnessTo17_ThenBrightnessIs17()
    {
        DateTime createdAtUtc = DateTime.UtcNow;
        Random random = new Random();
        Guid id = Guid.NewGuid();
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        EcoLamp newEcoLamp = new EcoLamp(createdAtUtc, random, id);

        newLampsRow.ChangeBrightnessAllDevices(17);

        for (int i = 0; i < LampList.Count; i++)
        {
            Assert.Equal(17, newLampsRow.LampList[i].Intensity);
        }
    }
}
