using Android.Content;
using ExpensesApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBarRenderer))]
namespace ExpensesApp.Droid.CustomRenderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        public CustomProgressBarRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (double.IsNaN(e.NewElement.Progress))
                Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(Color.FromRgb(182, 231, 233).ToAndroid());
            else if (e.NewElement.Progress < 0.3)
                Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(Color.FromRgb(200, 231, 233).ToAndroid());
            else if (e.NewElement.Progress < 0.5)
                Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(Color.FromRgb(100, 231, 233).ToAndroid());
            else
                Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(Color.FromRgb(255, 231, 233).ToAndroid());

            Control.ScaleY = 5;
        }
    }
}