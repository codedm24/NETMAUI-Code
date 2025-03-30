using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp_XAML
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime _time;
        private Timer _timer;

        public DateTime DateTime
        { 
            get => _time;
            set { 
                if(_time != value)
                {
                    _time = value;
                    OnPropertyChanged();
                }
            }
        }

        public ClockViewModel()
        {
            this._time = DateTime.Now;
            _timer = new Timer(new TimerCallback((s) => this.DateTime = DateTime.Now),
                null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        ~ClockViewModel()
        {
            _timer.Dispose();
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
