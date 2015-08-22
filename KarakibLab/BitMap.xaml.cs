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
            Ellipse t = new Ellipse { Height = 100, Width = 100,Fill = new SolidColorBrush(Colors.Black), Opacity =1 };
            //Sticker t = new Triangle(new Point(0, 0), 50);
            //path t = new path();
            //PathGeometry geo = new PathGeometry();
            //PathFigure figure = new PathFigure { StartPoint = new Point(50,0)};
            //figure.Segments.Add(new LineSegment { Point = new Point(100, 50) });
            //figure.Segments.Add(new LineSegment { Point = new Point(0, 50) });
            //figure.Segments.Add(new LineSegment { Point = new Point(50, 0) });
            //t.Fill = new SolidColorBrush(Colors.Black);
            //geo.Figures.Add(figure);
            //t.Data = geo;
            Grid y = new Grid();
            y.Children.Add(t);
            G.Children.Add(y);
            RenderTargetBitmap render = new RenderTargetBitmap();
            await render.RenderAsync(y);
            var result = await render.GetPixelsAsync();
            WriteableBitmap source = new WriteableBitmap(480,800);
            using (Stream stream = source.PixelBuffer.AsStream())
            {
                Byte[] res = new Byte[480 * 800 * 4];
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = 0xff;
                }
                //عيب يا ابو عيسي :P
                Byte[] kareem = result.ToArray();
                //for (int i = 0,j=0; i < source.PixelWidth * 200*4;i = (j/(200*4))*source.PixelWidth*4+i%(200*4) )
                //{
                //    for (int l = 0; l < 3; l++)
                //    {
                //        res[i++] = (byte)((3-l)*30);
                //        j++;
                //    }
                //    res[i++] = (byte)0xff;
                //    j++;
                //}
                const int Hoffset = 100;
                const int Voffset = 200;
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
            G.Children.Remove(y);
            I.Source = source;

        }
    }
}
