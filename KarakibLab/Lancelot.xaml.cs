using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;
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
    public sealed partial class Lancelot : Page
    {
        private AFactory GraphicsFactory;
        private Avalon Activated;
        public Lancelot()
        {
            this.InitializeComponent();
            List<AData> Segments = new List<AData>();
            //square
            path p1 = new path();
            p1.Data = new PathGeometry();
            PathFigure Square = new PathFigure();
            (p1.Data as PathGeometry).Figures.Add(Square);
            path p2 = new path();
            p2.Data = new PathGeometry();
            (p2.Data as PathGeometry).Figures.Add(Square);
            Square.StartPoint = new Point(0, 0);
            //Square.Segments = new List<PathSegment>();
            Square.Segments.Add(new LineSegment { Point = new Point(100, 0) });
            Square.Segments.Add(new LineSegment { Point = new Point(100, 100) });
            Square.Segments.Add(new LineSegment { Point = new Point(0, 100) });
            Square.Segments.Add(new LineSegment { Point = new Point(0, 0) });
            Area.Children.Add(p1);
            Area.Children.Add(p2);
            p1.Fill = new SolidColorBrush(Colors.Aqua);
            p2.Fill = p1.Fill;
            //Segments.Add(Square);
            Debug.WriteLine("finished initializing square");
            //Triangle
            AData Triangle = new AData();
            Triangle.StartPoint = new Point(50, 0);
            Triangle.Segments = new List<PathSegment>();
            Triangle.Segments.Add(new LineSegment { Point = new Point(100, 86.6) });
            Triangle.Segments.Add(new LineSegment { Point = new Point(0, 86.6) });
            Triangle.Segments.Add(new LineSegment { Point = new Point(50, 0) });
            Segments.Add(Triangle);
            //Circle
            AData Circle = new AData();
            Circle.StartPoint = new Point(50, 0);
            Circle.Segments = new List<PathSegment>();
            Circle.Segments.Add(new ArcSegment { Point = new Point(50, 100), Size = new Size(50, 50) });
            Circle.Segments.Add(new ArcSegment { Point = new Point(50, 0), Size = new Size(50, 50), RotationAngle = 180 });
            Segments.Add(Circle);
            GraphicsFactory = new AFactory(Segments, new Activation(Attach), new Activation(Detach), new Point(200, 200));
            GraphicsFactory.Fill = new SolidColorBrush();
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }
        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if(GraphicsFactory != null)
                GraphicsFactory.Fill.Color = Number2Color((int)e.NewValue);
            
        }
        private void Attach(Avalon A)
        {
            Activated = A;
        }
        private void Detach(Avalon A)
        {
            Activated = null;
        }
        private Color Number2Color(int number)
        {
            string Hex = number.ToString("X");
            if(Hex.Length < 6)
            {
                for (int i = Hex.Length; i < 6; i++)
                {
                    Hex = Hex.Insert(0, "0");
                }
            }
            return new Color { R = Convert.ToByte(Hex.Substring(0, 2),16), G = Convert.ToByte(Hex.Substring(4, 2),16), B = Convert.ToByte(Hex.Substring(2, 2),16), A = 0XFF };
        }

        private void S_Click(object sender, RoutedEventArgs e)
        {
            Area.Children.Add(GraphicsFactory.Produce(0));
        }

        private void T_Click(object sender, RoutedEventArgs e)
        {
            Area.Children.Add(GraphicsFactory.Produce(1));
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            Area.Children.Add(GraphicsFactory.Produce(2));
        }
    }
}
