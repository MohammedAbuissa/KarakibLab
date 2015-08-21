using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.Foundation;
namespace KarakibLab
{
    class Triangle : Sticker
    {
        public Triangle(Point Location,Double Radius):base(Location,Radius)
        {
            this.Sides = 3;
            this.InitialAngle = Math.PI / 2;
            this.InternalAngle = 2 * Math.PI / 3;
            this.Fill = new SolidColorBrush(Colors.Black);
            //this.StrokeThickness = 10;
            this.Construct();
        }
    }
}
