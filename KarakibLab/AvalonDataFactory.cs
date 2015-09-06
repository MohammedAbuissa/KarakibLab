using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml.Media;

namespace KarakibLab
{
    class AvalonDataFactory : GeometryFactory
    {
        int sides;
        string ob;
        public AvalonDataFactory(int Sides,string ObjectName = ""):this(Sides, null,ObjectName){}
        public AvalonDataFactory(int Sides, List<Point> Info,string ObjectName = "")
        {
            sides = Sides;
            ob = ObjectName;
            if(Info != null)
                this.Info = Info;
        }
        private List<Point> info;
        public List<Point> Info
        {
            get
            {
                return info;
            }
            set
            {
                if (value.Count == sides)
                    info = value;
                else
                    throw new ArgumentException("The List must contain exactly" + sides + " elements"+  ob != ""?"represent the points of a " + ob: "");
            }
        }

        public PathGeometry Pattern()
        {
            PathGeometry geo = new PathGeometry();
            PathFigure figure = new PathFigure();
            geo.Figures.Add(figure);
            if (Info == null)
                throw new ArgumentNullException("Set the value of Info property");
            figure.StartPoint = Info[0];
            for (int i = 0; i < sides; i++)
                figure.Segments.Add(new LineSegment { Point = Info[(i + 1) % sides] });
            return geo;
        }
    }
}
