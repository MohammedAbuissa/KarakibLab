using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace KarakibLab
{
    using path = Windows.UI.Xaml.Shapes.Path;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Drawing : Page
    {
        private SolidColorBrush black = new SolidColorBrush(Colors.Black);

        public Drawing()
        {
            this.InitializeComponent();
            //path
            PathFigure figure = new PathFigure(); // global
            PathGeometry geo = new PathGeometry(); // global
            geo.Figures.Add(figure);
            path p = new path();
            p.Data = geo;
            p.Stroke = black;
            figure.Segments.Add(new LineSegment { Point = new Point(25, 25) });
            CompositeTransform c = new CompositeTransform();
            p.RenderTransform = c;
            c.TranslateX = 100;
            c.TranslateY = 100;
            figure.StartPoint = new Point(0, 0); //poitner pressed
            figure.Segments.Add(new LineSegment { Point = new Point(50, 50) }); // pointer moved 
            figure.Segments.Add(new LineSegment { Point = new Point(50, 0) });
            //figure.Segments.Add(new LineSegment { Point = new Point(0, 0) });
           
            G.Children.Add(p);

        }
        private Line current;
        private Point pc = new Point();
        private bool isfirst = true;
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Grid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Point k = new Point();
            if(isfirst)
            {
                k.X = e.GetCurrentPoint((UIElement)sender).Position.X;
                k.Y = e.GetCurrentPoint((UIElement)sender).Position.Y;
                isfirst = false;
            }
            else
            {
                k.X = pc.X;
                k.Y = pc.Y;
            }
            Line l = new Line {
                X1 = k.X, 
                Y1 = k.Y,
                X2 = e.GetCurrentPoint((UIElement)sender).Position.X,
                Y2 = e.GetCurrentPoint((UIElement)sender).Position.Y,
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 5
            };
            ((Grid)sender).Children.Add(l);
            current = l;
        }

        private void Grid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pc.X = e.GetCurrentPoint((UIElement)sender).Position.X;
            pc.Y = e.GetCurrentPoint((UIElement)sender).Position.Y;
        }

        private void Grid_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            current.X2 = e.GetCurrentPoint((UIElement)sender).Position.X;
            current.Y2 = e.GetCurrentPoint((UIElement)sender).Position.Y;
        }

    }
}
