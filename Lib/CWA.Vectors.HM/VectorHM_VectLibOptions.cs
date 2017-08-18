/*
	The MIT License(MIT)

	Copyright(c) 2016 - 2017 Kurylko Maxim Igorevich

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
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
*/

/*=================================\
* CWA.Vectors.HM \ VectorHM_VectLibOptions.cs
*
* Created: 06.08.2017 20:20
* Last Edited: 18.08.2017 20:23:27
*
*=================================*/

namespace CWA.Vectors
{
    /// <summary>
    /// Описывает опции для класса VectLib.
    /// </summary>
    public class VectLibOptions
    {
        /// <summary>
        /// Коофициент преобразования в черно-белый формат красного каныала.
        /// </summary>
        public float GrayConvertRCof { get; set; }

        /// <summary>
        /// Коофициент преобразования в черно-белый формат зеленого канала.
        /// </summary>
        public float GrayConvertGCof { get; set; }

        /// <summary>
        /// Коофициент преобразования в черно-белый формат синего канала.
        /// </summary>
        public float GrayConvertBCof { get; set; }

        /// <summary>
        /// Определяет значение интенсивности размытия по Гаусу.
        /// </summary>
        public float GaussBlurSigma { get; set; }

        /// <summary>
        /// Определяет значение коофициента в формуле размытия по Гаусу.
        /// </summary>
        public short GaussBlurKCof { get; set; }

        /// <summary>
        /// Указывает на то, будет ли использоватся размытие по Гауссу.
        /// </summary>
        public bool UseGaussBlur { get; set; }

        /// <summary>
        /// Определяет предел обнаружения оператора Собеля.
        /// </summary>
        public int SobelOperatorLimFonf { get; set; }

        /// <summary>
        /// Указывает множитель увеличения изображения алгоритмом HQNX. 
        /// Может принемать значения: 1 (не увеличевать), 2 (увеличить в 2 раза), 3 и 4. Остальные значения будут игнорироватся.
        /// </summary>
        public int HqxScaleMult { get; set; }

        /// <summary>
        /// Количество потоков выполнения векторизации.
        /// </summary>
        public int PrStreamsCount { get; set; }

        /// <summary>
        /// Определяет, будет ли выводится в консоль отладочная информация о процессе векторизации.
        /// </summary>
        public bool DebugPrSay { get; set; }

        /// <summary>
        /// Определяет, сохранится ли при окончании векторизации обьедененный файл с промежуточными результатами.
        /// </summary>
        public bool DebugSaveMergedResult { get; set; }

        /// <summary>
        /// Определяет, будут ли сохранятся промежуточные этапы векторизации.
        /// </summary>
        public bool DebugSavePrticalResults { get; set; }

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
