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
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace KarakibLab
{
    using path = Windows.UI.Xaml.Shapes.Path;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TranslateRotate : Page
    {
        List<Sticker> active = new List<Sticker>();
        public TranslateRotate()
        {
            this.InitializeComponent();
                        
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
            foreach(Sticker s in active)
                s.Rotate(-Math.PI / 18);
        }
        //left
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Sticker s in active)
                s.Rotate(Math.PI / 18);
        }
        //scale
        //up
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//to be completed with angles geometry 
            foreach (Sticker s in active)
                s.Scale(5);
        }
        //down
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            foreach (Sticker s in active)
                s.Scale(-5);
        }
        //move
        private void g_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            foreach (Sticker s in active)
                s.Translate(new Point((e.GetCurrentPoint(sender as UIElement).Position.X - currentpointer.X), e.GetCurrentPoint((sender as UIElement)).Position.Y - currentpointer.Y));
            currentpointer = e.GetCurrentPoint(sender as UIElement).Position;
        }

        private void g_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            currentpointer = e.GetCurrentPoint((UIElement)sender).Position;
        }

        private void button_Click_4(object sender, RoutedEventArgs e)
        {

        }
    }
}
