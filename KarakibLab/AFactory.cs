using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KarakibLab
{
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Shapes;
    using Windows.UI.Xaml.Media;
    using Windows.Foundation;
    class AFactory
    {
        Activation Attach, Detach;
        public Color Fill { get; set; }
        List<AData> Data;
        Point DefaultLocation;
        public AFactory(PathSegmentCollection Data, Activation Attach, Activation Detach,Point DefaultLocation)
        {
            
        }
        public Avalon Produce(byte Type)
        {
            Avalon Pizza = new Avalon(Data[Type], Attach, Detach);
            Pizza.Fill = new SolidColorBrush(Fill);
            (Pizza.RenderTransform as CompositeTransform).TranslateX = DefaultLocation.X;
            (Pizza.RenderTransform as CompositeTransform).TranslateY = DefaultLocation.Y;
            
            return null;
        }
    }
}
