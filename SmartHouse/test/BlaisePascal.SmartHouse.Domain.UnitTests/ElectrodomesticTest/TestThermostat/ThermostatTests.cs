using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions.Status;
using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.TemperatureDevice.Entities;

namespace TestProject1.TestThermostat.ThermostatTests
{
    public class ThermostatTests
    {
        readonly Name name = new Name("Thermostat name");
        readonly int temp = 20;
        [Fact]
        public void Thermostat_WhenCreated_ThermostatIsOff()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp);

            // Assert
            Assert.Equal(DeviceStatus.Off, thermostat.Status);
            Assert.Equal(20, thermostat.CurrentTemperature);
            Assert.Equal(20, thermostat.TargetTemperature);
        }
        [Fact]
        public void Thermostat_WhenSwitchOn_ThermostatIsOn()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp);
            // Act
            thermostat.SwitchOn();
            // Assert
            Assert.Equal(DeviceStatus.On, thermostat.Status);
        }

        [Fact]
        public void Thermostat_WhenSwitchOff_ThermostatIsOff()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp   );
            // Act
            thermostat.SwitchOn();
            thermostat.SwitchOff();
            // Assert
            Assert.Equal(DeviceStatus.Off, thermostat.Status);
        }

        [Fact]
        public void Thermostat_SetTargetTemperature_WhenThermostatIsOff_ThrowInvalidOperationException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp);
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => thermostat.SetTargetTemperature(22));
        }
        [Fact]
        public void Thermostat_SetTargetTemperature_WhenThermostatIsOn_SetSuccessfully()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp);
            thermostat.SwitchOn();
            // Act
            thermostat.SetTargetTemperature(22);
            // Assert
            Assert.Equal(22, thermostat.TargetTemperature);
        }

        [Fact]
        public void Thermostat_SetTargetTemperature_WhenTemperatureIsOutOfRange_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp);
            thermostat.SwitchOn();
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.SetTargetTemperature(50));
        }
        [Fact]
        public void Thermostat_SetTargetTemperature_WhenTemperatureValueIsLowerThanRange_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp);
            thermostat.SwitchOn();
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.SetTargetTemperature(-1));
        }
        [Fact]
        public void Thermostat_UpdateTemperature_WhenThermostatIsOff_ThrowInvalidOperationException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp);
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => thermostat.UpdateTemperature());
        }
        [Fact]
        public void Thermostat_UpdateTemperature_WhenCurrentTemperatureIsLowerThanTarget_IncreaseCurrentTemperature()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp);
            thermostat.SwitchOn();
            thermostat.SetTargetTemperature(25);
            // Act
            thermostat.UpdateTemperature();
            // Assert
            Assert.Equal(25, thermostat.CurrentTemperature);
        }
        [Fact]
        public void Thermostat_UpdateTemperature_WhenCurrentTemperatureIsHigherThanTarget_DecreaseCurrentTemperature()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp);
            thermostat.SwitchOn();
            thermostat.SetTargetTemperature(25);
            // Act
            thermostat.UpdateTemperature();
            // Assert
            Assert.Equal(25, thermostat.CurrentTemperature);
        }
        [Fact]
        public void Thermostat_SetCurrentTemperature_WhenThermostatIsOff_ThrowInvalidOperationException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp);
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => thermostat.SetCurrentTemperature(22));
        }
        [Fact]
        public void Thermostat_SetCurrentTemperature_WhenTemperatureIsOutOfRange_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp);
            thermostat.SwitchOn();
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.SetCurrentTemperature(50));
        }
        [Fact]
        public void Thermostat_SetCurrentTemperature_WhenTemperatureValueIsLowerThanRange_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp);
            thermostat.SwitchOn();
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.SetCurrentTemperature(-1));
        }
        [Fact]
        public void Thermostat_SetCurrentTemperature_WhenThermostatIsOn_SetSuccessfully()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp);
            thermostat.SwitchOn();
            // Act
            thermostat.SetCurrentTemperature(22);
            // Assert
            Assert.Equal(22, thermostat.CurrentTemperature);
        }
        [Fact]
        public void Thermostat_SetTemperatureOnTime_WhenThermostatIsOff_ThrowInvalidOperationException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat(name, temp);
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => thermostat.SetTemperatureOnTime(DateTime.UtcNow.AddMinutes(10), 22));
        }
    }
}
