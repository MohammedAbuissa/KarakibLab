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
using Windows.UI;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace KarakibLab
{
    using path = Windows.UI.Xaml.Shapes.Path;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TranslateRotate : Page
    {
       
        public TranslateRotate()
        {
            this.InitializeComponent();
            
        }
        PathFigure square = new PathFigure();
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            path p = new path();
            PathGeometry geo = new PathGeometry();
            geo.Figures.Add(square);
            square.Segments.Add(new LineSegment { Point = new Point(0, 0) });
            square.Segments.Add(new LineSegment { Point = new Point(50, 0) });
            square.Segments.Add(new LineSegment { Point = new Point(50, 50) });
            square.Segments.Add(new LineSegment { Point = new Point(0, 50) });
            p.Data = geo;
            p.Fill = new SolidColorBrush(Colors.Black);
            g.Children.Add(p);
        }
        //rotate
        //right
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        //left
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        //scale
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
        //move
        private void g_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            for (int i = 0; i < square.Segments.Count; i++)
                (square.Segments[i] as LineSegment).Point = new Point((square.Segments[i] as LineSegment).Point.X + e.Delta.Translation.X, (square.Segments[i] as LineSegment).Point.Y + e.Delta.Translation.Y);
        }
        

    }
}
