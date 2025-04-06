using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp_XAML
{
    public partial class TintColorBehavior
    {
        public static readonly BindableProperty TintColorProperty =
            BindableProperty.Create(nameof(TintColor), typeof(Color), typeof(TintColorBehavior));

        public Color? TintColor { get; set; }

    }
}
