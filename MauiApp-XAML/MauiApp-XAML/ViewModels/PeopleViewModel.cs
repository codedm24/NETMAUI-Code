using MauiApp_XAML.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp_XAML
{
    public class PeopleViewModel 
    {
        public ObservableCollection<Person>? Employees { get; set; }

        public ICommand DeleteEmployeeCommand { get; private set; }

        public PeopleViewModel()
        {
            DeleteEmployeeCommand = new Command((employee) => {
                Employees?.Remove(employee as Person);
            });   
        }
    }
}
