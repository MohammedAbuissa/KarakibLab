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
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace KarakibLab
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Parser : Page
    {
        public Parser()
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
            String Data = "T|M60,143.333 C125,-81.665 185,-6.66667 325,150.833 C465,308.333 320,415.832 342.5,435.832 C365,455.832 127.5,598.331 82.5,403.332 C37.5,208.333 -4.9999,368.331 60,143.333 z_O|M102.5,125.833 L240,138.333 C240,138.333 132.5,303.333 255,273.333 C377.5,243.333 325,455.833 220,393.333 C115,330.833 102.5,125.833 102.5,125.833 z|M55,258.333 C77.5,233.333 230,153.333 130,300.833 C30,448.333 300,280.833 237.5,435.834 C175,590.835 62.5,283.333 50,290.833 C37.5,298.333 55,258.333 55,258.333 z";
            KarakibLab.Template t = new KarakibLab.Template(Data);
            G.Children.Add(t);
        }
    }
}
