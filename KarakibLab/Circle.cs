using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
namespace KarakibLab
{
    class Circle : Sticker
    {
        public Circle(Point Location, Double Radius) : base(Location, Radius)
        {
            this.Sides = 1000;
            this.InitialAngle = 0;
            this.InternalAngle = Math.PI / 500;
            this.Fill = new SolidColorBrush(Colors.Black);
            this.Construct();
        }
        
    }
}
