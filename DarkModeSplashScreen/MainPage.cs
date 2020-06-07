using System;
using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace DarkModeSplashScreen
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var operatingSystem = DependencyService.Get<IEnvironment>().GetOperatingSystemTheme();

            BackgroundColor = operatingSystem switch
            {
                Theme.Light => Color.White,
                Theme.Dark => Color.Black,
                _ => throw new NotSupportedException()
            };

            Content = new TextLabel("We Did it!", operatingSystem);
        }

        class TextLabel : Label
        {
            public TextLabel(in string text, in Theme theme)
            {
                Text = text;
                TextColor = theme switch
                {
                    Theme.Light => Color.Black,
                    Theme.Dark => Color.White,
                    _ => throw new NotSupportedException()
                };

                this.Center();
                this.TextCenter();
            }
        }
    }
}
