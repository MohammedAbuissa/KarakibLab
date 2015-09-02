using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Controls;
using Windows.UI;
using Windows.UI.Xaml.Media;
namespace KarakibLab
{
    using path = Windows.UI.Xaml.Shapes.Path;
    abstract class Avalon: path
    {
        public Avalon()
        {
            this.Data = new PathGeometry();
            (this.Data as PathGeometry).Figures.Add(new PathFigure());
            this.ManipulationMode = Windows.UI.Xaml.Input.ManipulationModes.All;
            this.ManipulationDelta += Avalon_ManipulationDelta;
            this.RenderTransform = new CompositeTransform();
            this.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);
            this.Fill = new SolidColorBrush();
        }

        protected virtual void Avalon_ManipulationDelta(object sender, Windows.UI.Xaml.Input.ManipulationDeltaRoutedEventArgs e)
        {
            (this.RenderTransform as CompositeTransform).TranslateX += e.Delta.Translation.X;
            (this.RenderTransform as CompositeTransform).TranslateY += e.Delta.Translation.Y;
            (this.RenderTransform as CompositeTransform).Rotation += e.Delta.Rotation;
            if (e.Delta.Scale >0)
            {
                (this.RenderTransform as CompositeTransform).ScaleX *= e.Delta.Scale;
                (this.RenderTransform as CompositeTransform).ScaleY *= e.Delta.Scale;
            }
        }
    }
}
