using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace XFColorPickerControl
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
	{
        private SKPoint _lastTouchPoint = new SKPoint();

		public MainPage()
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
				var colors = new SKColor[]
				{
					new SKColor(18, 154, 154),
					new SKColor(167, 0, 158),
					new SKColor(153, 153, 0),
					new SKColor(0, 157, 155),
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
			using (var skImage = skSurface.Snapshot())
			{
				using (var skData = skImage.Encode(SKEncodedImageFormat.Jpeg, 100))
				{
					using (SKBitmap bitmap = SKBitmap.Decode(skData))
					{
						touchPointColor = bitmap.GetPixel((int)_lastTouchPoint.X, (int)_lastTouchPoint.Y);
					}
				}
			}

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
			//SetCurrentColor(touchPointColor.ToFormsColor());
		}

        private void SkCanvasView_OnTouch(object sender, SKTouchEventArgs e)
        {

            float scale = SkCanvasView.CanvasSize.Width / (float)SkCanvasView.Width;

            //if (args.Type == TouchActionType.Pressed)
            //{
            //    _lastTouchPoint = new SKPoint(scale * (float)args.Location.X, scale * (float)args.Location.Y);
            //}

            //_lastTouchPoint = new SKPoint(scale * (float)args.Location.X, scale * (float)args.Location.Y);

			// update the Canvas as you wish
            SkCanvasView.InvalidateSurface();
		}
    }
}
