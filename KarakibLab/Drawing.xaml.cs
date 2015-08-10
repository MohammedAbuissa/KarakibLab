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
        public Drawing()
        {
            this.InitializeComponent();
            Line k = new Line { X1 = 50, Y1 = 50, X2 = 100, Y2 = 100, Stroke = new SolidColorBrush(Colors.Black), StrokeThickness = 5 };
            G.Children.Add(k);
            current = k;
        }
        private Line current;
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
            current.Stroke = new SolidColorBrush(Colors.Red);
            Line l = new Line {
                X1 = e.GetCurrentPoint((UIElement)sender).Position.X, 
                Y1 = e.GetCurrentPoint((UIElement)sender).Position.Y,
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

        }

        private void Grid_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            current.X2 = e.GetCurrentPoint((UIElement)sender).Position.X;
            current.Y2 = e.GetCurrentPoint((UIElement)sender).Position.Y;
        }

    }
}
