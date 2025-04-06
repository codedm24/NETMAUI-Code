
namespace MauiApp_XAML
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //return base.CreateWindow(activationState);
            Window window = base.CreateWindow(activationState);
            window.Created += (s,e) =>
            {
                window.Title = "MauiApp-XAML";
            };

            return window;
        }
    }
}
