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
    public sealed partial class TranslateRotate : Page
    {
        Color fill = Colors.Red;
        public TranslateRotate()
        {
            this.InitializeComponent();
            ColorPicker c = new ColorPicker();
            u.Children.Add(c);
            c.ColorChanged += C_ColorChanged;         
        }

        private void C_ColorChanged(object sender, Color color)
        {
            foreach (Sticker s in Global.Active)
                s.Fill = new SolidColorBrush(color);
            fill = color;
        }

        Point currentpointer; 
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }
        //rotate
        //right
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(Sticker s in Global.Active)
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
            x.Fill = new SolidColorBrush(fill);
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Triangle x = new Triangle(new Point(g.ActualHeight / 2, g.ActualWidth / 2), 50);
            Global.Active.AddLast(x);
            x.Opacity = 0.5;
            x.isActive = true;
            g.Children.Add(x);
            g.Children.Add(x.Shadow);
            x.Fill = new SolidColorBrush(fill);
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Circle x = new Circle(new Point(g.ActualHeight / 2, g.ActualWidth / 2), 50);
            Global.Active.AddLast(x);
            x.Opacity = 0.5;
            x.isActive = true;
            g.Children.Add(x);
            g.Children.Add(x.Shadow);
            x.Fill = new SolidColorBrush(fill);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            foreach (Sticker s in Global.Active)
            {
                g.Children.Remove(s);
                g.Children.Remove(s.Shadow);
            }
        }

        private void g_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            foreach (var k in Global.Active)
            {
                k.Rotate(-e.Delta.Rotation / 180.0 * Math.PI);
                k.Translate(e.Delta.Translation);
                if (e.Delta.Scale > 0)
                    k.Scale(e.Delta.Scale);
            }
            
        }
    }
}
