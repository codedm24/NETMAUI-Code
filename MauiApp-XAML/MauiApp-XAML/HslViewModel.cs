using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp_XAML
{
    public class HslViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double _hue;
        private double _saturation;
        private double _luminosity;
        private Color _color;

        public double Hue
        {
            get => _hue;
            set
            {
                if (_hue != value)
                {
                    _hue = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Saturation
        {
            get => _saturation;
            set
            {
                if (_saturation != value)
                {
                    _saturation = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Luminosity
        {
            get => _luminosity;
            set
            {
                if (_luminosity != value)
                {
                    _luminosity = value;
                    OnPropertyChanged();
                }
            }
        }

        public Color Color
        {
            get => _color;
            set
            {
                if (_color != value)
                {
                    _color = value;
                    _hue = _color.GetHue();
                    _saturation = _color.GetSaturation();
                    _luminosity = _color.GetLuminosity();

                    OnPropertyChanged("Hue");
                    OnPropertyChanged("Saturation");
                    OnPropertyChanged("Lightness");
                    OnPropertyChanged();
                }
            }
        }

        public HslViewModel()
        {
            this._hue = 0;
            this._saturation = 0;
            this._luminosity = 0;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
