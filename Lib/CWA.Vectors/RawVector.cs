/*=================================\
* CWA.Vectors\RawVector.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CWA.Vectors
{

    /// <summary>
    /// Промежуточный класс, представляющий вектор в байтовом виде.
    /// </summary>
    public class RawVector
    {
        /// <summary>
        /// Имя файла.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Ширина вектора.
        /// </summary>
        public UInt16 Width { get; set; }

        /// <summary>
        /// Высота вектора.
        /// </summary>
        public UInt16 Height { get; set; }

        /// <summary>
        /// Контрольные точки вектора.
        /// </summary>
        public Point[][] Points { get; set; }

        /// <summary>
        /// Приведение контрольных точек к стандартному для векторов библиотеки формату.
        /// </summary>
        public VPointEx[][] ToRawData()
        {
            return Points.Select(p => p.Select(pp => new VPointEx(pp.X, pp.Y)).ToArray()).ToArray();
        }

        /// <summary>
        /// Приведение стандартного представления векторов библиотеки формата к контрольным точкам.
        /// </summary>
        public void FillFromRawData(VPointEx[][] RawData)
        {
            Points = RawData.Select(p => p.Select(pp => new Point((int)pp.BasePoint.X, (int)pp.BasePoint.Y)).ToArray()).ToArray();
        }

        /// <summary>
        /// Приведение данного экземпляра к <see cref="Vector"/>.
        /// </summary>
        public Vector ToVector()
        {
            return new Vector(new Size(Width, Height), ToRawData());
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="RawVector"/>.
        /// </summary>
        /// <param name="Vect">Вектор, откуда будет взята информация.</param>
        public RawVector(Vector Vect)
        {
            FillFromRawData(Vect.RawData);
            Width = (UInt16)Vect.Size.Width;
            Height = (UInt16)Vect.Size.Height;
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="RawVector"/>.
        /// </summary>
        /// <param name="Vect">Вектор, откуда будет взята информация.</param>   
        /// <param name="RawData">Данные о векторе, которыми будет оперировать экземпляр.</param>
        public RawVector(Vector Vect, VPointEx[][] RawData)
        {
            FillFromRawData(RawData);
            Width = (UInt16)Vect.Size.Width;
            Height = (UInt16)Vect.Size.Height;
        }


        /// <summary>
        /// Создает новый экземпляр класса <see cref="RawVector"/>.
        /// </summary>
        /// <param name="bytes">Байты, полученные с помощью <see cref="ToBytes()"/>.</param>
        public RawVector(byte[] bytes)
        {
            Width = BitConverter.ToUInt16(bytes.Take(2).ToArray(), 0);
            Height = BitConverter.ToUInt16(bytes.Take(4).ToArray(), 2);
            UInt16 TotalCount = BitConverter.ToUInt16(bytes.Take(6).ToArray(), 4);
            var PointData = bytes.Skip(6).ToArray();
            Int32 ByteCounter = -2;
            Points = new Point[TotalCount][];
            for (Int32 i = 0; i < TotalCount; i++)
            {
                UInt16 CountOfPoints = BitConverter.ToUInt16(PointData, ByteCounter += 2);
                Points[i] = new Point[CountOfPoints];
                for (Int32 ii = 0; ii < CountOfPoints; ii++)
                {
                    Points[i][ii] = new Point(
                        BitConverter.ToUInt16(PointData, ByteCounter += 2),
                        BitConverter.ToUInt16(PointData, ByteCounter += 2));
                }
            }
        }

        /// <summary>
        /// Преобразованния вектора к массиву байтов.
        /// </summary>
        public byte[] ToBytes()
        {
            var result = new List<byte>();
            result.AddRange(BitConverter.GetBytes(Width));
            result.AddRange(BitConverter.GetBytes(Height));
            result.AddRange(BitConverter.GetBytes((UInt16)Points.Length));
            foreach (var item in Points)
            {
                result.AddRange(BitConverter.GetBytes((UInt16)item.Length));
                foreach (var subItem in item)
                {
                    result.AddRange(BitConverter.GetBytes((UInt16)subItem.X));
                    result.AddRange(BitConverter.GetBytes((UInt16)subItem.Y));
                }
            }
            return result.ToArray();
        }
    }
}
