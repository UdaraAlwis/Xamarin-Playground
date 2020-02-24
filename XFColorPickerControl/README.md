# XFColorPickerControl

### Interactive Color Picker Control for Xamarin.Forms!

Watch me build an awesome interactive Color Picker UI Control for Xamarin.Forms using SkiaSharp...


Here'a this awesomeness in action:  <br /><br />
<img src="/XFColorPickerControl/screenshots/Color Picker Control for Xamarin.Forms by Udara Alwis.png" height="300"/> <img src="/XFColorPickerControl/screenshots/ScreenshotAndroid.png" height="300"/> 

This is an essintial control that's well missed in Xamarin.Forms out of the box, though there are few non-interactive dull looking simple 3rd party Color picker UI elements or controls out there, no one has come up with an actual interactive fun to use Color picker similar to what you have in Ms Paint or Google Web Color picker. So this is my attempt at solving this requirement in Xamarin.Forms...

The special implementation of this Control in a gist:

- Modeled after the Ms Paint Color picker
- Populate a full spectrum of colors on a canvas
- Add the darkened gradient colors spectrum on it
- Enable touch responses on the canvas
- Intercept the touch point cordinates detection
- Paint the touch point on the canvas for feedback
- Read the pixels off of the touch point cordinates
- Extract out the dominant color of that pixel point
- Return the Color object back to Xamarin.Forms

Still WIP though, stay in touch! ;) 

<img src="/XFColorPickerControl/screenshots/ScreenshotAndroid.png" height="300"/> <img src="/XFColorPickerControl/screenshots/ScreenshotiOS.png" height="300"/> <img src="/XFColorPickerControl/screenshots/ScreenshotUWP.png" height="300"/>