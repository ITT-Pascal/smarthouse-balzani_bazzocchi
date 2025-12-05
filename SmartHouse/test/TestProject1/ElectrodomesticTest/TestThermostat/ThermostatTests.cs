using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Thermostat;

namespace TestProject1.TestThermostat.ThermostatTests
{
    public class ThermostatTests
    {
        [Fact]
        public void Thermostat_WhenCreated_ThermostatIsOff()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 20);

            // Assert
            Assert.Equal(DeviceStatus.Off, thermostat.Status);
            Assert.Equal(20, thermostat.CurrentTemperature);
            Assert.Equal(20, thermostat.TargetTemperature);
        }
        [Fact]
        public void Thermostat_WhenTurnOn_ThermostatIsOn()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 20);
            // Act
            thermostat.TurnOnOff();
            // Assert
            Assert.Equal(DeviceStatus.On, thermostat.Status);
        }

        [Fact]
        public void Thermostat_WhenTurnOff_ThermostatIsOff()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 20);
            // Act
            thermostat.TurnOnOff();
            thermostat.TurnOnOff();
            // Assert
            Assert.Equal(DeviceStatus.Off, thermostat.Status);
        }

        [Fact]
        public void Thermostat_SetTargetTemperature_WhenThermostatIsOff_ThrowInvalidOperationException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 20);
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => thermostat.SetTargetTemperature(22));
        }
        [Fact]
        public void Thermostat_SetTargetTemperature_WhenThermostatIsOn_SetSuccessfully()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 20);
            thermostat.TurnOnOff();
            // Act
            thermostat.SetTargetTemperature(22);
            // Assert
            Assert.Equal(22, thermostat.TargetTemperature);
        }

        [Fact]
        public void Thermostat_SetTargetTemperature_WhenTemperatureIsOutOfRange_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 20);
            thermostat.TurnOnOff();
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.SetTargetTemperature(50));
        }
        [Fact]
        public void Thermostat_SetTargetTemperature_WhenTemperatureValueIsLowerThanRange_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 20);
            thermostat.TurnOnOff();
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.SetTargetTemperature(-1));
        }
        [Fact]
        public void Thermostat_UpdateTemperature_WhenThermostatIsOff_ThrowInvalidOperationException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 20);
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => thermostat.UpdateTemperature());
        }
        [Fact]
        public void Thermostat_UpdateTemperature_WhenCurrentTemperatureIsLowerThanTarget_IncreaseCurrentTemperature()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 20);
            thermostat.TurnOnOff();
            thermostat.SetTargetTemperature(25);
            // Act
            thermostat.UpdateTemperature();
            // Assert
            Assert.Equal(20.5, thermostat.CurrentTemperature);
        }
        [Fact]
        public void Thermostat_UpdateTemperature_WhenCurrentTemperatureIsHigherThanTarget_DecreaseCurrentTemperature()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 30);
            thermostat.TurnOnOff();
            thermostat.SetTargetTemperature(25);
            // Act
            thermostat.UpdateTemperature();
            // Assert
            Assert.Equal(29.5, thermostat.CurrentTemperature);
        }
        [Fact]
        public void Thermostat_SetCurrentTemperature_WhenThermostatIsOff_ThrowInvalidOperationException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 20);
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => thermostat.SetCurrentTemperature(22));
        }
        [Fact]
        public void Thermostat_SetCurrentTemperature_WhenTemperatureIsOutOfRange_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 20);
            thermostat.TurnOnOff();
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.SetCurrentTemperature(50));
        }
        [Fact]
        public void Thermostat_SetCurrentTemperature_WhenTemperatureValueIsLowerThanRange_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 20);
            thermostat.TurnOnOff();
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.SetCurrentTemperature(-1));
        }
        [Fact]
        public void Thermostat_SetCurrentTemperature_WhenThermostatIsOn_SetSuccessfully()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 20);
            thermostat.TurnOnOff();
            // Act
            thermostat.SetCurrentTemperature(22);
            // Assert
            Assert.Equal(22, thermostat.CurrentTemperature);
        }
        [Fact]
        public void Thermostat_SetTemperatureOnTime_WhenThermostatIsOff_ThrowInvalidOperationException()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Living Room Thermostat", 20);
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => thermostat.SetTemperatureOnTime(DateTime.UtcNow.AddMinutes(10), 22));
        }
    }
}
