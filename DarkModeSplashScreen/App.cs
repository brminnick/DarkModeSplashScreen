using Xamarin.Forms;

namespace DarkModeSplashScreen
{
    public class App : Application
    {
        public App()
        {
            Device.SetFlags(new[] { "Markup_Experimental" });
            MainPage = new SplashScreenPage();
        }
    }
}
