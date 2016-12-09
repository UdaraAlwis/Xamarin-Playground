using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PageTranslucentLayerXF
{
    public class CoolCustomPage : ContentPage
    {
        public static readonly BindableProperty TranslucentPageBlockProperty =
        BindableProperty.Create(
            nameof(TranslucentPageBlock),
            typeof(TranslucentBlockerState),
            typeof(CoolCustomPage),
            TranslucentBlockerState.Inactive,
            BindingMode.Default);
        
        public TranslucentBlockerState TranslucentPageBlock
        {
            get { return (TranslucentBlockerState)this.GetValue(TranslucentPageBlockProperty); }
            set { this.SetValue(TranslucentPageBlockProperty, value); }
        }

        public CoolCustomPage()
        {

        }
    }

    public enum TranslucentBlockerState
    {
        Inactive,
        Active
    }
}
