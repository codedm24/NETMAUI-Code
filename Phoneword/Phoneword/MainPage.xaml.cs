namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        string translatedNumber = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            //count+=5;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert("Dial a Number", "Would you like to call " + translatedNumber + "?", "Yes", "No")) {
                try
                {
                    if (PhoneDialer.Default.IsSupported)
                        PhoneDialer.Default.Open(translatedNumber);
                }
                catch (ArgumentNullException ex)
                {
                    await DisplayAlert("Uanble to dial", "Phone number was not valid.", "OK");
                }
                catch (Exception) {
                    await DisplayAlert("Unable to call", "Phone dialing failed.", "OK");
                }
            }
        }

        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = PhoneNumberText.Text;
            translatedNumber = PhonewordTranslator.ToNumber(enteredNumber);

            if (!string.IsNullOrEmpty(translatedNumber))
            {
                CallButton.IsEnabled = true;
                CallButton.Text = "Call " + translatedNumber;
            }
            else 
            {
                CallButton.IsEnabled = false;
                CallButton.Text = "Call";
            }
        }
    }

}
