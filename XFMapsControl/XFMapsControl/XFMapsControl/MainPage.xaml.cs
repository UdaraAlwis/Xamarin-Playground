using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XFMapsControl
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var pin1 = new CustomPin
            {
                Pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(37.79752, -122.40183),
                    Label = "Xamarin San Francisco Office",
                    Address = "394 Pacific Ave, San Francisco CA"
                },
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"
            };

            var pin2 = new CustomPin
            {
                Pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(37.797389, -122.402250),
                    Label = "Next to Xamarin San Francisco Office",
                    Address = "I dont know some random place"
                },
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"
            };

            //customMap.CustomPins = new List<CustomPin> { pin1, pin2 };
            //customMap.Pins.Add(pin1.Pin);
            ////customMap.Pins.Add(new Pin()
            ////{
            ////    Position = new Position(37.797389, -122.402250),
            ////    Label = "Next to Xamarin San Francisco Office",
            ////    Address = "I dont know some random place"
            ////});
            //customMap.MoveToRegion(MapSpan.FromCenterAndRadius(
            //  new Position(37.79752, -122.40183), Distance.FromMiles(1.0)));
        }
    }
}
