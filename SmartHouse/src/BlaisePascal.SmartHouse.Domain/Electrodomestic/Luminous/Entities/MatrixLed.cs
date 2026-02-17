using BlaisePascal.SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities
{
    public sealed class MatrixLed: AbstractLamp
    {
        public AbstractLamp[,] Matrix;
        public MatrixLed(int rows, int columns, Name name): base( name) {
            Matrix = new AbstractLamp[rows, columns];
            for(int r = 0; r < Matrix.GetLength(0); r++)
            {
                for(int c = 0; c < Matrix.GetLength(1); c++)
                {
                    Matrix[r, c] = new Lamp(new Name("Default Lamp"));
                }
            }
        }

        public void AddChangeLamp(AbstractLamp type, int rowNumber, int columnNumber)
        {
            if (rowNumber > Matrix.GetLength(0) || columnNumber > Matrix.GetLength(1)
                || rowNumber < 1 || columnNumber < 1)
                throw new IndexOutOfRangeException("Valori inseriti non validi.");
            Matrix[rowNumber - 1, columnNumber - 1] = type;
        }
        public override void SwitchOn()
        {
            for (int r = 0; r < Matrix.GetLength(0); r++)
            {
                for (int c = 0; c < Matrix.GetLength(1); c++)
                {
                    Matrix[r, c].SwitchOn();
                }
            }
        }
        public override void SwitchOff()
        {
            for (int r = 0; r < Matrix.GetLength(0); r++)
            {
                for (int c = 0; c < Matrix.GetLength(1); c++)
                {
                    Matrix[r, c].SwitchOff();
                }
            }
        }
        public void SwitchOnRow(int rowNumber)
        {
            if (rowNumber < 1 || rowNumber > Matrix.GetLength(0))
                throw new IndexOutOfRangeException("Valore non valido.");
            for (int c=0; c<Matrix.GetLength(1); c++)
            {
                Matrix[rowNumber - 1, c].SwitchOn();
            }
        }
        public void SwitchOffRow(int rowNumber)
        {
            if (rowNumber < 1 || rowNumber > Matrix.GetLength(0))
                throw new IndexOutOfRangeException("Valore non valido.");
            for (int c = 0; c < Matrix.GetLength(1); c++)
            {
                Matrix[rowNumber - 1, c].SwitchOff();
            }
        }
        public void SwitchOnColumn(int columnNumber)
        {
            if (columnNumber < 1 || columnNumber > Matrix.GetLength(0))
                throw new IndexOutOfRangeException("Valore non valido.");
            for (int r = 0; r < Matrix.GetLength(0); r++)
            {
                Matrix[r, columnNumber - 1].SwitchOn();
            }
        }
        public void SwitchOffColumn(int columnNumber)
        {
            if (columnNumber < 1 || columnNumber > Matrix.GetLength(0))
                throw new IndexOutOfRangeException("Valore non valido.");
            for (int r = 0; r < Matrix.GetLength(0); r++)
            {
                Matrix[r, columnNumber - 1].SwitchOff();
            }
        }
        public void SetMatrixLedType(Func<AbstractLamp> type)
        {
            for (int r = 0; r < Matrix.GetLength(0); r++)
            {
                for (int c = 0; c < Matrix.GetLength(1); c++)
                {
                    Matrix[r, c] = type();
                }
            }
        }
        public override void SetIntensity(Intensity intensity)
        {
            for (int r = 0; r < Matrix.GetLength(0); r++)
            {
                for (int c = 0; c < Matrix.GetLength(1); c++)
                {
                    Matrix[r,c].SetIntensity(intensity);
                }
            }
        }
        public void SetRowIntensity(int rowNumber, Intensity intensity)
        {
            if (rowNumber < 1 || rowNumber > Matrix.GetLength(0))
                throw new IndexOutOfRangeException("Valore non valido.");
            for (int c = 0; c < Matrix.GetLength(1); c++)
            {
                Matrix[rowNumber - 1, c].SetIntensity(intensity);
            }
        }
        public void SetColumnIntensity(int columnNumber, Intensity intensity)
        {
            if (columnNumber < 1 || columnNumber > Matrix.GetLength(1))
                throw new IndexOutOfRangeException("Valore non valido.");
            for (int r = 0; r < Matrix.GetLength(0); r++)
            {
                Matrix[r, columnNumber - 1].SetIntensity(intensity);
            }
        }
    }
}
