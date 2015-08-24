using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Media;
using Windows.Foundation;
namespace KarakibLab
{
    using path = Windows.UI.Xaml.Shapes.Path;
    class Template : path
    {
        public Template(String Data)
        {
            this.Data = this.Parse(Data);
        }
        private PathGeometry Parse(String Data)
        {
            List<List<String>> Split = Spliter(Data);
            PathGeometry Result = new PathGeometry();
            PathFigure figure = new PathFigure();
            Result.Figures.Add(figure);
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
            return Result;
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
                handle.Add(Data[CommandLocation[i]].ToString());
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
                handle.Add(Data[CommandLocation[CommandLocation.Count - 1]].ToString());
                String ToBeSplitted = Data.Substring(CommandLocation[CommandLocation.Count - 1]+1);
                String[] Splitted = ToBeSplitted.Split(new Char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                handle.AddRange(Splitted);
                Result.Add(handle);
            } 
            return Result;
        }

        private List<String> XamlSerializer(Uri Path)
        {

            return new List<string>();
        }

    }
}
