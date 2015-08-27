using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
namespace KarakibLab
{
    class Triangle : Sticker
    {
        public Triangle(Point Location,Double Radius,Boolean isShadow = false):base(Location,Radius)
        {
            if (!isShadow)
            {
                this.Shadow = new Triangle(Location, Radius, true);
                this.Shadow.Fill = new SolidColorBrush(new Color { R = 0, B = 0, G = 0, A = 0 });
                Canvas.SetZIndex(this.Shadow, 2);
                this.Fill = new SolidColorBrush(Colors.Black);
                this.Shadow.Real = this;
            }
            this.isShadow = isShadow;
            this.Sides = 3;
            this.InitialAngle = Math.PI / 2;
            this.InternalAngle = 2 * Math.PI / 3;
            this.Construct();
        }
    }
}
