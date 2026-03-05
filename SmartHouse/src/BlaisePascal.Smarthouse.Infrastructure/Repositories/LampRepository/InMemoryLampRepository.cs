using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Smarthouse.Infrastructure.Repositories.LampRepository
{
    public class InMemoryLampRepository : ILampRepository
    {
        private readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<Lamp>();
            _lamps.Add(new Lamp(new Name("Lampada Salotto")));
            _lamps.Add(new Lamp(new Name("Lampada Cucina")));
        }
        public Lamp GetById(Guid id)
        {
            return _lamps.FirstOrDefault(lamp => lamp.Id == id);
        }

        public List<Lamp> GetAll()
        {
            return _lamps.ToList();
        }

        public void Add(Lamp lamp)
        {
            if (lamp == null)
            {
                throw new ArgumentNullException(nameof(lamp), "Non puoi salvare una lampada vuota nel DB.");
            }
            _lamps.Add(lamp);
        }

        public void Remove(Guid id)
        {
            Lamp lampToRemove = GetById(id);
            if (lampToRemove != null)
            {
                _lamps.Remove(lampToRemove);
            }
        }

        public void Update(Lamp lamp)
        {
            Lamp existingLamp = GetById(lamp.Id);
            if (existingLamp != null)
            {
                _lamps.Remove(existingLamp);
                _lamps.Add(lamp);
            }
        }
    }
}
