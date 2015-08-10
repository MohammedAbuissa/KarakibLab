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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Drawing : Page
    {
        private SolidColorBrush black = new SolidColorBrush(Colors.Black);
        public Drawing()
        {
            this.InitializeComponent();
            Polyline p = new Polyline();
            Point[] ps = new Point[4];
            ps[0] = new Point { X = 0, Y = 0 };
            ps[1] = new Point { X = 100, Y = 0 };
            ps[2] = new Point { X = 100, Y = 100};
            ps[3] = new Point { X = 0, Y = 100 };
            for (int i = 0; i < 4; i++)
            {
                p.Points.Add(ps[i]);
            }
            p.Stroke = black;
            p.RenderTransformOrigin = new Point(0, 0);
            TranslateTransform t = new TranslateTransform();
            p.RenderTransform = t;
            t.X = 100;
            t.Y = 100;
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
