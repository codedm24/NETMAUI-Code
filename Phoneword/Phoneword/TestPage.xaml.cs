namespace Phoneword;

public partial class TestPage : ContentPage
{
	int count = 0;
	public TestPage()
	{
		InitializeComponent();
	}

    private void OnCounterClicked(object sender, EventArgs e)
    {
		count++;
		CounterLabel.Text = $"Current count: {count}";

		SemanticScreenReader.Announce(CounterLabel.Text);
    }
}