using BlaisePascal.SmartHouse.Domain.Electrodomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.ElectrodomesticTest.AirConditionerTests
{
    public class AirConditionerTests
    {
        [Fact]
        public void SetTargetTemperature_IfTheTemperatureIsInRange_SetTheTemperature()
        {
            AirConditioner A = new AirConditioner(Guid.NewGuid(), "AC1", 22.0, 26.0, 2);
            A.TurnOnOff(); 
            A.SetTargetTemperature(24.0);
            Assert.Equal(24.0, A.TargetTemperature);
        }

        [Fact]
        public void SetTargetTemperature_IfTheTemperatureIsOutOfRange_ThrowArgumentOutOfRangeException()
        {
            AirConditioner A = new AirConditioner(Guid.NewGuid(), "AC1", 22.0, 26.0, 2);
            A.TurnOnOff();
            Assert.Throws<ArgumentOutOfRangeException>(() => A.SetTargetTemperature(35.0));
        }
        [Fact]
        public void SetTargetTemperature_IfTheAirConditionerIsOff_ThrowInvalidOperationException()
        {
            AirConditioner A = new AirConditioner(Guid.NewGuid(), "AC1", 22.0, 26.0, 2);
            Assert.Throws<InvalidOperationException>(() => A.SetTargetTemperature(24.0));
        }
    }
}
