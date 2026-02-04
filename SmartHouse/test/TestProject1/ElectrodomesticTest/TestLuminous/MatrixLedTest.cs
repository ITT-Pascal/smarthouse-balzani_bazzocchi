using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.ElectrodomesticTest.TestLuminous
{
    public class MatrixLedTest
    {
        readonly int rows = 10;
        readonly int columns = 10;
        readonly Guid id = Guid.NewGuid();
        readonly Guid lampId = Guid.NewGuid();
        readonly string lampName = "lamp name";
        readonly string name = "matrix name";


        [Fact]
        public void AddChangeLamp_InsertLamp()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            AbstractLamp type = new Lamp(lampId, lampName);
            newMatrixLed.AddChangeLamp(type, 3, 3);
            Assert.IsType<Lamp>(newMatrixLed.Matrix[2, 2]);
        }

        [Fact]
        public void AddChangeLamp_InsertEcoLamp()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            AbstractLamp type = new EcoLamp(lampName, lampId);
            newMatrixLed.AddChangeLamp(type, 3, 3);
            Assert.IsType<EcoLamp>(newMatrixLed.Matrix[2, 2]);
        }

        [Fact]
        public void AddChangeLamp_InsertLampOutOfMatrix()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            AbstractLamp type = new EcoLamp(lampName, lampId);
            Assert.Throws<IndexOutOfRangeException>(() => newMatrixLed.AddChangeLamp(type, 15, 3));
        }

        [Fact]
        public void SwitchOn()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            newMatrixLed.SwitchOn();
            for (int r = 0; r < newMatrixLed.Matrix.GetLength(0); r++)
            {
                for (int c = 0; c < newMatrixLed.Matrix.GetLength(1); c++)
                {
                    Assert.Equal(DeviceStatus.On, newMatrixLed.Matrix[r, c].Status);
                }
            }
        }

        [Fact]
        public void SwitchOff()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            newMatrixLed.SwitchOn();
            newMatrixLed.SwitchOff();
            for (int r = 0; r < newMatrixLed.Matrix.GetLength(0); r++)
            {
                for (int c = 0; c < newMatrixLed.Matrix.GetLength(1); c++)
                {
                    Assert.Equal(DeviceStatus.Off, newMatrixLed.Matrix[r, c].Status);
                }
            }
        }

        [Fact]
        public void SwitchOnRow()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            newMatrixLed.SwitchOnRow(3);
            for (int c = 0; c < newMatrixLed.Matrix.GetLength(1); c++)
            {
                Assert.Equal(DeviceStatus.On, newMatrixLed.Matrix[2, c].Status);
            }
        }

        [Fact]
        public void SwitchOnRow_RowIndexOutOfMatrix()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            Assert.Throws<IndexOutOfRangeException>(() => newMatrixLed.SwitchOnRow(17));
        }

        [Fact]
        public void SwitchOffRow()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            newMatrixLed.SwitchOn();
            newMatrixLed.SwitchOffRow(3);
            for (int c = 0; c < newMatrixLed.Matrix.GetLength(1); c++)
            {
                Assert.Equal(DeviceStatus.Off, newMatrixLed.Matrix[2, c].Status);
            }
        }

        [Fact]
        public void SwitchOffRow_RowIndexOutOfMatrix()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            Assert.Throws<IndexOutOfRangeException>(() => newMatrixLed.SwitchOffRow(17));
        }

        [Fact]
        public void SwitchOnColumn()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            newMatrixLed.SwitchOnColumn(3);
            for (int r = 0; r < newMatrixLed.Matrix.GetLength(0); r++)
            {
                Assert.Equal(DeviceStatus.On, newMatrixLed.Matrix[r, 2].Status);
            }
        }

        [Fact]
        public void SwitchOnColumn_ColumnIndexOutOfMatrix()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            Assert.Throws<IndexOutOfRangeException>(() => newMatrixLed.SwitchOnColumn(17));
        }

        [Fact]
        public void SwitchOffColumn()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            newMatrixLed.SwitchOn();
            newMatrixLed.SwitchOffColumn(3);
            for (int r = 0; r < newMatrixLed.Matrix.GetLength(0); r++)
            {
                Assert.Equal(DeviceStatus.Off, newMatrixLed.Matrix[r, 2].Status);
            }
        }

        [Fact]
        public void SwitchOffColumn_ColumnIndexOutOfMatrix()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            Assert.Throws<IndexOutOfRangeException>(() => newMatrixLed.SwitchOffColumn(17));
        }

        [Fact]
        public void SetMatrixLedType_Lamp()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            Func<AbstractLamp> type = () => new Lamp(lampId, lampName);
            newMatrixLed.SetMatrixLedType(type);
            for (int r = 0; r < newMatrixLed.Matrix.GetLength(0); r++)
            {
                for (int c = 0; c < newMatrixLed.Matrix.GetLength(1); c++)
                {
                    Assert.IsType<Lamp>(newMatrixLed.Matrix[r, c]);
                }
            }
        }

        [Fact]
        public void SetMatrixLedType_EcoLamp()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            Func<AbstractLamp> type = () => new EcoLamp(lampName, lampId);
            newMatrixLed.SetMatrixLedType(type);
            for (int r = 0; r < newMatrixLed.Matrix.GetLength(0); r++)
            {
                for (int c = 0; c < newMatrixLed.Matrix.GetLength(1); c++)
                {
                    Assert.IsType<EcoLamp>(newMatrixLed.Matrix[r, c]);
                }
            }
        }

        [Fact]
        public void SetIntensity()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            Func<AbstractLamp> type = () => new Lamp(lampId, lampName);
            newMatrixLed.SetMatrixLedType(type);
            newMatrixLed.SwitchOn();
            newMatrixLed.SetIntensity(new Intensity(35));
            for (int r = 0; r < newMatrixLed.Matrix.GetLength(0); r++)
            {
                for (int c = 0; c < newMatrixLed.Matrix.GetLength(1); c++)
                {
                    Assert.Equal(new Intensity(35), newMatrixLed.Matrix[r, c].Intensity);
                }
            }
        }

        [Fact]
        public void SetIntensity_IntensityOutOfRange()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            newMatrixLed.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newMatrixLed.SetIntensity(new Intensity(911)));
        }

        [Fact]
        public void SetRowIntensity()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            newMatrixLed.SwitchOn();
            newMatrixLed.SetRowIntensity(3, new Intensity(20));
            for (int c = 0; c < newMatrixLed.Matrix.GetLength(1); c++)
            {
                Assert.Equal(new Intensity(20), newMatrixLed.Matrix[2, c].Intensity);
            }
        }

        [Fact]
        public void SetRowIntensity_IndexOutOfMatrix()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            newMatrixLed.SwitchOn();
            Assert.Throws<IndexOutOfRangeException>(() => newMatrixLed.SetRowIntensity(500, new Intensity(20)));
        }

        [Fact]
        public void SetRowIntensity_IntensityOutOfRange()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            newMatrixLed.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newMatrixLed.SetRowIntensity(3, new Intensity(200)));
        }

        [Fact]
        public void SetColumnIntensity()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            newMatrixLed.SwitchOn();
            newMatrixLed.SetColumnIntensity(3, new Intensity(20));
            for (int r = 0; r < newMatrixLed.Matrix.GetLength(0); r++)
            {
                Assert.Equal(new Intensity(20), newMatrixLed.Matrix[r, 2].Intensity);
            }
        }

        [Fact]
        public void SetColumnIntensity_IndexOutOfMatrix()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            newMatrixLed.SwitchOn();
            Assert.Throws<IndexOutOfRangeException>(() => newMatrixLed.SetColumnIntensity(500, new Intensity(20)));
        }

        [Fact]
        public void SetColumnIntensity_IntensityOutOfRange()
        {
            MatrixLed newMatrixLed = new MatrixLed(rows, columns, id, name);
            newMatrixLed.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => newMatrixLed.SetColumnIntensity(3, new Intensity(200)));
        }
    }
}
