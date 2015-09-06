using System.Collections.Generic;

namespace KarakibLab
{
    using Windows.UI.Xaml.Media;
    using Windows.Foundation;
    public interface GeometryFactory
    {
        List<Point> Info { get; set; }
        PathGeometry Pattern();
    }
}
