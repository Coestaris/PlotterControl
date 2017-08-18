using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CnC_WFA
{
  /*  public abstract class IGraphDataSource
    {
        public SizeF GetInterval();
        public float GetValue(float arg);
    }*/

    [Serializable]
    public class SerializablePen
    {
        public SerializableColor Color { get; set; }
        public float Width { get; set; }

        public SerializablePen() { }

        public static implicit operator Pen(SerializablePen pen)
        {
            return new Pen(pen.Color, pen.Width);
        }
        
        public static implicit operator SerializablePen(Pen pen)
        {
            return new SerializablePen() { Color = pen.Color, Width = pen.Width };
        }
    }

    [Serializable]
    public class SerializableColor
    {
        public float A { get; set; }
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }

        public SerializableColor() { }

        public static implicit operator Color(SerializableColor col)
        {
            return Color.FromArgb((int)col.A, (int)col.R, (int)col.G, (int)col.B);
        }

        public static implicit operator SerializableColor(Color col)
        {
            return new SerializableColor() { A = col.A, R = col.R, B = col.B, G = col.G };
        }
    }

    public enum PenStyles
    {
        Solid,
        Dash
    }

    public enum GraphDataSource
    {
        Formula,
        File
    }

    public enum MarkerType
    {
        Circle,
        Square,
    }

    [Serializable]
    public class FormulaDataSource
    {
        #region CompStrings
        internal const string CompRangeEnvironment =
        @"
        using System;
        //using static System.Math;

        namespace Func
        {
            public static class Function
            {
                public static float MainFunction()
                {
                    double val = {formula};
                    return (float)val;
                }
            }
        }";

        private const string CompEnvironment =
        @"
        using System;
        //using static System.Math;

        namespace Func
        {
            public static class Function
            {
                public static float MainFunction(float x)
                {
                    double val = {formula};
                    return (float)val;
                }
            }
        }";
        #endregion

        private Func<float, float> func;
        public string LowLimFormula { get; set; }
        public string HighLimFormula { get; set; }
        public string Formula { get; set; }
        public float LowLim { get; set; }
        public float HighLim { get; set; }

        public FormulaDataSource() { }

        public List<string> CompileRange()
        {
            var CSHarpProvider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters compilerParams = new CompilerParameters()
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
            };
            compilerParams.ReferencedAssemblies.AddRange(new string[]
            {
                "System.dll",
            });
            compilerParams.IncludeDebugInformation = false;
            var compilerResultLow = CSHarpProvider.CompileAssemblyFromSource(compilerParams, CompRangeEnvironment.Replace("{formula}", LowLimFormula));
            var compilerResultHigh = CSHarpProvider.CompileAssemblyFromSource(compilerParams, CompRangeEnvironment.Replace("{formula}", HighLimFormula));

            if (compilerResultLow.Errors.Count == 0 && compilerResultHigh.Errors.Count == 0)
            {
                try
                {
                    var _baseTypeLow = compilerResultLow.CompiledAssembly.GetType("Func.Function");
                    var _baseTypeHigh = compilerResultHigh.CompiledAssembly.GetType("Func.Function");
                    HighLim = ((Func<float>)Delegate.CreateDelegate(typeof(Func<float>), _baseTypeHigh.GetMethod("MainFunction"))).Invoke();
                    LowLim  = ((Func<float>)Delegate.CreateDelegate(typeof(Func<float>), _baseTypeLow.GetMethod("MainFunction"))).Invoke();

                }
                catch (Exception e)
                {
                    var res = new List<string>();
                    res.Add(e.Message + ". Stack Trace: " + e.StackTrace);
                    return res;
                }
            }
            else
            {
                var res = new List<string>();
                if (compilerResultLow.Errors.Count != 0)
                {
                    foreach (var a in compilerResultLow.Errors)
                    {
                        var b = a.ToString();
                        res.Add('/' + b.Substring(b.IndexOf("CS")));
                    }
                }
                if (compilerResultHigh.Errors.Count != 0)
                {
                    foreach (var a in compilerResultHigh.Errors)
                    {
                        var b = a.ToString();
                        res.Add('\\' + b.Substring(b.IndexOf("CS")));
                    }
                }
                return res;
            }
            return null;
        }

        public List<string> Compile()
        {
            var CSHarpProvider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters compilerParams = new CompilerParameters()
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
            };
            compilerParams.ReferencedAssemblies.AddRange(new string[]
            {
                "System.dll",
            });
            compilerParams.IncludeDebugInformation = false;
            var compilerResult = CSHarpProvider.CompileAssemblyFromSource(compilerParams, CompEnvironment.Replace("{formula}", Formula));
            if (compilerResult.Errors.Count == 0)
            {
                try
                {
                    var _baseType = compilerResult.CompiledAssembly.GetType("Func.Function");
                    func = (Func<float, float>)Delegate.CreateDelegate(typeof(Func<float, float>), _baseType.GetMethod("MainFunction"));
                }
                catch (Exception e)
                {
                    var res = new List<string>();
                    res.Add(e.Message + ". Stack Trace: " + e.StackTrace);
                    return res;
                }
            }
            else
            {
                var res = new List<string>();
                foreach (var a in compilerResult.Errors)
                {
                    var b = a.ToString();
                    res.Add(b.Substring(b.IndexOf("CS")));
                }
                return res;
            }
            return null;
        }

        public SizeF GetInterval()
        {
            return new SizeF(LowLim, HighLim);
        }

        public float GetValue(float arg)
        {
            return func(arg);
        }
    }

    [Serializable]
    public class GraphMarkers
    {
        public bool Use { get; set; }
        public bool UsePeriodic { get; set; }
        //***Display
        public List<float> Points { get; set; }
        public float Size { get; set; }
        public MarkerType Type { get; set; }
        public SerializableColor Color { get; set; }
        //***Periodic Members
        public bool AutoLims { get; set; }
        public string LowLimFormula { get; set; }
        public string HighLimFormula { get; set; }
        public string PeriodFormula { get; set; }
        public float Period { get; set; }
        public float LowLim { get; set; }
        public float HighLim { get; set; }
        //***Non-Periodic Members
        public List<string> PointFormulas { get; set; }

        public GraphMarkers() { }

        public List<string> CompilePeriod()
        {
            var CSHarpProvider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters compilerParams = new CompilerParameters()
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
            };
            compilerParams.ReferencedAssemblies.AddRange(new string[]
            {
                "System.dll",
            });
            compilerParams.IncludeDebugInformation = false;

            var compilerResultPeriod = CSHarpProvider.CompileAssemblyFromSource(compilerParams, FormulaDataSource.CompRangeEnvironment.Replace("{formula}", PeriodFormula));
            var compilerResultLow = CSHarpProvider.CompileAssemblyFromSource(compilerParams, FormulaDataSource.CompRangeEnvironment.Replace("{formula}", LowLimFormula));
            var compilerResultHigh = CSHarpProvider.CompileAssemblyFromSource(compilerParams, FormulaDataSource.CompRangeEnvironment.Replace("{formula}", HighLimFormula));

            if (compilerResultLow.Errors.Count == 0 && compilerResultHigh.Errors.Count == 0 && compilerResultPeriod.Errors.Count == 0)
            {
                try
                {
                    var _baseTypeLow = compilerResultLow.CompiledAssembly.GetType("Func.Function");
                    var _baseTypeHigh = compilerResultHigh.CompiledAssembly.GetType("Func.Function");
                    var _baseTypePeriod = compilerResultPeriod.CompiledAssembly.GetType("Func.Function");
                    Period = ((Func<float>)Delegate.CreateDelegate(typeof(Func<float>), _baseTypePeriod.GetMethod("MainFunction"))).Invoke();
                    HighLim = ((Func<float>)Delegate.CreateDelegate(typeof(Func<float>), _baseTypeHigh.GetMethod("MainFunction"))).Invoke();
                    LowLim = ((Func<float>)Delegate.CreateDelegate(typeof(Func<float>), _baseTypeLow.GetMethod("MainFunction"))).Invoke();

                }
                catch (Exception e)
                {
                    var res = new List<string>();
                    res.Add(e.Message + ". Stack Trace: " + e.StackTrace);
                    return res;
                }
            }
            else
            {
                var res = new List<string>();
                if (compilerResultLow.Errors.Count != 0)
                {
                    foreach (var a in compilerResultLow.Errors)
                    {
                        var b = a.ToString();
                        res.Add('/' + b.Substring(b.IndexOf("CS")));
                    }
                }
                if (compilerResultHigh.Errors.Count != 0)
                {
                    foreach (var a in compilerResultHigh.Errors)
                    {
                        var b = a.ToString();
                        res.Add('\\' + b.Substring(b.IndexOf("CS")));
                    }
                }
                if (compilerResultPeriod.Errors.Count != 0)
                {
                    foreach (var a in compilerResultPeriod.Errors)
                    {
                        var b = a.ToString();
                        res.Add('|' + b.Substring(b.IndexOf("CS")));
                    }
                }
                return res;
            }
            return null;
        }

        public void GetPoints()
        {
            Points = new List<float>();
            for (float i = LowLim; i<=HighLim; i += Period) Points.Add(i);
        }
    }

    [Serializable]
    public class GraphDocAxis
    {
        public bool Show { get; set; }
        public SerializableColor Color { get; set; }
        public float Width { get; set; }
        public bool UseUnlimited { get; set; }
        public float XOffset { get; set; }
        public float YOffset{ get; set; }

        public GraphDocAxis() { }
    }

    [Serializable]
    public class Graph: ICloneable
    {
        private GraphicsPath preRenderedGraph;
        private GraphicsPath prerenderedMarkers;
        public SerializablePen MainPen { get; set; }
        public PenStyles PStyle { get; set; }
        public bool Display { get; set; }
        public GraphMarkers Markers { get; set; }
        public string Name { get; set; }
        public FormulaDataSource DataSource { get; set; }
        public float MaxValue { get; set; }
        public float MinValue { get; set; }

        const float Step = .01f;
        const float Delta = .01f;
        //SharpDX
        
        public Graph()
        {
            Display = true;
            MainPen = Pens.Black;
            ResetPreRender();
        }

        public Graph(FormulaDataSource DataSource, string Name)
        {
            Display = true;
            MainPen = Pens.Black;
            this.DataSource = DataSource;
            this.Name = Name;
            ResetPreRender();
        }

        private void BuildGraph()
        {
            if (Display)
            {
                GraphicsPath a = new GraphicsPath();
                SizeF Lims = DataSource.GetInterval();
                List<PointF> points = new List<PointF>();

                MinValue = float.MaxValue;
                MaxValue = float.MinValue;

                for (float i = Lims.Width; i <= Lims.Height; i += Step)
                {
                    var val = DataSource.GetValue(i);
                    if(float.IsInfinity(val))
                    {
                        var v = float.IsPositiveInfinity(val) ? float.MinValue : float.MaxValue;

                        // points.Add(new PointF(i, float.IsPositiveInfinity(val) ? -float.MaxValue : float.MaxValue));
                        points.Add(new PointF(i, v));
                        if (v > MaxValue) MaxValue = v;
                        if (v < MinValue) MinValue = v;
                    }
                    if (!float.IsNaN(val))
                    {
                        points.Add(new PointF(i, -val));
                        if (val > MaxValue) MaxValue = val;
                        if (val < MinValue) MinValue = val;
                    }
                }
                a.AddLines(points.ToArray());
                preRenderedGraph = a;
            }
            else preRenderedGraph = new GraphicsPath();
        }

        public void ResetPreRender()
        {
            prerenderedMarkers = null;
            preRenderedGraph = null;
            MaxValue = 0;
            MinValue = 0;
        }

        public void PrerenderMarkers()
        {
            /*
            Markers.GetPoints();
            var a = new GraphicsPath();
            foreach (var item in Markers.Points)
            {
                if (Markers.Type == MarkerType.Circle)
                    a.AddEllipse(item - Markers.Size / 2, - dataSource.GetValue(item) - Markers.Size / 2, Markers.Size, Markers.Size);
                else a.AddRectangle(new RectangleF(item - Markers.Size / 2, -dataSource.GetValue(item) - Markers.Size / 2, Markers.Size, Markers.Size));
            }
            prerenderedMarkers = a;*/
        }

        public GraphicsPath BuildMarkers()
        {
            if (prerenderedMarkers == null) PrerenderMarkers();
            return (GraphicsPath)prerenderedMarkers.Clone();
        }

        public GraphicsPath Build()
        {
            if (preRenderedGraph == null) BuildGraph();
            return (GraphicsPath)preRenderedGraph.Clone();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

    }
    
    [Serializable]
    public class GraphDoc
    {
        internal const float GraphDocVers = 1.1f;
        public float LocalGraphDocVers { get; set; }

        private GraphicsPath preRenderedXAxis, preRenderedYAxis;
        public List<Graph> Graphs { get; set; }
        public GraphDocAxis AxisParams { get; set; }

        public GraphDoc()
        {
            Graphs = new List<Graph>();
        }

        private void PreRenderXAxis()
        {
            if (!AxisParams.UseUnlimited)
            {
                GraphicsPath a = new GraphicsPath();
                float min = Graphs.Select(p => p.DataSource.GetInterval().Width).Min();
                float max = Graphs.Select(p => p.DataSource.GetInterval().Height).Max();
                a.AddLine(new PointF(min - AxisParams.XOffset, 0), new PointF(max + AxisParams.YOffset, 0));
                preRenderedXAxis = a;
            }
            else
            {
                GraphicsPath a = new GraphicsPath();
                a.AddLine(new PointF(-9999, 0), new PointF(9999, 0));
                preRenderedXAxis = a;
            }
        }

        private void PreRenderYAxis()
        {
            if (!AxisParams.UseUnlimited)
            {
                GraphicsPath a = new GraphicsPath();
                float min = Graphs.Select(p => p.MinValue).Min();
                float max = Graphs.Select(p => p.MaxValue).Max();
                a.AddLine(new PointF(0, -min + AxisParams.XOffset), new PointF(0, -max - AxisParams.YOffset));
                preRenderedYAxis = a;
            }
            else
            {
                GraphicsPath a = new GraphicsPath();
                a.AddLine(new PointF(0, -9999), new PointF(0, 9999));
                preRenderedYAxis = a;
            }
        }

        public void ResetPrerender()
        {
            preRenderedXAxis = null;
            preRenderedYAxis = null;
        }

        public GraphicsPath GetXAxis()
        {
            if (preRenderedXAxis == null) PreRenderXAxis();
            return (GraphicsPath)preRenderedXAxis.Clone();
        }

        public GraphicsPath GetYAxis()
        {
            if (preRenderedYAxis == null) PreRenderYAxis();
            return (GraphicsPath)preRenderedYAxis.Clone();
        }

        public void Save(string FileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(GraphDoc));
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }

        public static GraphDoc Load(string FileName)
        {
            GraphDoc result;
            XmlSerializer formatter = new XmlSerializer(typeof(GraphDoc));
            using (FileStream fs = new FileStream(FileName, FileMode.Open))
            {
                result = (GraphDoc)formatter.Deserialize(fs);
                foreach (var item in result.Graphs)
                {
                    item.DataSource.Compile();
                    item.DataSource.CompileRange();
                    if (item.Markers.Use)
                        if (item.Markers.UsePeriodic) item.Markers.CompilePeriod();
                }
            }
            if (result.LocalGraphDocVers == 0 || result.LocalGraphDocVers < GraphDocVers) throw new InvalidDataException(string.Format("Обнаружена проблема несовместимости версий. Вы пытаетесь загрузить файл версии {0}, когда актуальная - {1}. Загрузка была прервана с целью предотвращения дальнейших ошибок.\nВы можете попробовать решить проблему, изменив версию формата в файле, что может привести только к большим ошибкам. Желаю удачи ;)", result.LocalGraphDocVers, GraphDocVers));
            return result;
        }
    }
}