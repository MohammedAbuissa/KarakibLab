using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Media;
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
            String Data = "T|M60,143.333 C125,-81.665 185,-6.66667 325,150.833 C465,308.333 320,415.832 342.5,435.832 C365,455.832 127.5,598.331 82.5,403.332 C37.5,208.333 -4.9999,368.331 60,143.333 z_O|M102.5,125.833 L240,138.333 C240,138.333 132.5,303.333 255,273.333 C377.5,243.333 325,455.833 220,393.333 C115,330.833 102.5,125.833 102.5,125.833 z|M55,258.333 C77.5,233.333 230,153.333 130,300.833 C30,448.333 300,280.833 237.5,435.834 C175,590.835 62.5,283.333 50,290.833 C37.5,298.333 55,258.333 55,258.333 z";
            KarakibLab.Template t = new KarakibLab.Template(Data);
            Debug.WriteLine((t.Children[0] as path).Data.Bounds.Height +" "+ (t.Children[0] as path).Data.Bounds.Width);
            CompositeTransform c = new CompositeTransform();
            c.ScaleX = 0.75;
            c.ScaleY = 0.75;
            for (int i = 0; i < 2; i++)
            {
                (t.Children[i] as path).RenderTransform = c;
            }
            Debug.WriteLine((t.Children[0] as path).Data.Bounds.Height + " " + (t.Children[0] as path).Data.Bounds.Width);
            G.Children.Add(t);
            RenderTargetBitmap render = new RenderTargetBitmap();
            await render.RenderAsync(t);
            var result = await render.GetPixelsAsync();
            const int ScaleFactor = 2;
            WriteableBitmap source = new WriteableBitmap(ScaleFactor * render.PixelWidth, ScaleFactor * render.PixelHeight);
            using (Stream stream = source.PixelBuffer.AsStream())
            {
                Byte[] res = new Byte[source.PixelHeight * source.PixelWidth * 4];
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = 0xff;
                }
                //عيب يا ابو عيسي :P
                Byte[] kareem = result.ToArray();
                int Hoffset = 40/*(int)((G.ActualWidth - render.PixelWidth)/2)*/;
                int Voffset = 75/*(int)((G.ActualHeight - render.PixelHeight)/2)*/;
                for (int i = 0,j=0; i+4 < source.PixelWidth*render.PixelHeight*4+Voffset * source.PixelWidth * 4; i =((j/(render.PixelWidth*4))+Voffset)*source.PixelWidth*4+i%(render.PixelWidth*4))
                {
                    if (kareem[j + 1] == 0 && kareem[j] == 0 && kareem[j + 2] == 0 && kareem[j + 3] == 255)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            res[i++ +Hoffset*4] = kareem[j++];
                        }
                        res[i++ + Hoffset*4] = 0;
                        j++;
                    }
                        
                    else
                        for (int l = 0; l < 4; l++)
                        {
                            res[i++ + Hoffset * 4] = 0xff;
                            j++;
                        }
                }
                await stream.WriteAsync(res, 0, res.Length);
            }
            G.Children.Remove(t);
            I.Source = source;

        }
    }
}
