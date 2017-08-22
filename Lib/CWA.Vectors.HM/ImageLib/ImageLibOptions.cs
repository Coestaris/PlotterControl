/*=================================\
* CWA.Vectors.HM\ImageLibOptions.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:41
* Last Edited: 22.08.2017 20:40:43
*=================================*/

namespace CWA.Vectors
{
    /// <summary>
    /// Описывает опции для класса VectLib.
    /// </summary>
    public class ImageLibOptions
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
        public ImageLibOptions()
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
