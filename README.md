# SCXI
Steam Controller XInput Adapter

## About

SCXI emulates an Xbox 360 controller from a Steam Controller without needing to have Steam installed.

I started this because I wanted to play a game that was on Xbox Game Pass and I couldn't get it added to Steam properly (UWP game) -- holding out for the new Xbox to come out before I buy a new controller :)

SCXI works by reading the USB HID (human interface device) raw data the same way that Steam would.  It uses the ViGEm driver to emulate an Xbox controller.

It is a simple .NET core console app.  It only supports Windows at the moment.  As long as the app is running, the Steam Controller will be read and translated into an Xbox controller.

## Future State
The app is far from complete but it works fine for my use case.  Depending on how many people use it and request features, I'll consider adding them (or pull request).  Currently the following features are NOT implemented.

+ ~~Setting HID feature reports.  This means that the app cannot currently disable the keyboard/mouse USB devices that the Steam Controller has (desktop mode as it's called).  Ever notice how your controller acts differently in big picture mode?  This is why.~~  There is now a watchdog, called "FeatureEnforcer" that will set the controller to the settings used in big picture mode.  The watchdog will check the focused window, and whenever the focused window changes, the features are re-sent to the controller.  


* Rumble support

* Multiple profiles / button mappings

* A proper UI / system tray icon

* Non Windows OS support

I did this in C# because it was the fastest way for me to get a working prototype working.  I'd consider rewriting it in Rust if performance becomes an issue, but that doesn't seem to be the case so far.

## Building

1. Make sure you have https://github.com/ViGEm/ViGEmBus/releases installed.  If you have used GloSC before, ViGEm will be installed too.
2. With the .NET core 3 SDK installed, you should be able to do dotnet build / dotnet run.  In the future, if people use this I will add proper releases and installers.
