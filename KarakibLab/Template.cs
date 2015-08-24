using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace KarakibLab
{
    using path = Windows.UI.Xaml.Shapes.Path;
    class Template : path
    {
        public Template(String Data)
        {
            this.Data = this.Parse(Data);
        }
        private PathGeometry Parse(String Data)
        {
            return new PathGeometry();
        }
        private String[,] Spliter(String Data)
        {
            return new String[5, 5];
        }
    }
}
