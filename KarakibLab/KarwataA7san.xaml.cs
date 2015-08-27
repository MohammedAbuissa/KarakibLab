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
using System.Diagnostics;
using Coding4Fun.Toolkit.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace KarakibLab
{
    using path = Windows.UI.Xaml.Shapes.Path;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KarwataA7san : Page
    {
        public KarwataA7san()
        {
            this.InitializeComponent();
            ColorPicker c = new ColorPicker();
            u.Children.Add(c);
            c.ColorChanged += C_ColorChanged;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        private void C_ColorChanged(object sender, Color color)
        {
            foreach (Sticker s in Global.Active)
                s.Fill = new SolidColorBrush(color);
        }

        Point currentpointer;
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String shape = "T|M60,143.333 C125,-81.665 185,-6.66667 325,150.833 C465,308.333 320,415.832 342.5,435.832 C365,455.832 127.5,598.331 82.5,403.332 C37.5,208.333 -4.9999,368.331 60,143.333 z_O|M102.5,125.833 L240,138.333 C240,138.333 132.5,303.333 255,273.333 C377.5,243.333 325,455.833 220,393.333 C115,330.833 102.5,125.833 102.5,125.833 z|M55,258.333 C77.5,233.333 230,153.333 130,300.833 C30,448.333 300,280.833 237.5,435.834 C175,590.835 62.5,283.333 50,290.833 C37.5,298.333 55,258.333 55,258.333 z";
            String Cats = "T|M211.111,133.889 C211.111,133.889 203.889,162.778 215.556,165 L236.667,173.333 L270,167.778 L286.667,151.667 L293.889,147.222 L304.444,176.111 C304.444,176.111 343.333,200.556 286.111,232.778 C286.111,232.778 268.889,269.444 356.666,351.667 C356.666,351.667 389.443,409.444 344.999,447.222 C344.999,447.222 336.666,453.333 356.666,461.111 C356.666,461.111 438.332,499.444 366.666,511.111 C366.666,511.111 298.333,535.555 225.555,511.111 C225.555,511.111 213.889,497.778 181.111,513.889 C181.111,513.889 86.6672,537.778 12.2232,504.444 C12.2232,504.444 -14.4431,493.889 25.0011,470 L63.3342,450.555 C63.3342,450.555 10.5568,420 39.4455,350 C39.4455,350 47.7788,330.555 59.4454,330 C59.4454,330 111.667,287.222 111.112,222.222 C111.112,222.222 114.445,209.444 96.6674,203.889 C96.6674,203.889 66.112,183.889 78.3341,160 L85.0008,115.556 L121.667,145 C121.667,145 150.556,141.111 167.778,150 L198.333,140.556 Z_O|M205.833,405.833 C205.833,405.833 213.333,461.667 276.667,460 C276.667,460 295.833,458.333 332.083,475 C332.083,475 369.167,495.417 334.167,500 C334.167,500 291.25,511.667 245,497.5 C245,497.5 233.75,496.25 245,491.25 L248.75,487.917 L245.833,482.917 C245.833,482.917 234.583,480 219.583,487.5 L208.333,491.25 L176.25,480.417 L166.667,484.583 L174.167,495 C174.167,495 98.8829,514.747 59.5013,497.829 C59.2494,497.721 58.9989,497.611 58.75,497.5 C58.75,497.5 45.4167,490.416 62.5,482.5 C62.5,482.5 94.167,463.333 117.5,458.75 C117.5,458.75 188.334,460.833 203.334,413.75 z|M196.667,201.667 C196.667,194.583 197.5,232.083 241.25,236.667 C241.25,236.667 294.583,293.75 220,346.667 L209.167,359.583 C209.167,359.583 206.25,345.833 198.333,340.833 C198.333,340.833 130,298.333 145.833,230.417 C145.833,230.417 147.5,217.083 161.25,217.083 C161.25,217.083 196.667,208.751 196.667,201.667 z";
            KarakibLab.Template t = new KarakibLab.Template(Cats);
            Debug.WriteLine((t.Children[0] as path).Data.Bounds.Height + " " + (t.Children[0] as path).Data.Bounds.Width);
            CompositeTransform c = new CompositeTransform();
            c.ScaleX = 0.75;
            c.ScaleY = 0.75;
            for (int i = 0; i < 2; i++)
            {
                (t.Children[i] as path).RenderTransform = c;
            }
            Debug.WriteLine((t.Children[0] as path).Data.Bounds.Height + " " + (t.Children[0] as path).Data.Bounds.Width);
            Template2BitMap.templateCreator(t, I, l, 0, 50, 2);
        }
        //rotate
        //right
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Sticker s in Global.Active)
                s.Rotate(-Math.PI / 18);
        }
        //left
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Sticker s in Global.Active)
                s.Rotate(Math.PI / 18);
        }
        //scale
        //up
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//to be completed with angles geometry 
            foreach (Sticker s in Global.Active)
                s.Scale(5);
        }
        //down
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            foreach (Sticker s in Global.Active)
                s.Scale(-5);
        }
        //move
        private void g_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            foreach (Sticker s in Global.Active)
                s.Translate(new Point((e.GetCurrentPoint(sender as UIElement).Position.X - currentpointer.X), e.GetCurrentPoint((sender as UIElement)).Position.Y - currentpointer.Y));
            currentpointer = e.GetCurrentPoint(sender as UIElement).Position;
        }

        private void g_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            currentpointer = e.GetCurrentPoint((UIElement)sender).Position;
        }

        private void button_Click_4(object sender, RoutedEventArgs e)
        {
            Square x = new Square(new Point(g.ActualHeight / 2, g.ActualWidth / 2), 50);
            Global.Active.AddLast(x);
            x.Opacity = 0.5;
            x.isActive = true;
            g.Children.Add(x);
            g.Children.Add(x.Shadow);
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Triangle x = new Triangle(new Point(g.ActualHeight / 2, g.ActualWidth / 2), 50);
            Global.Active.AddLast(x);
            x.Opacity = 0.5;
            x.isActive = true;
            g.Children.Add(x);
            g.Children.Add(x.Shadow);
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Circle x = new Circle(new Point(g.ActualHeight / 2, g.ActualWidth / 2), 50);
            Global.Active.AddLast(x);
            x.Opacity = 0.5;
            x.isActive = true;
            g.Children.Add(x);
            g.Children.Add(x.Shadow);
        }
    }
}
