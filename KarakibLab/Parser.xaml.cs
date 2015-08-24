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
            String Data = Data = "M92.5,147.083 C143.889,94.4446 153.75,-0.416672 216.25,128.333 C278.75,257.083 323.333,-193.334 370,205 C416.667,603.334 403.333,561.666 303.333,563.333 C203.333,565 166.667,486.667 196.667,420 C226.667,353.333 86.6666,413.333 226.667,353.333 C366.667,293.333 -93.3334,355 146.667,268.333 C386.667,181.666 41.1112,199.721 92.5,147.083 Z";
            KarakibLab.Template t = new KarakibLab.Template(Data);
            t.Fill = new SolidColorBrush(Colors.Azure);
            G.Children.Add(t);
        }
    }
}
