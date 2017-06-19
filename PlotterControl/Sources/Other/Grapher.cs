using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CnC_WFA
{
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

    public interface IGraphDataSource
    {
        SizeF GetInterval();
        float GetValue(float arg);
    }

    public class FormulaDataSource: IGraphDataSource
    {
        public string lowLimFormula, highLimFormula;
        public string formula;
        public float LowLim, HighLim;
        private Func<float, float> func;
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
            var compilerResultLow = CSHarpProvider.CompileAssemblyFromSource(compilerParams, CompRangeEnvironment.Replace("{formula}", lowLimFormula));
            var compilerResultHigh = CSHarpProvider.CompileAssemblyFromSource(compilerParams, CompRangeEnvironment.Replace("{formula}", highLimFormula));

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
            var compilerResult = CSHarpProvider.CompileAssemblyFromSource(compilerParams, CompEnvironment.Replace("{formula}", formula));
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

    public enum MarkerType
    {
        Circle,
        Square,
    }

    public class GraphMarkers
    {
        public bool Use;
        
        public bool UsePeriodic;

        //***Periodic Members
        public bool AutoLims;
        public string LowLimFormula, HighLimFormula, PeriodFormula;
        public float Period, LowLim, HighLim;

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

        //***Non-Periodic Members
        public List<string> PointFormulas;
        //*** 

        public List<float> Points;
        public float Size;
        public MarkerType Type;
        public Color Color;
    }

    public struct GraphDocAxis
    {
        public bool Show;
        public Color Color;
        public float Width;
        public bool UseUnlimited;
        public float XOffset, YOffset;
    }

    public class Graph: ICloneable
    {
        public Pen MainPen;
        public PenStyles PStyle;
        public bool Display;

        public GraphMarkers Markers;

        //SharpDX

        public string Name;
        public IGraphDataSource dataSource { get; set; }
        
        public Graph()
        {
            Display = true;
            MainPen = Pens.Black;
            ResetPreRender();
        }

        public Graph(IGraphDataSource DataSource, string Name)
        {
            Display = true;
            MainPen = Pens.Black;
            dataSource = DataSource;
            this.Name = Name;
            ResetPreRender();
        }

        public float MaxValue, MinValue;

        private GraphicsPath preRenderedGraph;
        private GraphicsPath prerenderedMarkers;

        const float Step = .01f;
        const float Delta = .01f;

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

        private void BuildGraph()
        {
            if (Display)
            {
                GraphicsPath a = new GraphicsPath();
                SizeF Lims = dataSource.GetInterval();
                List<PointF> points = new List<PointF>();

                MinValue = float.MaxValue;
                MaxValue = float.MinValue;

                for (float i = Lims.Width; i <= Lims.Height; i += Step)
                {
                    var val = dataSource.GetValue(i);
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

    public class GraphDoc
    {
        private GraphicsPath preRenderedXAxis, preRenderedYAxis;

        public List<Graph> Graphs;

        public GraphDoc()
        {
            Graphs = new List<Graph>();
        }

        public void ResetPrerender()
        {
            preRenderedXAxis = null;
            preRenderedYAxis = null;
        }

        private void PreRenderXAxis()
        {
            if (!AxisParams.UseUnlimited)
            {
                GraphicsPath a = new GraphicsPath();
                float min = Graphs.Select(p => p.dataSource.GetInterval().Width).Min();
                float max = Graphs.Select(p => p.dataSource.GetInterval().Height).Max();
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

        public GraphDocAxis AxisParams;

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
    }
}