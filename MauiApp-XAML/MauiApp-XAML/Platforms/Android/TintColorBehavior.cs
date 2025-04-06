using Android.Widget;
using Android.Graphics;
using Microsoft.Maui.Platform;
using Color = Microsoft.Maui.Graphics.Color;

namespace MauiApp_XAML
{
    public partial class TintColorBehavior : PlatformBehavior<Image,ImageView>
    {
        protected override void OnAttachedTo(Image bindable, ImageView platformView)
        {
            base.OnAttachedTo(bindable, platformView);

            if (bindable is null)
                return;
            if (TintColor is null)
                ClearColor(platformView);
            else
                ApplyColor(platformView, TintColor);
        }

        protected override void OnDetachedFrom(Image bindable, ImageView platformView)
        {
            base.OnDetachedFrom(bindable, platformView);

            if (bindable is null)
                return;

            ClearColor(platformView);
        }

        void ApplyColor(ImageView imageView, Color color)
        {
            imageView.SetColorFilter(new PorterDuffColorFilter(color.ToPlatform(), PorterDuff.Mode.SrcIn ?? throw new NullReferenceException()));
        }

        void ClearColor(ImageView imageView)
        {
            imageView.ClearColorFilter();
        }
    }
}
