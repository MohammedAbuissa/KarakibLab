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

        virtual public Sticker(Point location, double InternalAngle,double radius,int Sides, double InitialAngle = 0)
        {
            PathFigure figure = new PathFigure();
            PathGeometry geo = new PathGeometry();
            geo.Figures.Add(figure);
            this.Data = geo;
        }
        public void Translate(Point Delta)
        {
            foreach (LineSegment item in Segments)
            {
                item.Point = new Point(item.Point.X + Delta.X, item.Point.Y + Delta.Y);
            }
        }
        public void Rotate()
        {

        }

    }
}
