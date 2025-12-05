using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic
{
    public class AirConditioner: AbstractDevice
    {
        public double CurrentTemperature { get; private set; }
        public double TargetTemperature { get; private set; }
        public int Power { get; set; }
        public const int MinTemperature = 10;
        public const int MaxTemperature = 30;
        public const int MinPower = 1;
        public const int MaxPower = 3;
        public TimeOnly? HourToTurnOn { get; set; } // nullable
        public TimeOnly? HourToTurnOff { get; set; } // nullable

        public AirConditioner(Guid id, string name, double currentTemperture, double targetTemperature, int power): base(name)
        {
            CurrentTemperature = currentTemperture;
            TargetTemperature = targetTemperature;
            if (power < MinPower || power > MaxPower)
                throw new ArgumentOutOfRangeException($"La potenza può assumere solamente valori compresi fra {MinPower} e {MaxPower}");
            Power = power;
                
        }

        public void SetTargetTemperature(double temperature)
        {
            if (temperature < TargetTemperature || temperature > TargetTemperature)
                throw new ArgumentOutOfRangeException($"La temperatura deve essere compresa fra {MinTemperature} e {MaxTemperature}");
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("You CANNOT set the temperature if the airconditioner is off!!");
            TargetTemperature = temperature;
        }

        public void SetAutoTurnOn(TimeOnly hourToTurnOn)
        {
            //TimeOnly CurrentTime = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute);
            HourToTurnOn = hourToTurnOn;
        }

        public void SetAutoTurnOff(TimeOnly hourToTurnOff)
        {
            HourToTurnOff = hourToTurnOff;
        }

        public void AutoTurnOn()
        {
            TimeOnly now = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute);
            if (HourToTurnOn == now && Status == DeviceStatus.Off && CurrentTemperature < TargetTemperature)
                Status = DeviceStatus.On;
        }

        public void AutoTurnOff()
        {
            TimeOnly now = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute);
            if (Status == DeviceStatus.On)
                if (HourToTurnOff == now || CurrentTemperature == TargetTemperature)
                    Status = DeviceStatus.Off;
        }
    }
}
