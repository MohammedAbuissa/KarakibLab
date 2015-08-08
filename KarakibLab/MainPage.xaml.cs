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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.System.Threading;
using System.IO;
using Windows.Storage.Streams;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace KarakibLab
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private WriteableBitmap Scenario4WriteableBitmap;
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            Scenario4WriteableBitmap = new WriteableBitmap((int)image.Width, (int)image.Height);
            image.Source = Scenario4WriteableBitmap;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        async private void Button_Click(object sender, RoutedEventArgs e)
        {

            int pixelWidth = Scenario4WriteableBitmap.PixelWidth;
            int pixelHeight = Scenario4WriteableBitmap.PixelHeight;

            // Asynchronously graph the Mandelbrot set on a background thread
            byte[] result = null;
            await ThreadPool.RunAsync(new WorkItemHandler(
                (IAsyncAction action) =>
                {
                    result = graph(pixelWidth, pixelHeight);
                }
                ));
            int k;
            // Open a stream to copy the graph to the WriteableBitmap's pixel buffer
            using (Stream stream = Scenario4WriteableBitmap.PixelBuffer.AsStream())
            {
                await stream.WriteAsync(result, 0, result.Length);
            }

            // Redraw the WriteableBitmap
            Scenario4WriteableBitmap.Invalidate();
        }
        private byte[] graph(int width, int height)
        {
            byte[] result = new byte[width * height * 4];
            int resultIndex = 0;
            for (int i = 50*width; i < 50*(100+width); i++)
            {
                 result[resultIndex++] = 10; // Green value of pixel
                 result[resultIndex++] = 100; // Blue value of pixel
                 result[resultIndex++] = 110; // Red value of pixel
                 result[resultIndex++] = 255; 
            }
            return result;
        }

    }
}
