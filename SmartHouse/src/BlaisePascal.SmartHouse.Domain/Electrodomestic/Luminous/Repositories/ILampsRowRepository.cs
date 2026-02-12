using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories
{
    public interface ILampsRowRepository
    {
        void Add(LampsRow row);
        void Update(LampsRow row);
        void Remove(Guid id);
        LampsRow GetById(Guid id);
        List<LampsRow> GetAll();
    }
}
