using BlaisePascal.SmartHouse.Domain.Electrodomestic.Lamp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic
{
    public class AirConditioner
    {
        public string Name { get; set; }
        public double CurrentTemperature { get; private set; }
        public double TargetTemperature { get; private set; }

        public const int MinTemperature = 10;
        public const int MaxTemperature = 30;
        public DeviceStatus Status { get; set; }
        public Guid Id { get; set; }
        public TimeOnly CurrentTime { get; set; }

        public AirConditioner(string name, double currentTemperture, double targettemperature, Guid id)
        {
            Name = name;
            CurrentTemperature = currentTemperture;
            TargetTemperature = targettemperature;
            Status = DeviceStatus.Off;
            Id = id;
            CurrentTime = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute);
        }

        public void TurnOnOff()
        {
            if (Status == DeviceStatus.Off)
                Status = DeviceStatus.On;
            else
                Status = DeviceStatus.Off;
        }

        public void SetTargetTemperature(double temperature)
        {
            if (temperature < TargetTemperature || temperature > TargetTemperature)
                throw new ArgumentOutOfRangeException($"La temperatura deve essere compresa fra {MinTemperature} e {MaxTemperature}");
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("You CANNOT set the temperature if the airconditioner is off!!");
            TargetTemperature = temperature;
        }
    }
}
