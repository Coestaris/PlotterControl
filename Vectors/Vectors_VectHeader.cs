/*
    The MIT License(MIT)

    Copyright (c) 2016 - 2017 Kurylko Maxim Igorevich

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:
    
    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.
    
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

*/

using System.Collections.Generic;

namespace CWA.Vectors
{
    /// <summary>
    /// Предоставляет информацию о векторе.
    /// </summary>
    public class VectHeader
    {
        /// <summary>
        /// Приватный параметр. Тип получения вектора.
        /// </summary>
        private VectType _type;

        /// <summary>
        /// Приватный параметр. Ширина вектора.
        /// </summary>
        private double _width;

        /// <summary>
        /// Приватный параметр. Высота вектора.
        /// </summary>
        private double _height;

        /// <summary>
        /// Приватный параметр. Количество контуров вектора.
        /// </summary>
        private int _cnum;

        /// <summary>
        /// Приватный параметр. Дополнительные параметеры вектора.
        /// </summary>
        private Dictionary<string, string> _exparams;

        /// <summary>
        /// Ширина вектора.
        /// </summary>
        public double Width
        {
            get { return _width; }
            internal set { _width = value; }
        }

        /// <summary>
        /// Высота вектора.
        /// </summary>
        public double Height
        {
            get { return _height; }
            internal set { _height = value; }
        }

        /// <summary>
        /// Тип получения вектора.
        /// </summary>
        public VectType VectType
        {
            get { return _type; }
            internal set { _type = value; }
        }

        /// <summary>
        /// Количество контуров вектора.
        /// </summary>
        public int CountOfCont
        {
            get { return _cnum; }
            internal set { _cnum = value; }
        }

        /// <summary>
        /// Дополнительные параметеры вектора.
        /// </summary>
        public Dictionary<string, string> ExParams
        {
            get { return _exparams; }
        }

        /// <summary>
        /// Оператор сравнения хедеров.
        /// </summary>
        public static bool operator ==(VectHeader a, VectHeader b)
        {
            return a._type == b._type && a._width == b._width && a._height == b._height && a._cnum == b._cnum && a._exparams == b._exparams;
        }

        /// <summary>
        /// Оператор неравенства хедеров.
        /// </summary>
        public static bool operator !=(VectHeader a, VectHeader b)
        {
            return a._type != b._type || a._width != b._width || a._height != b._height || a._cnum != b._cnum || a._exparams != b._exparams;
        }

        /// <summary>
        /// Сравнивает данный хедер с obj.
        /// </summary>
        public override bool Equals(object obj)
        {
            return this == (VectHeader)obj;
        }

        /// <summary>
        /// Возвращает хеш-код класса.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
