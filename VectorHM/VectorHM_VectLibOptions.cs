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

namespace CWA.Vectors
{
    /// <summary>
    /// Описывает опции для класса VectLib.
    /// </summary>
    public class VectLibOptions
    {
        /// <summary>
        /// Приватный параметр. Коофициент преобразования в черно-белый формат красного каныала.
        /// </summary>
        private float _grayConvertRCof;

        /// <summary>
        /// Приватный параметр. Коофициент преобразования в черно-белый формат зеленого канала.
        /// </summary>
        private float _grayConvertGCof;

        /// <summary>
        /// Приватный параметр. Коофициент преобразования в черно-белый формат синего канала.
        /// </summary>
        private float _grayConvertBCof;

        /// <summary>
        /// Приватный параметр. Определяет значение интенсивности размытия по Гаусу.
        /// </summary>
        private float _gaussBlurSigma;

        /// <summary>
        /// Приватный параметр. Определяет значение коофициента в формуле размытия по Гаусу.
        /// </summary>
        private short _gaussBlurKCof;

        /// <summary>
        /// Приватный параметр. Указывает на то, будет ли использоватся размытие по Гауссу.
        /// </summary>
        private bool _useGaussBlur;

        /// <summary>
        /// Приватный параметр. Определяет предел обнаружения оператора Собеля.
        /// </summary>
        private int _sobelOperatorLimFonf;

        /// <summary>
        /// Приватный параметр. Указывает множитель увеличения изображения алгоритмом HQNX. 
        /// Может принемать значения: 1 (не увеличевать), 2 (увеличить в 2 раза), 3 и 4. Остальные значения будут игнорироватся.
        /// </summary>
        private int _hqxScaleMult;

        /// <summary>
        /// Приватный параметр. Количество потоков выполнения векторизации.
        /// </summary>
        private int _prStreamsCount;

        /// <summary>
        /// Приватный параметр. Определяет, будет ли выводится в консоль отладочная информация о процессе векторизации.
        /// </summary>
        private bool _debugPrSay;

        /// <summary>
        /// Приватный параметр. Определяет, сохранится ли при окончании векторизации обьедененный файл с промежуточными результатами.
        /// </summary>
        private bool _debugSaveMergedResult;

        /// <summary>
        /// Приватный параметр. Определяет, будут ли сохранятся промежуточные этапы векторизации.
        /// </summary>
        private bool _debugSavePrticalResults;

        /// <summary>
        /// Коофициент преобразования в черно-белый формат красного каныала.
        /// </summary>
        public float GrayConvertRCof
        {
            get { return _grayConvertRCof; }
            set { _grayConvertRCof = value; }
        }

        /// <summary>
        /// Коофициент преобразования в черно-белый формат зеленого канала.
        /// </summary>
        public float GrayConvertGCof
        {
            get { return _grayConvertGCof; }
            set { _grayConvertGCof = value; }
        }

        /// <summary>
        /// Коофициент преобразования в черно-белый формат синего канала.
        /// </summary>
        public float GrayConvertBCof
        {
            get { return _grayConvertBCof; }
            set { _grayConvertBCof = value; }
        }
        
        /// <summary>
        /// Определяет значение интенсивности размытия по Гаусу.
        /// </summary>
        public float GaussBlurSigma
        {
            get { return _gaussBlurSigma; }
            set { _gaussBlurSigma = value; }
        }

        /// <summary>
        /// Определяет значение коофициента в формуле размытия по Гаусу.
        /// </summary>
        public short GaussBlurKCof
        {
            get { return _gaussBlurKCof; }
            set { _gaussBlurKCof = value; }
        }

        /// <summary>
        /// Указывает на то, будет ли использоватся размытие по Гауссу.
        /// </summary>
        public bool UseGaussBlur
        {
            get { return _useGaussBlur; }
            set { _useGaussBlur = value; }
        }

        /// <summary>
        /// Определяет предел обнаружения оператора Собеля.
        /// </summary>
        public int SobelOperatorLimFonf
        {
            get { return _sobelOperatorLimFonf; }
            set { _sobelOperatorLimFonf = value; }
        }

        /// <summary>
        /// Указывает множитель увеличения изображения алгоритмом HQNX. 
        /// Может принемать значения: 1 (не увеличевать), 2 (увеличить в 2 раза), 3 и 4. Остальные значения будут игнорироватся.
        /// </summary>
        public int HqxScaleMult
        {
            get { return _hqxScaleMult; }
            set { _hqxScaleMult = value; }
        }

        /// <summary>
        /// Количество потоков выполнения векторизации.
        /// </summary>
        public int PrStreamsCount
        {
            get { return _prStreamsCount; }
            set { _prStreamsCount = value; }
        }

        /// <summary>
        /// Определяет, будет ли выводится в консоль отладочная информация о процессе векторизации.
        /// </summary>
        public bool DebugPrSay
        {
            get { return _debugPrSay; }
            set { _debugPrSay = value; }
        }

        /// <summary>
        /// Определяет, сохранится ли при окончании векторизации обьедененный файл с промежуточными результатами.
        /// </summary>
        public bool DebugSaveMergedResult
        {
            get { return _debugSaveMergedResult; }
            set { _debugSaveMergedResult = value; }
        }

        /// <summary>
        /// Определяет, будут ли сохранятся промежуточные этапы векторизации.
        /// </summary>
        public bool DebugSavePrticalResults
        {
            get { return _debugSavePrticalResults; }
            set { _debugSavePrticalResults = value; }
        }

        /// <summary>
        /// Создает новый экземпляр класса VectLibOptions. 
        /// </summary>
        public VectLibOptions()
        {
            SetDefault();
        }

        /// <summary>
        /// Устанавливает все значения по умолчанию.
        /// </summary>
        public void SetDefault()
        {
            GrayConvertRCof = 0.299f;
            GrayConvertGCof = 0.587f;
            GrayConvertBCof = 0.114f;
            GaussBlurSigma = 1.2f;
            GaussBlurKCof = 7;
            UseGaussBlur = true;
            SobelOperatorLimFonf = 80;
            HqxScaleMult = 1;
            PrStreamsCount = 1;
            DebugPrSay = false;
            DebugSaveMergedResult = false;
            DebugSavePrticalResults = false;
        }
    }

}
