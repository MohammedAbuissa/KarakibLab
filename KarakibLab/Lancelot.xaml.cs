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
    using path = Windows.UI.Xaml.Shapes.Path;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Lancelot : Page
    {
        public Lancelot()
        {
            this.InitializeComponent();
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
            if (Area != null)
            {
                Area.Background = Number2Color(Convert.ToInt32((sender as Slider).Value));
            }
            
        }
        private SolidColorBrush Number2Color(int number)
        {
            string Hex = number.ToString("X");
            if(Hex.Length < 6)
            {
                for (int i = Hex.Length; i < 6; i++)
                {
                    Hex = Hex.Insert(0, "0");
                }
            }
            return new SolidColorBrush(new Color { R = Convert.ToByte(Hex.Substring(0, 2),16), G = Convert.ToByte(Hex.Substring(4, 2),16), B = Convert.ToByte(Hex.Substring(2, 2),16), A = 0XFF });
        }

    }
}
