using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.TemperatureDevice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.ElectrodomesticTest.AirConditionerTests
{
    public class AirConditionerTests
    {
        AirConditioner A = new AirConditioner(new Name("AC1"), 22.0, 26.0, 2);
        [Fact]
        public void SetTargetTemperature_IfTheTemperatureIsInRange_SetTheTemperature()
        {
           
            A.Toggle(); 
            A.SetTargetTemperature(24.0);
            Assert.Equal(24.0, A.TargetTemperature);
        }

        [Fact]
        public void SetTargetTemperature_IfTheTemperatureIsOutOfRange_ThrowArgumentOutOfRangeException()
        {
            A.Toggle();
            Assert.Throws<ArgumentOutOfRangeException>(() => A.SetTargetTemperature(35.0));
        }
        [Fact]
        public void SetTargetTemperature_IfTheAirConditionerIsOff_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => A.SetTargetTemperature(24.0));
        }
    }
}
