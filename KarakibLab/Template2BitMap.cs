using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml;
using Windows.UI;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace KarakibLab
{
    static class Template2BitMap
    {
        public static  async void templateCreator(Template t,Image I,Grid VisualTreeParent,int Hoffset, int Voffset,int ScaleFactor)
        {
            //say cheese
            VisualTreeParent.Children.Add(t);
            RenderTargetBitmap render = new RenderTargetBitmap();
            await render.RenderAsync(t);
            var result = await render.GetPixelsAsync();
            //print the photo
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
                for (int i = 0, j = 0; i + 4 < source.PixelWidth * render.PixelHeight * 4 + Voffset * source.PixelWidth * 4; i = ((j / (render.PixelWidth * 4)) + Voffset) * source.PixelWidth * 4 + i % (render.PixelWidth * 4))
                {
                    if (kareem[j + 1] == 0 && kareem[j] == 0 && kareem[j + 2] == 0 && kareem[j + 3] == 255)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            res[i++ + Hoffset * 4] = kareem[j++];
                        }
                        res[i++ + Hoffset * 4] = 0;
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
            VisualTreeParent.Children.Remove(t);
            I.Source = source;
        }
    }
}
