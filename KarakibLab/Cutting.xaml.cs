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
    using path = Windows.UI.Xaml.Shapes.Path;
    public sealed partial class Cutting : Page
    {
        public Cutting()
        {
            this.InitializeComponent();
        }
        private PathFigure figure = new PathFigure();
        private Line current;
        private Point pc = new Point();
        private bool isfirst = true;
        private SolidColorBrush black = new SolidColorBrush(Colors.Black);
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PathGeometry geo = new PathGeometry();
            geo.Figures.Add(figure);
            path p = new path();
            p.Data = geo;
            p.Stroke = black;
            G.Children.Add(p);
        }

        private void G_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (Draw.IsChecked == true)
            {

            }
            else if (Cut.IsChecked == true)
            {

            }
        }

        private void G_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if(Draw.IsChecked == true)
            {
                if(isfirst)
                {

                }
            }
            else if(Cut.IsChecked == true)
            {

            }
        }

        private void G_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (Draw.IsChecked == true)
            {

            }
            else if (Cut.IsChecked == true)
            {

            }
        }




    }
}
