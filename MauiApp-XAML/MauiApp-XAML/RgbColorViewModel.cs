using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp_XAML
{
    public class RgbColorViewModel : INotifyPropertyChanged
    {
        Color color;
        string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public float Red
        {
            get => color.Red;

            set 
            {
                if (color.Red != value)
                {
                    color = new Color(value, color.Green, color.Blue);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Red"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));

                    Name = NamedColor.GetNearestColorName(color);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public float Green
        {
            get => color.Green;
            set
            {
                if (color.Green != value)
                {
                    color = new Color(color.Red, value, color.Blue);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Green"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
                    Name = NamedColor.GetNearestColorName(color);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public float Blue
        {
            get => color.Blue;
            set
            {
                if (color.Blue != value)
                {
                    color = new Color(color.Red, color.Green, value);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Blue"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
                    Name = NamedColor.GetNearestColorName(color);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public Color Color
        {
            get => color;
            set
            {
                if (color != value)
                {
                    color = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Red"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Green"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Blue"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));

                    Name = NamedColor.GetNearestColorName(color);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public string Name
        { 
            get => name;
            private set {
                if (name != value)
                {
                    name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
    }
}
