using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.TemperatureDevice.Repository
{
    public interface IAirConditionerRepository
    {
        void Add(AirConditioner ac);
        void Update(AirConditioner ac);
        void Remove(Guid id);
        AirConditioner GetById(Guid id);
        List<AirConditioner> GetAll();
        // Metodo speciale: trova condizionatori con una specifica TargetTemperature
        List<AirConditioner> GetByTargetTemperature(double temp);
    }
}
