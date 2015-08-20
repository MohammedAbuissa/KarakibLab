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
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace KarakibLab
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BitMap : Page
    {
        public BitMap()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            Triangle t = new Triangle(new Point(200,200), 100);
            t.Opacity = 0.75;
            k.Children.Add(t);
            RenderTargetBitmap render = new RenderTargetBitmap();
            await render.RenderAsync(t);
            var result = await render.GetPixelsAsync();
            WriteableBitmap temp = new WriteableBitmap(render.PixelWidth,render.PixelHeight);
            using (Stream stream = temp.PixelBuffer.AsStream())
            {
                await stream.WriteAsync(result.ToArray(), 0, render.PixelHeight * render.PixelWidth*4);
            }
            WriteableBitmap source = new WriteableBitmap(480,800);
            using (Stream stream = source.PixelBuffer.AsStream())
            {
                Byte[] res = new Byte[480 * 800 * 4];
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = 0xff;
                }

                Byte[] k = temp.PixelBuffer.ToArray();
                for (long i = 0, j=0; j < k.Length;i = (j/(temp.PixelWidth*4))*source.PixelWidth*4+(i%(temp.PixelWidth*4)))
                {
                    for (int l = 0; l < 4; l++)
                    {
                        res[i++%res.Length] = k[j++%k.Length];
                    }
                }
                await stream.WriteAsync(res, 0, res.Length);
            }
            k.Children.Remove(t);
            I.Source = source;

        }
    }
}
