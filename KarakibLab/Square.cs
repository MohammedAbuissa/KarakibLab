using System;
using Windows.UI.Xaml.Media;
using Windows.Foundation;
using Windows.UI;
namespace KarakibLab
{
    class Square : Sticker
    {
        public Square(Point Location, Double Radius):base(Location, Radius)
        {
            this.Sides = 4;
            this.InitialAngle = Math.PI / 4;
            this.InternalAngle = Math.PI / 2;
            this.Fill = new SolidColorBrush(Colors.Black);
            this.ManipulationDelta += Square_ManipulationDelta;
            this.Construct();
        }

        private void Square_ManipulationDelta(object sender, Windows.UI.Xaml.Input.ManipulationDeltaRoutedEventArgs e)
        {
            this.Fill = new SolidColorBrush(Colors.Black);
            this.Translate(e.Delta.Translation);
        }
    }
}
