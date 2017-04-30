Forcefully dismissing Keyboard in Xamarin Forms...
===========

Here's another one of my Xamarin Forms hacks!

"YOU MUST GET RID OF THE KEYBOARD VISIBILITY!", demanded the UX Lead. :o

So...

Basically, what I did was to create a dependency service which would forcefully dismiss the keyboard, as in, push down the keyboard from which ever the current view of focus.

Sounds pretty simple eh? nah it wasn't. lol

Up on the Entry's Completed event I would first of all call up on my custom Keyboard dismissal service and then perform the screen capture and blurring view effect and so on. Which worked out pretty nicely!

read up the full story: https://theconfuzedsourcecode.wordpress.com/2017/04/30/forcefully-dismissing-keyboard-in-xamarin-forms/

<img src="https://github.com/UdaraAlwis/Xamarin-Playground/raw/master/XFForcefulKeyboardDismiss/screenshots/keyboard dismiss android.gif"  height="650" /> <img src="https://github.com/UdaraAlwis/Xamarin-Playground/raw/master/XFForcefulKeyboardDismiss/screenshots/keyboard dismiss ios.gif"  height="650" />
