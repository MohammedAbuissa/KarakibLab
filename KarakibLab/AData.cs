using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarakibLab
{
    using Windows.Foundation;
    using Windows.UI.Xaml.Media;
    public class AData
    {
        public Point StartPoint { get; set; }
        public List<PathSegment> Segments { get; set; }
    }
}
