using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Markup;

namespace DarkModeSplashScreen
{
    public class SplashScreenPage : ContentPage
    {
        readonly Image _mondayPundayImage;

        public SplashScreenPage()
        {
            Content = new Image
            {
                Opacity = 0,
                WidthRequest = Device.RuntimePlatform is Device.Android ? 215 : -1,
                HeightRequest = Device.RuntimePlatform is Device.iOS ? 105 : -1
            }.CenterExpand().Assign(out _mondayPundayImage);
        }

        protected override async void OnAppearing()
        {
            var operatingSystemTheme = DependencyService.Get<IEnvironment>().GetOperatingSystemTheme();

            _mondayPundayImage.Source = operatingSystemTheme switch
            {
                Theme.Light => "MondayPundayBlack",
                Theme.Dark => "MondayPundayWhite",
                _ => throw new NotSupportedException()
            };

            BackgroundColor = operatingSystemTheme switch
            {
                Theme.Light => Color.White,
                Theme.Dark => Color.Black,
                _ => throw new NotSupportedException()
            };

            base.OnAppearing();

            await Content.FadeTo(1, 1000, Easing.CubicIn);

            await Content.ScaleTo(1.25, 250, Easing.SpringOut);

            await Content.ScaleTo(1, 500, Easing.BounceOut);

            await Content.RotateTo(562, 1000, Easing.CubicOut);
            await Content.RotateTo(-1, 1000, Easing.CubicIn);

            await Task.WhenAll(Content.ScaleTo(50, 250, Easing.CubicOut), Content.RotateTo(-100, 250));

            Application.Current.MainPage = new MainPage();
        }
    }
}
