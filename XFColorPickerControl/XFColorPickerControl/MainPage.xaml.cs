using System;
using System.ComponentModel;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFColorPickerControl.Controls;

namespace XFColorPickerControl
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
        {
            InitializeComponent();
        }

		private void GotoColorPickerButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new ColorPickerPage());
		}
	}
}
