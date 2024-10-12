namespace Expenser.MauiAppl
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        int clickHereCount = 0;
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

        private void OnClickHereBtnClicked(object sender, EventArgs e)
        {
            clickHereCount++;
            if (clickHereCount == 1)
                ClickHereBtn.Text = $"Clicked {clickHereCount} time";
            else
                ClickHereBtn.Text = $"CLicked {clickHereCount} times";
            SemanticScreenReader.Announce(ClickHereBtn.Text);
        }
    }

}
