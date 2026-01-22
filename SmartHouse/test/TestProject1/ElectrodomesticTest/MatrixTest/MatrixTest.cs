using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.ElectrodomesticTest.MatrixTest
{
    public class MatrixTest
    {
        readonly int rows = 10;
        readonly int columns = 10;
        readonly Guid id = Guid.NewGuid();
        readonly string name = "Foca";

        [Fact]
        public void AddChangeLamp_InsertLamp()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            AbstractLamp type = new Lamp(Guid.NewGuid(), "Sasso");
            newMatrixLed.AddChangeLamp(type, 3, 3);
            Assert.IsType<Lamp>(newMatrixLed.Matrix[2, 2]);
        }

        
    }
}
