using BlaisePascal.SmartHouse.Domain;

namespace TestProject1;

public class LampsRowTest
{
    //private LampDesign _lamp = new Lamp();
    //private LampDesign _ecoLamp = new EcoLamp();

    Lamp newLamp = new Lamp();
    EcoLamp newEcoLamp = new EcoLamp();
    LampsRow newLampsRow = new LampsRow();
    List<LampDesign> LampList = new List<LampDesign>();

    [Fact]
    public void AddLamp_WhenAddLamp()
    {
        newLampsRow.AddLamp(newLamp);

        Assert.IsType<Lamp>(newLampsRow.LampList[0]); // new nel costruttore nuovo.
    }

    [Fact]
    public void AddEcoLamp_WhenAddEcoLamp()
    {
        newLampsRow.AddEcoLamp(newEcoLamp);

        Assert.IsType<EcoLamp>(newLampsRow.LampList[0]);
    }

    [Fact]
    public void TurnOnOffAllLamps_WhenAllLampsAreOn()
    {
        newLampsRow.TurnOnOffAllLamps(); // on
        newLampsRow.TurnOnOffAllLamps(); // off

        for (int i = 0; i < LampList.Count; i++)
        {
            if (LampList[i] is Lamp)
            Assert.False(newLampsRow.LampList[i].IsOn);
        }
    }

    [Fact]
    public void TurnOnOffAllLamps_WhenAllLampsAreOff()
    {
        newLampsRow.TurnOnOffAllLamps();

        for (int i = 0; i < LampList.Count; i++)
        {
            if (LampList[i] is Lamp)
            Assert.True(newLampsRow.LampList[i].IsOn);
        }
    }

    [Fact]
    public void TurnOnOffAllEcoLamps_WhenAllEcoLampsAreOn()
    {
        newLampsRow.TurnOnOffAllEcoLamps(); // on
        newLampsRow.TurnOnOffAllEcoLamps(); // off

        for (int i = 0; i < LampList.Count; i++)
        {
            if (LampList[i] is EcoLamp)
                Assert.False(newLampsRow.LampList[i].IsOn);
        }
    }

    [Fact]
    public void TurnOnOffAllEcoLamps_WhenAllEcoLampsAreOff()
    {
        newLampsRow.TurnOnOffAllEcoLamps();

        for (int i = 0; i < LampList.Count; i++)
        {
            if (LampList[i] is EcoLamp)
                Assert.True(newLampsRow.LampList[i].IsOn);
        }
    }

    [Fact]
    public void TurnOnOffAllDevices_WhenAllDevicesAreOn()
    {
        newLampsRow.TurnOnOffAllLamps();
        newLampsRow.TurnOnOffAllEcoLamps();

        for (int i = 0; i < LampList.Count; i++)
        {
            Assert.False(newLampsRow.LampList[i].IsOn);
        }
    }

    [Fact]
    public void TurnOnOffAllDevices_WhenAllDevicesAreOff()
    {
        newLampsRow.TurnOnOffAllLamps();

        for (int i = 0; i < LampList.Count; i++)
        {
            Assert.True(newLampsRow.LampList[i].IsOn);
        }
    }

    [Fact]
    public void ChangeBrightnessAllDevices_WhenChangeAllDevicesBrightnessTo17_ThenBrightnessIs17()
    {
        newLampsRow.ChangeBrightnessAllDevices(17);

        for (int i = 0; i < LampList.Count; i++)
        {
            Assert.Equal(17, newLampsRow.LampList[i].Brightness);
        }
    }
}
