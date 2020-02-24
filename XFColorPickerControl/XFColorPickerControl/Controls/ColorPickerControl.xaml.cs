using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFColorPickerControl.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorPickerControl : ContentView
	{
		public event EventHandler<Color> PickedColorChanged;

		public static readonly BindableProperty PickedColorProperty
			= BindableProperty.Create(
				nameof(PickedColor),
				typeof(Color),
				typeof(ColorPickerControl),
				null,
		defaultBindingMode: BindingMode.TwoWay);

		public Color PickedColor
		{
			get { return (Color)GetValue(PickedColorProperty); }
			set { SetValue(PickedColorProperty, value); }
		}

		private SKPoint _lastTouchPoint = new SKPoint();

		public ColorPickerControl()
		{
			InitializeComponent();
		}

		private void SkCanvasView_OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
		{
			var skImageInfo = e.Info;
			var skSurface = e.Surface;
			var skCanvas = skSurface.Canvas;

			var skCanvasWidth = skImageInfo.Width;
			var skCanvasHeight = skImageInfo.Height;

			skCanvas.Clear(SKColors.White);

			// Draw colorful gradient spectrum
			using (var paint = new SKPaint())
			{
				paint.IsAntialias = true;

				// Initiate the darkened primary color list
				// picked from Google search "online color picker"
				var colors = new SKColor[]
				{
					new SKColor(255, 0, 0),
					new SKColor(255, 255, 0),
					new SKColor(0, 255, 0),
					new SKColor(0, 255, 255),
					new SKColor(0, 0, 255),
					new SKColor(255, 0, 255),
					new SKColor(255, 0, 0),
				};

				// create the gradient shader 
				using (var shader = SKShader.CreateLinearGradient(
					new SKPoint(0, 0),
					new SKPoint(skCanvasWidth, 0),
					colors,
					null,
					SKShaderTileMode.Clamp))
				{
					paint.Shader = shader;
					skCanvas.DrawPaint(paint);
				}
			}

			// Draw darker gradient spectrum
			using (var paint = new SKPaint())
			{
				paint.IsAntialias = true;

				// Initiate the darkened primary color list
				var colors = new SKColor[]
				{
					SKColors.Transparent,
					SKColors.Black
				};

				// create the gradient shader 
				using (var shader = SKShader.CreateLinearGradient(
					new SKPoint(0, 0),
					new SKPoint(0, skCanvasHeight),
					colors,
					null,
					SKShaderTileMode.Clamp))
				{
					paint.Shader = shader;
					skCanvas.DrawPaint(paint);
				}
			}

			// retrieve the color of the current Touch point
			SKColor touchPointColor;

			// Inefficient : causes memory overload errors
			//using (var skImage = skSurface.Snapshot())
			//{
			//	using (var skData = skImage.Encode(SKEncodedImageFormat.Webp, 100))
			//	{
			//                 if (skData != null)
			//                 {
			//		    using (SKBitmap bitmap = SKBitmap.Decode(skData))
			//		    {
			//			    touchPointColor = bitmap.GetPixel((int)_lastTouchPoint.X, (int)_lastTouchPoint.Y);
			//                     }
			//                 }
			//	}
			//}


			// this is more efficent
			// https://forums.xamarin.com/discussion/92899/read-a-pixel-info-from-a-canvas
			// create the 1x1 bitmap (auto allocates the pixel buffer)
			SKBitmap bitmap = new SKBitmap(skImageInfo);

			// get the pixel buffer for the bitmap
			IntPtr dstpixels = bitmap.GetPixels();

			// read the surface into the bitmap
			skSurface.ReadPixels(skImageInfo, dstpixels, skImageInfo.RowBytes, (int)_lastTouchPoint.X, (int)_lastTouchPoint.Y);

			// access the color
			touchPointColor = bitmap.GetPixel(0, 0);



			// painting the Touch point
			using (SKPaint paintTouchPoint = new SKPaint())
			{
				paintTouchPoint.Style = SKPaintStyle.Fill;
				paintTouchPoint.Color = SKColors.White;
				paintTouchPoint.IsAntialias = true;

				skCanvas.DrawCircle(
					_lastTouchPoint.X,
					_lastTouchPoint.Y,
					30, paintTouchPoint);

				paintTouchPoint.Color = touchPointColor;

				skCanvas.DrawCircle(
					_lastTouchPoint.X,
					_lastTouchPoint.Y,
					20, paintTouchPoint);
			}

			// Set selected color
			PickedColor = touchPointColor.ToFormsColor();
			PickedColorChanged?.Invoke(this, PickedColor);
		}

		private void SkCanvasView_OnTouch(object sender, SKTouchEventArgs e)
		{
			_lastTouchPoint = e.Location;

			var canvasSize = SkCanvasView.CanvasSize;

			// Ignore Touch Move events that drags the cursor outside the canvas surface region
			if ((e.Location.X > 0 && e.Location.X < canvasSize.Width) &&
				(e.Location.Y > 0 && e.Location.Y < canvasSize.Height))
			{
				e.Handled = true;

				// update the Canvas as you wish
				SkCanvasView.InvalidateSurface();
			}
		}
	}
}