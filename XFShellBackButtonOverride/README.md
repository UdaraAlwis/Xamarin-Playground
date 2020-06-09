Overriding Back Button in Xamarin.Forms Shell...
==============
Let me share all about overriding the Back Button navigation in Xamarin.Forms Shell applications, oh and yes! it includes handling the Android on-screen Back Button as well! :wink:

Here'a this awesomeness in action:  <br /><br />
<img src="/XFShellBackButtonOverride/screenshots/Xamarin.Forms Shell Back Button Override Android.png" height="425"/> <img src="/XFShellBackButtonOverride/screenshots/XFShellBackButtonOverride Android Page3.gif" height="425"/> <img src="/XFShellBackButtonOverride/screenshots/Xamarin.Forms Shell Back Button Override iOS.png" height="425"/> <img src="/XFShellBackButtonOverride/screenshots/XFShellBackButtonOverride iOS Page3.gif" height="425"/> 
<br />
 
Blog post: https://theconfuzedsourcecode.wordpress.com

basic ways of backward navigation,
- Navigation bar Back button (iOS and Android)
- Android on-screen Back Button
- Programmatically Navigating Backwards

I've investigated on several possibilities for achieving these requirements,
- Case 1: OnBackButtonPressed()
- Case 2: Shell.BackButtonBehavior
- Case 3: Shell.OnNavigating()
- Case 4: Shell.GoToAsync() for backwards!

Derived from those investigations I've used the following key features of Xamarin.Forms Shell in this implementation!

### Shell.BackButtonBehavior
```xml
<ContentPage
    ... >
  
    <Shell.BackButtonBehavior>
        <BackButtonBehavior Command="{Binding GoBackCommand}">
            <BackButtonBehavior.TextOverride>
                <OnPlatform x:TypeArguments="x:String">
                    <OnPlatform.Platforms>
                        <On Platform="iOS" Value="Go Back" />
                    </OnPlatform.Platforms>
                </OnPlatform>
            </BackButtonBehavior.TextOverride>
        </BackButtonBehavior>
    </Shell.BackButtonBehavior>
  
    <ContentPage.Content>
        ...
    </ContentPage.Content>
</ContentPage>
```

### Shell.OnNavigating
```csharp
private void OnAppearing()
{
	Shell.Current.Navigating += Current_Navigating;
}

private async void Current_Navigating(object sender, 
							ShellNavigatingEventArgs e)
{
	if (e.CanCancel)
	{
		e.Cancel();
		await GoBack();
	}
}
```

### Shell.Current.GoToAsync("..");
```csharp
private async Task GoBack()
{
	// display Alert for confirmation
	...

	if (result)
	{
		Shell.Current.Navigating -= Current_Navigating;
		await Shell.Current.GoToAsync("..", true);
	}
}
```

In this demo app, I've demonstrated the following features,
- First Page: Here we’re overriding the Navigation bar Back Button!
- Second Page: Here we’re overriding Android on-screen Back Button!
- Third Page: Here we’re overriding both Navigation Bar and Android on-screen Back Buttons!
