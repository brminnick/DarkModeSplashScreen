using System;
using System.Threading.Tasks;
using DarkModeSplashScreen.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Environment_iOS))]
namespace DarkModeSplashScreen.iOS
{
    public class Environment_iOS : IEnvironment
    {
        public Task<Theme> GetOperatingSystemThemeAsync() => Device.InvokeOnMainThreadAsync(GetOperatingSystemTheme);

        public Theme GetOperatingSystemTheme()
        {
            var currentUIViewController = GetVisibleViewController();
            var userInterfaceStyle = currentUIViewController.TraitCollection.UserInterfaceStyle;

            return userInterfaceStyle switch
            {
                UIUserInterfaceStyle.Light => Theme.Light,
                UIUserInterfaceStyle.Dark => Theme.Dark,
                _ => throw new NotSupportedException($"UIUserInterfaceStyle {userInterfaceStyle} not supported")
            };
        }

        static UIViewController GetVisibleViewController()
        {
            var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            return rootController.PresentedViewController switch
            {
                UINavigationController navigationController => navigationController.TopViewController,

                UITabBarController tabBarController => tabBarController.SelectedViewController,

                null => rootController,

                _ => rootController.PresentedViewController,
            };
        }
    }
}

