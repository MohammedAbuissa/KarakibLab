﻿using System.Collections.Generic;
namespace KarakibLab
{
    using Windows.UI.Xaml.Media;
    using Windows.Foundation;
    using Windows.UI.Xaml.Input;
    class AFactory
    {
        Activation Attach, Detach;
        ManipulationDeltaEventHandler Router;
        public SolidColorBrush Fill { get; set; }
        List<AvalonDataFactory> Data ;
        Point DefaultLocation;
        public AFactory(List<AvalonDataFactory> Data, Activation Attach, Activation Detach, ManipulationDeltaEventHandler Router , Point DefaultLocation)
        {
            this.Attach = Attach;
            this.Detach = Detach;
            this.Router = Router;
            this.Data = Data;
            this.DefaultLocation = DefaultLocation;
        }
        public Avalon Produce(byte Type)
        {
            Avalon Pizza = new Avalon(Data[Type], Attach, Detach, Router);
            Pizza.fill = Fill;
            (Pizza.RenderTransform as CompositeTransform).TranslateX = DefaultLocation.X;
            (Pizza.RenderTransform as CompositeTransform).TranslateY = DefaultLocation.Y;
            return Pizza;
        }
    }
}
