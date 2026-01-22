using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous
{
    public sealed class MatrixLed: AbstractLamp
    {
        public AbstractLamp[,] Matrix;
        public MatrixLed(int rows, int columns, Guid id, string name): base(id, name) {
            Matrix = new AbstractLamp[rows, columns];
        }

        public void AddChangeLamp(AbstractLamp type, int rowNumber, int columnNumber)
        {
            if (rowNumber > Matrix.GetLength(0) || columnNumber > Matrix.GetLength(1)
                || rowNumber < 1 || columnNumber < 1)
                throw new Exception("Valori inseriti non validi.");
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
        public void TurnOnRow(int rowNumber)
        {
            if (rowNumber < 1 || rowNumber > Matrix.GetLength(0))
                throw new Exception("Valore non valido.");
            for (int c=0; c<Matrix.GetLength(1); c++)
            {
                Matrix[rowNumber - 1, c].SwitchOn();
            }
        }
        public void TurnOffRow(int rowNumber)
        {
            if (rowNumber < 1 || rowNumber > Matrix.GetLength(0))
                throw new Exception("Valore non valido.");
            for (int c = 0; c < Matrix.GetLength(1); c++)
            {
                Matrix[rowNumber - 1, c].SwitchOn();
            }
        }
        public void TurnOnColumn(int columnNumber)
        {
            if (columnNumber < 1 || columnNumber > Matrix.GetLength(0))
                throw new Exception("Valore non valido.");
            for (int r = 0; r < Matrix.GetLength(0); r++)
            {
                Matrix[r, columnNumber - 1].SwitchOn();
            }
        }
        public void TurnOffColumn(int columnNumber)
        {
            if (columnNumber < 1 || columnNumber > Matrix.GetLength(0))
                throw new Exception("Valore non valido.");
            for (int r = 0; r < Matrix.GetLength(0); r++)
            {
                Matrix[r, columnNumber - 1].SwitchOff();
            }
        }
        public void SetMatrixLedType(AbstractLamp type)
        {
            for (int r = 0; r < Matrix.GetLength(0); r++)
            {
                for (int c = 0; c < Matrix.GetLength(1); c++)
                {
                    Matrix[r, c] = type;
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
                throw new Exception("Valore non valido.");
            for (int c = 0; c < Matrix.GetLength(1); c++)
            {
                Matrix[rowNumber - 1, c].SetIntensity(intensity);
            }
        }
        public void SetColumnIntensity(int columnNumber, int intensity)
        {
            if (columnNumber < 1 || columnNumber > Matrix.GetLength(0))
                throw new Exception("Valore non valido.");
            for (int r = 0; r < Matrix.GetLength(0); r++)
            {
                Matrix[r, columnNumber - 1].SwitchOn();
            }
        }
    }
}
