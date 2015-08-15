using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.Foundation;
namespace KarakibLab
{
    abstract class Sticker : Path
    {
        protected List<LineSegment> Segments = new List<LineSegment>();
        public Point Sorigin { get; set; }
        protected Point Location;
        protected double InternalAngle, Radius, InitialAngle = 0;
        protected int Sides;
        public Sticker()
        {
            PathFigure figure = new PathFigure();
            PathGeometry geo = new PathGeometry();
            geo.Figures.Add(figure);
            this.Data = geo;
        }
        private void Construct()
        {
            if (Segments.Count == 0)
                for (int i = 0; i < Sides; i++)
                    Segments.Add(new LineSegment { Point = new Point(Location.X - Sorigin.X + Radius * Math.Cos(i * InternalAngle + InitialAngle), Location.Y - Sorigin.Y - Radius * Math.Sin(i * InternalAngle + InitialAngle)) });
            else
                for (int i = 0; i < Sides; i++)
                    Segments[i].Point = new Point(Location.X - Sorigin.X + Radius * Math.Cos(i * InternalAngle + InitialAngle), Location.Y - Sorigin.Y - Radius * Math.Sin(i * InternalAngle + InitialAngle));

        }
        public void Translate(Point DeltaLocation)
        {
            this.Location.X += DeltaLocation.X;
            this.Location.Y += DeltaLocation.Y;
            this.Construct();
        }
        public void Rotate(Double DeltaAngle)
        {
            this.InitialAngle += DeltaAngle;
            this.Construct(); 
        }
        public void Scale (Double DeltaRadius)
        {
            this.Radius += DeltaRadius;
            this.Construct();
        }
    }
}
