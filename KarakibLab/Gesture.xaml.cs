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
using System.Diagnostics;

using Windows.UI;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace KarakibLab
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Gesture : Page
    {
        public Gesture()
        {
            this.InitializeComponent();
        }
        Sticker k;
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            k = new Square(new Point(200, 200), 100);
            G.Children.Add(k);
            k.Fill = new SolidColorBrush(Colors.Red);
        }

        private void Grid_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            k.Rotate(-e.Delta.Rotation/180.0 * Math.PI);
            k.Translate(e.Delta.Translation);
            if(e.Delta.Scale>0)
                k.Scale(e.Delta.Scale);
            G.Background = new SolidColorBrush(Colors.AliceBlue);
        }
    }
}
