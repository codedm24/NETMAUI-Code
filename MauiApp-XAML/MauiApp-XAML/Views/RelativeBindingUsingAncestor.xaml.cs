
namespace MauiApp_XAML;

public partial class RelativeBindingUsingAncestor : ContentPage
{
	public RelativeBindingUsingAncestor()
	{
		InitializeComponent();
	}

	public PeopleViewModel DefaultViewModel { get; } = new PeopleViewModel { 
		Employees = new System.Collections.ObjectModel.ObservableCollection<Person>
        {
            new Person { ForeName = "John", SurName = "Doe" },
            new Person { ForeName = "Jane", SurName = "Smith" },
            new Person { ForeName = "Bob", SurName = "Johnson" }
        }   
    };
}