Playing Audio with the MediaManager Plugin for Xamarin.Forms!
==============
Let me show you how to play Audio in Xamarin.Forms across Android, iOS and Windows UWP using the super easy plug and play MediaManager Plugin! :wink:

Blog post: https://theconfuzedsourcecode.wordpress.com/2020/06/28/playing-audio-with-the-mediamanager-plugin-for-xamarin-forms/

It's easy as,
```csharp
var audioUrl = "https://ia800605.us.archive.org/32/items/Mp3Playlist_555/Daughtry-Homeacoustic.mp3";
await CrossMediaManager.Current.Play(audioUrl);
```

In this little demo, I've explored:
- Playing Audio in a Music Player style
- Queueing the Audio playlist
- Loading local Audio files 
- Maintain Audio playback even during app backgrounding/minimizing/lock screen

Here'a this awesomeness in action:  <br /><br />
iOS:
<img src="/XFAudioPlayer/screenshots/Full Functionality iOS.gif" height="425"/> <img src="/XFAudioPlayer/screenshots/Home Page iOS.png" height="425"/> <img src="/XFAudioPlayer/screenshots/Audio List Page iOS.png" height="425"/>

<br /><br />
Android:
<img src="/XFAudioPlayer/screenshots/Full Functionality Android.gif" height="425"/> <img src="/XFAudioPlayer/screenshots/Home Page Android.png" height="425"/> <img src="/XFAudioPlayer/screenshots/Audio List Page Android.png" height="425"/>

<br /><br />
UWP:
<img src="/XFAudioPlayer/screenshots/Full Functionality UWP.gif" height="425"/> <img src="/XFAudioPlayer/screenshots/Home Page UWP.png" height="425"/> <img src="/XFAudioPlayer/screenshots/Audio List Page UWP.png" height="425"/>
<br />

<br /><br />
Loading local Audio files:
<img src="/XFAudioPlayer/screenshots/File Picking iOS.gif" height="425"/> <img src="/XFAudioPlayer/screenshots/File Picking Android.gif" height="425"/> <img src="/XFAudioPlayer/screenshots/File Picking UWP.gif" height="425"/>
<br />

<br /><br />
Continous playback activity:
<img src="/XFAudioPlayer/screenshots/Android Status Bar.png" height="425"/> <img src="/XFAudioPlayer/screenshots/Android Lock Screen.png" height="425"/> 

<img src="/XFAudioPlayer/screenshots/UWP Windows Desktop Preview Player.png" height="425"/> <img src="/XFAudioPlayer/screenshots/UWP Lock Screen.png" height="425"/> 
<br />
