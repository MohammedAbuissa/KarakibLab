using System;
using Windows.UI.Xaml.Media;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
namespace KarakibLab
{
    class Square : Sticker
    {
        public Square(Point Location, Double Radius, Boolean isShadow = false):base(Location, Radius)
        {
            if(!isShadow)
            {
                this.Shadow = new Square(Location, Radius, true);
                this.Shadow.Fill = new SolidColorBrush(new Color { R = 0, B = 0, G = 0, A = 0});
                Canvas.SetZIndex(this.Shadow, 2);
                this.Fill = new SolidColorBrush(Colors.Black);
                this.Shadow.Real = this;
            }
            this.Sides = 4;
            this.InitialAngle = Math.PI / 4;
            this.InternalAngle = Math.PI / 2;
            this.isShadow = isShadow;
            this.Construct();   
        }

    }
}
