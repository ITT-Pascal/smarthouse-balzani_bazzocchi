using BlaisePascal.SmartHouse.Domain;

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
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp();

        newLampsRow.AddLamp(newLamp);

        Assert.IsType<Lamp>(newLampsRow.LampList[0]); // new nel costruttore nuovo.
    }

    [Fact]
    public void AddEcoLamp_WhenAddEcoLamp()
    {
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp();
        EcoLamp newEcoLamp = new EcoLamp();

        newLampsRow.AddEcoLamp(newEcoLamp);

        Assert.IsType<EcoLamp>(newLampsRow.LampList[0]);
    }

    [Fact]
    public void TurnOnOffAllLamps_WhenAllLampsAreOn()
    {

        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp();
        EcoLamp newEcoLamp = new EcoLamp();
        newLampsRow.TurnOnOffAllLamps(); // on
        newLampsRow.TurnOnOffAllLamps(); // off

        for (int i = 0; i < LampList.Count; i++)
        {
            if (LampList[i] is Lamp)
            Assert.False(newLampsRow.LampList[i].IsLampOn());
        }
    }

    [Fact]
    public void TurnOnOffAllLamps_WhenAllLampsAreOff()
    {
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp();
        EcoLamp newEcoLamp = new EcoLamp();

        newLampsRow.TurnOnOffAllLamps();

        for (int i = 0; i < LampList.Count; i++)
        {
            if (LampList[i] is Lamp)
            Assert.True(newLampsRow.LampList[i].IsLampOn());
        }
    }

    [Fact]
    public void TurnOnOffAllEcoLamps_WhenAllEcoLampsAreOn()
    {
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp();
        EcoLamp newEcoLamp = new EcoLamp();

        newLampsRow.TurnOnOffAllEcoLamps(); // on
        newLampsRow.TurnOnOffAllEcoLamps(); // off

        for (int i = 0; i < LampList.Count; i++)
        {
            if (LampList[i] is EcoLamp)
                Assert.False(newLampsRow.LampList[i].IsLampOn());
        }
    }

    [Fact]
    public void TurnOnOffAllEcoLamps_WhenAllEcoLampsAreOff()
    {
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp();
        EcoLamp newEcoLamp = new EcoLamp();

        newLampsRow.TurnOnOffAllEcoLamps();

        for (int i = 0; i < LampList.Count; i++)
        {
            if (LampList[i] is EcoLamp)
                Assert.True(newLampsRow.LampList[i].IsLampOn());
        }
    }

    [Fact]
    public void TurnOnOffAllDevices_WhenAllDevicesAreOn()
    {
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp();
        EcoLamp newEcoLamp = new EcoLamp();

        newLampsRow.TurnOnOffAllLamps();
        newLampsRow.TurnOnOffAllEcoLamps();

        for (int i = 0; i < LampList.Count; i++)
        {
            Assert.False(newLampsRow.LampList[i].IsLampOn());
        }
    }

    [Fact]
    public void TurnOnOffAllDevices_WhenAllDevicesAreOff()
    {
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp();
        EcoLamp newEcoLamp = new EcoLamp();

        newLampsRow.TurnOnOffAllLamps();

        for (int i = 0; i < LampList.Count; i++)
        {
            Assert.True(newLampsRow.LampList[i].IsLampOn());
        }
    }

    [Fact]
    public void ChangeBrightnessAllDevices_WhenChangeAllDevicesBrightnessTo17_ThenBrightnessIs17()
    {
        LampsRow newLampsRow = new LampsRow();
        List<LampDesign> LampList = new List<LampDesign>();
        Lamp newLamp = new Lamp();
        EcoLamp newEcoLamp = new EcoLamp();

        newLampsRow.ChangeBrightnessAllDevices(17);

        for (int i = 0; i < LampList.Count; i++)
        {
            Assert.Equal(17, newLampsRow.LampList[i].Brightness);
        }
    }
}
