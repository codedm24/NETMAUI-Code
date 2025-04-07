using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp_XAML
{
    public class Person
    {
        public string ForeName { get; set; }
        public string SurName { get; set; }
        public string FullName => $"{ForeName} {SurName}";
    }
}
