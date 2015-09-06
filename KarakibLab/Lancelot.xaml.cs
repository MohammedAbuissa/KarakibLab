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
            List<AvalonDataFactory> Pizza = new List<AvalonDataFactory>();
            //square
            AvalonDataFactory Square = new AvalonDataFactory(4, "Square");
            List<Point> Umaro = new List<Point>();
            Umaro.Add(new Point(0, 0));
            Umaro.Add(new Point(100, 0));
            Umaro.Add(new Point(100, 100));
            Umaro.Add(new Point(0, 100));
            Square.Info = Umaro;
            Pizza.Add(Square);
            GraphicsFactory = new AFactory(Pizza, new Activation(Attach), new Activation(Detach), new ManipulationDeltaEventHandler(Area_ManipulationDelta), new Point(0, 0));
            GraphicsFactory.Fill = new SolidColorBrush(Colors.Black);
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
            if (GraphicsFactory != null)
                GraphicsFactory.Fill = new SolidColorBrush(Number2Color((int)e.NewValue));
            if (Activated != null)
                Activated.fill = new SolidColorBrush(Number2Color((int)e.NewValue));
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

        private void Area_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            //if(Activated != null)
            //    Activated.Manipulation(e);
            if (!e.IsInertial && Activated!=null)
            {
                (Activated.RenderTransform as CompositeTransform).TranslateX += e.Delta.Translation.X;
                (Activated.RenderTransform as CompositeTransform).TranslateY += e.Delta.Translation.Y;
                (Activated.RenderTransform as CompositeTransform).Rotation += e.Delta.Rotation;
                if (e.Delta.Scale > 0)
                {
                    (Activated.RenderTransform as CompositeTransform).ScaleX *= e.Delta.Scale;
                    (Activated.RenderTransform as CompositeTransform).ScaleY *= e.Delta.Scale;
                }
            }
        }
    }
}
