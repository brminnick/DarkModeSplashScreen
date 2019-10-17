using System;
using Xamarin.Forms;

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

            Content = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,

                TextColor = operatingSystem switch
                {
                    Theme.Light => Color.Black,
                    Theme.Dark => Color.White,
                    _ => throw new NotSupportedException()
                },

                Text = "We Did it!"
            };
        }
    }
}
