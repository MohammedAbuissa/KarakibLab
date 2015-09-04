namespace KarakibLab
{
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
    using Windows.UI.Xaml.Input;
    using path = Windows.UI.Xaml.Shapes.Path;
    public delegate void Activation(Avalon A);
    public sealed class Avalon: path
    {
        private Boolean isActive = true;
        public Avalon Real { get; private set; }
        public new SolidColorBrush Fill
        {
            get
            {
                return Fill;
            }
            set
            {
                if (Real != null)
                    Real.Fill = value;
                else
                    this.Fill = value;
            }
        }
        Activation Attach, Detach;
        public Avalon(PathSegmentCollection Segments, Activation Attach, Activation Detach)
        {
            Data = new PathGeometry();
            (Data as PathGeometry).Figures.Add(new PathFigure());
            (Data as PathGeometry).Figures[0].Segments = Segments;
            ManipulationMode = Windows.UI.Xaml.Input.ManipulationModes.All;
            RenderTransform = new CompositeTransform();
            RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);
            this.Attach = Attach;
            this.Detach = Detach;
            Tapped += Avalon_Tapped;
            Holding += Avalon_Holding;
            Loaded += Avalon_Loaded;
            Avalon_Holding(null, null);
        }

        private void Avalon_Loaded(object sender, RoutedEventArgs e)
        {
            if (Real != null)
                (this.Parent as Panel).Children.Add(Real);
        }

        private void Avalon_Holding(object sender, HoldingRoutedEventArgs e)
        {
            Attach(this);
            Real.Opacity = 0.5;
            isActive = true;
        }

        private void Avalon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Detach(this);
            Real.Opacity = 1;
            isActive = false;
        }
        public void Manipulation(ManipulationDeltaRoutedEventArgs e)
        {
            (RenderTransform as CompositeTransform).TranslateX += e.Delta.Translation.X;
            (RenderTransform as CompositeTransform).TranslateY += e.Delta.Translation.Y;
            (RenderTransform as CompositeTransform).Rotation += e.Delta.Rotation;
            if (e.Delta.Scale >0)
            {
                (RenderTransform as CompositeTransform).ScaleX *= e.Delta.Scale;
                (RenderTransform as CompositeTransform).ScaleY *= e.Delta.Scale;
            }
        }
    }
}
