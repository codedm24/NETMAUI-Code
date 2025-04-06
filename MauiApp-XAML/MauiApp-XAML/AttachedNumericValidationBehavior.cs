using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp_XAML
{
    public static class AttachedNumericValidationBehavior
    {
        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(AttachedNumericValidationBehavior), false, propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view)
        { 
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        private static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            if (!(view is Entry entry))
            {
                return;
            }
            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                entry.TextChanged -= OnEntryTextChanged;
            }
        }

        private static void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry)
            {
                if (!string.IsNullOrEmpty(e.NewTextValue))
                {
                    bool isValid = double.TryParse(e.NewTextValue, out double result);
                    entry.TextColor = isValid ? Colors.White : Colors.Red;
                }
            }
        }
    }
}
