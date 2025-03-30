using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp_XAML
{
    public class KeypadViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _inputString = "";
        private string _displayText = "";
        private char[] _specialChars = new char[] { '*', '#' };

        public ICommand AddCharCommand { get; private set; }
        public ICommand DeleteCharCommand { get; private set; }

        public string InputString
        { 
            get => _inputString;
            private set {
                if (_inputString != value)
                {
                    _inputString = value;
                    OnPropertyChanged();
                    DisplayText = FormatText(_inputString);

                    ((Command)DeleteCharCommand).ChangeCanExecute();
                }
            }
        }    
        
        public string DisplayText
        {
            get => _displayText;
            private set {
                if (_displayText != value) {
                    _displayText = value;
                    OnPropertyChanged();
                }

            }
        }

        string FormatText(string str)
        {
            bool hasNonNumbers = str.IndexOfAny(_specialChars) != -1;
            string formatted = str;

            if (hasNonNumbers || str.Length < 4 || str.Length > 10)
            {

            }
            else if (str.Length < 8)
            {
                formatted = string.Format("{0}-{1}", str.Substring(0, 3), str.Substring(3));
            }
            else
            {
                formatted = string.Format("({0}) {1}-{2}", str.Substring(0, 3), str.Substring(3, 3), str.Substring(6));
            }

            return formatted;
        }

        public KeypadViewModel()
        {
            AddCharCommand = new Command<string>((key) => InputString += key);
            DeleteCharCommand = new Command(
                () => InputString = InputString.Substring(0, InputString.Length - 1),
                () => InputString.Length > 0);
        }

        public void OnPropertyChanged([CallerMemberName] string name ="") =>
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
    }
}
