using System.Windows.Input;

namespace MauiApp_XAML;

public partial class MarkupExtensionBasic : ContentPage
{
	public ICommand CreateCommand { get; private set; }

	public MarkupExtensionBasic()
	{
		InitializeComponent();
		CreateCommand = new Command<Type>((Type viewType) => {
			View view = (View)Activator.CreateInstance(viewType)!;
			view.VerticalOptions = LayoutOptions.Center;
			verticalStackLayout.Add(view);
		});

		BindingContext = this;
	}
}