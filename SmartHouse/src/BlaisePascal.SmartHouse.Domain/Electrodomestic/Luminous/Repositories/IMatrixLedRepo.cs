using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories
{
    public interface IMatrixLedRepository
    {
        void Add(MatrixLed matrix);
        void Update(MatrixLed matrix);
        void Remove(Guid id);
        MatrixLed GetById(Guid id);
        List<MatrixLed> GetAll();
    }
}
