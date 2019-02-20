using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Mousey
{
    public partial class App : Application
    {
        MainPage main;
        public App()
        {
            InitializeComponent();
            main = new MainPage();
            MainPage = main;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            if(main!=null)
            {
                main.Close();
            }
        }

        protected override void OnResume()
        {
            if (main != null)
            {
                main.Close();
            }
        }
    }
}
