using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp_XAML
{
    public class NumericValidationStyleBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(NumericValidationStyleBehavior), false, propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        private static void OnAttachBehaviorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Entry entry = bindable as Entry;
            if (entry == null)
            {
                return;
            }

            bool attachBehavior = (bool)newValue;

            if(attachBehavior)
                entry.Behaviors.Add(new NumericValidationStyleBehavior());
            else
                entry.Behaviors.Remove(entry.Behaviors.FirstOrDefault(b => b is NumericValidationStyleBehavior));
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
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
