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
        public Sticker(Point Location, Double Radius)
        {
            PathFigure figure = new PathFigure();
            PathGeometry geo = new PathGeometry();
            geo.Figures.Add(figure);
            this.Data = geo;
            this.Location = Location;
            this.Radius = Radius;
        }


        protected virtual void Construct()
        {
            ((this.Data as PathGeometry).Figures[0] as PathFigure).StartPoint = new Point(Location.X - Sorigin.X + Radius * Math.Cos(InitialAngle), Location.Y - Sorigin.Y - Radius * Math.Sin(InitialAngle));
            if (Segments.Count == 0)
                for (int i = 1; i < Sides; i++)
                    {
                        Segments.Add(new LineSegment { Point = new Point(Location.X - Sorigin.X + Radius * Math.Cos((i%Sides) * InternalAngle + InitialAngle), Location.Y - Sorigin.Y - Radius * Math.Sin((i%Sides) * InternalAngle + InitialAngle)) });
                        ((this.Data as PathGeometry).Figures[0] as PathFigure).Segments.Add(Segments[i-1]);
                    }
                

            else
                for (int i = 1; i < Sides; i++)
                    Segments[i-1].Point = new Point(Location.X - Sorigin.X + Radius * Math.Cos((i%Sides) * InternalAngle + InitialAngle), Location.Y - Sorigin.Y - Radius * Math.Sin((i%Sides) * InternalAngle + InitialAngle));

        }
        public void Translate(Point DeltaLocation)
        {
            this.Location.X += DeltaLocation.X;
            this.Location.Y += DeltaLocation.Y;
            this.Construct();
        }
        public virtual void Rotate(Double DeltaAngle)
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
