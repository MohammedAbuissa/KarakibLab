using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Media;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI;
namespace KarakibLab
{
    using path = Windows.UI.Xaml.Shapes.Path;
    class Template : Grid
    {
        
        public Template(String Data):base()
        {
            path[] hello = this.KTSerializer(Data);
            for (int i = 0; i < 2; i++)
                this.Children.Add(hello[i]);
        }
        enum Paths
        {
            Transparent, Opaque
        }
        private PathFigure Parse(String Data)
        {
            List<List<String>> Split = Spliter(Data);
            PathFigure figure = new PathFigure();
            foreach (List<String> item in Split)
            {
                switch (item[0])
                {
                    case "M":
                        figure.StartPoint = new Point(Double.Parse(item[1]), Double.Parse(item[2]));
                        for (int i = 3; i < item.Count;)
                            figure.Segments.Add(new LineSegment { Point = new Point(Double.Parse(item[i++]), Double.Parse(item[i++])) });
                        break;
                    case "L":
                        for (int i = 1; i < item.Count;)
                            figure.Segments.Add(new LineSegment { Point = new Point(Double.Parse(item[i++]), Double.Parse(item[i++])) });
                        break;
                    case "H":
                        for (int i = 1; i < item.Count;)
                            figure.Segments.Add(new LineSegment { Point = new Point(Double.Parse(item[i++]), (figure.Segments[figure.Segments.Count - 1] as LineSegment).Point.Y) });
                        break;
                    case "V":
                        for (int i = 1; i < item.Count;)
                            figure.Segments.Add(new LineSegment { Point = new Point((figure.Segments[figure.Segments.Count - 1] as LineSegment).Point.X, Double.Parse(item[i++])) });
                        break;
                    case "C":
                        for (int i = 1; i < item.Count;)
                            figure.Segments.Add(new BezierSegment { Point1 = new Point(Double.Parse(item[i++]), Double.Parse(item[i++])), Point2 = new Point(Double.Parse(item[i++]), Double.Parse(item[i++])), Point3 = new Point(Double.Parse(item[i++]), Double.Parse(item[i++])) });
                        break;
                    case "Q":
                        for (int i = 1; i < item.Count;)
                            figure.Segments.Add(new QuadraticBezierSegment { Point1 = new Point(Double.Parse(item[i++]), Double.Parse(item[i++])), Point2 = new Point(Double.Parse(item[i++]), Double.Parse(item[i++])) });
                        break;
                    case "S":
                        throw new NotImplementedException();
                    case "T":
                        throw new NotImplementedException();
                    case "A":
                        for (int i = 1; i < item.Count;)
                            figure.Segments.Add(new ArcSegment { Size = new Size(Double.Parse(item[i++]), Double.Parse(item[i++])), RotationAngle = Double.Parse(item[i++]), IsLargeArc = (Double.Parse(item[i++]) == 1.0), SweepDirection = Double.Parse(item[i++]) == 1.0 ? SweepDirection.Clockwise : SweepDirection.Counterclockwise, Point = new Point(Double.Parse(item[i++]), Double.Parse(item[i++]))});
                        break;
                    case "Z":
                        figure.IsClosed = true;
                        break;
                }
            }
            return figure;
        }
        private List<List<String>> Spliter (String Data)
        {
            Char[] Commands = new char[] {'L', 'H','V','C','Q','S','T','A','M','Z' };
            Array.Sort<Char>(Commands);
            List<Int32> CommandLocation = new List<int>();
            int index;
            //detect palces of commands
            for (int i = 0; i < Data.Length; i++)
            {
                index = Array.BinarySearch<Char>(Commands, Char.ToUpper(Data[i]));
                if (index >= 0)
                    CommandLocation.Add(i);
            }
            List<List<String>> Result = new List<List<String>>(CommandLocation.Count);
            //split commands data
            for (int i = 0; i < CommandLocation.Count-1; i++)
            {
                List<String> handle = new List<string>();
                handle.Add(Char.ToUpper(Data[CommandLocation[i]]).ToString());
                String ToBeSplited = Data.Substring(CommandLocation[i]+1, CommandLocation[i + 1] - CommandLocation[i] - 1);
                String[] Splitted = ToBeSplited.Split(new Char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                handle.AddRange(Splitted);
                Result.Add(handle);
            }
            if (Data[CommandLocation[CommandLocation.Count - 1]] == 'Z')
                Result.Add(new List<string>() {"Z"});
            else
            {
                List<String> handle = new List<string>();
                handle.Add(Char.ToUpper(Data[CommandLocation[CommandLocation.Count - 1]]).ToString());
                String ToBeSplitted = Data.Substring(CommandLocation[CommandLocation.Count - 1]+1);
                String[] Splitted = ToBeSplitted.Split(new Char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                handle.AddRange(Splitted);
                Result.Add(handle);
            } 
            return Result;
        }

        private path[] KTSerializer(String Data)
        {
            path[] Result = new path[2] { new path(), new path() };
            Result[(int)Paths.Transparent].Fill = new SolidColorBrush(Colors.Black);
            Result[(int)Paths.Opaque].Fill = new SolidColorBrush(Colors.White);
            String[] TO = Data.Split(new Char[] { '_' },StringSplitOptions.RemoveEmptyEntries);
            for (int t = 0; t < 2; t++)
            {
                String[] Split = TO[t].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                PathGeometry geo = new PathGeometry();
                geo.FillRule = FillRule.Nonzero;
                for (int i = 1; i < Split.Length; i++)
                {
                    geo.Figures.Add(this.Parse(Split[i]));
                }
                Result[t].Data = geo;
            }
            return Result;
         }

    }
}

