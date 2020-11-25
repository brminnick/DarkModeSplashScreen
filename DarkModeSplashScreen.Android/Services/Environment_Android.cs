using System;
using System.Threading.Tasks;
using Android.Content.Res;
using DarkModeSplashScreen.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(Environment_Android))]
namespace DarkModeSplashScreen.Droid
{
    public class Environment_Android : IEnvironment
    {
        public Task<Theme> GetOperatingSystemThemeAsync() => Task.FromResult(GetOperatingSystemTheme());

        public Theme GetOperatingSystemTheme()
        {
            var uiModeFlags = Xamarin.Essentials.Platform.AppContext.Resources.Configuration.UiMode & UiMode.NightMask;

            return uiModeFlags switch
            {
                UiMode.NightYes => Theme.Dark,
                UiMode.NightNo => Theme.Light,
                _ => throw new NotSupportedException($"UiMode {uiModeFlags} not supported"),
            };
        }
    }
}

