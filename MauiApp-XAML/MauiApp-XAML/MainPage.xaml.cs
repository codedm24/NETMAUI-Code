namespace MauiApp_XAML
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnBtnLinkNextPage1Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EssentialProperties());
        }

        private async void OnBtnLinkNextPage2Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MarkupExtensions());
        }

        private async void OnBtnLinkNextPage3Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync (new DataBindingBasic1());
        }

        private async void OnBtnLinkNextPage4Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DataBindingBasic2());
        }

        private async void OnBtnLinkNextPage5Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DataBindingBasic3());
        }
    }

}
