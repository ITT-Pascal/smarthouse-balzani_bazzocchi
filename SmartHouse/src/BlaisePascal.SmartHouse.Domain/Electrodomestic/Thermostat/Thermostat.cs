using BlaisePascal.SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Thermostat
{
    public class Thermostat: AbstractDevice
    {
        public double CurrentTemperature { get; private set; }
        public double TargetTemperature { get; private set; }
        public const int MinTemperature = 0;
        public const int MaxTemperature = 40;
        public Thermostat(string name, double temp, Guid id): base(name, id)
        {
            CurrentTemperature = temp;
            TargetTemperature = temp;
        }
        public void SetTargetTemperature(double temp)
        {
            if (temp < MinTemperature || temp > MaxTemperature)
                throw new ArgumentOutOfRangeException($"Target temperature must be between {MinTemperature} and {MaxTemperature}.");   
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Cannot set target temperature when the thermostat is off.");
            TargetTemperature = temp;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void UpdateTemperature()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Cannot update temperature when the thermostat is off.");
            if (CurrentTemperature < TargetTemperature)
                CurrentTemperature += TargetTemperature - CurrentTemperature;
            else if (CurrentTemperature > TargetTemperature)
                CurrentTemperature -= CurrentTemperature - TargetTemperature;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void SetCurrentTemperature(double temp)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Cannot set current temperature when the thermostat is off.");
            if (temp < MinTemperature || temp > MaxTemperature)
                throw new ArgumentOutOfRangeException($"Temperature must be between {MinTemperature} and {MaxTemperature}.");
            CurrentTemperature = temp;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void SetTemperatureOnTime(DateTime dateTime, double temp)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Cannot set current temperature when the thermostat is off.");
            if (temp < MinTemperature || temp > MaxTemperature)
                throw new ArgumentOutOfRangeException($"Temperature must be between {MinTemperature} and {MaxTemperature}.");
            if (DateTime.UtcNow == dateTime)
            {
                CurrentTemperature = temp;
                LastModifiedAtUtc = DateTime.UtcNow;
            }  
        }
        
    }

}
