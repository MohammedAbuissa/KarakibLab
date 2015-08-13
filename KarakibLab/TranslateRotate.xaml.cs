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
        Point currentpointer;
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
            square.StartPoint = new Point(0, 0);
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
        //up
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//to be completed with angles geometry 
            square.StartPoint = new Point(square.StartPoint.X - 5,square.StartPoint.Y -5);
            (square.Segments[0] as LineSegment).Point = new Point((square.Segments[0] as LineSegment).Point.X + 5, (square.Segments[0] as LineSegment).Point.Y - 5);
            (square.Segments[1] as LineSegment).Point = new Point((square.Segments[1] as LineSegment).Point.X + 5, (square.Segments[1] as LineSegment).Point.Y + 5);
            (square.Segments[2] as LineSegment).Point = new Point((square.Segments[2] as LineSegment).Point.X - 5, (square.Segments[2] as LineSegment).Point.Y + 5);
        }
        //down
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
        //move
        private void g_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            square.StartPoint = new Point(square.StartPoint.X + (e.GetCurrentPoint(sender as UIElement).Position.X - currentpointer.X), square.StartPoint.Y + (e.GetCurrentPoint(sender as UIElement).Position.Y - currentpointer.Y));   
            foreach (LineSegment item in square.Segments)
                item.Point = new Point(item.Point.X + (e.GetCurrentPoint(sender as UIElement).Position.X - currentpointer.X), item.Point.Y + (e.GetCurrentPoint(sender as UIElement).Position.Y - currentpointer.Y));
            currentpointer = e.GetCurrentPoint(sender as UIElement).Position;
        }

        private void g_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            currentpointer = e.GetCurrentPoint((UIElement)sender).Position;
        }
        


    }
}
