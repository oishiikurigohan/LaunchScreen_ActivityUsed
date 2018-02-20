using System.Threading.Tasks;
using Android.App;
using Xamarin.Forms.Platform.Android;
using Android.OS;
using Android.Widget;
using Android.Graphics.Drawables;

namespace LaunchScreen_ActivityUsed.Droid
{
    [Activity(MainLauncher = true, Label = "LaunchScreen_ActivityUsed", Icon = "@mipmap/greeeen_icon", Theme = "@style/LaunchScreenTheme")]
    public class LaunchScreenActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LaunchScreen);

            ImageView imageView = FindViewById<ImageView>(Resource.Id.animated_android);
            AnimationDrawable animation = (AnimationDrawable)imageView.Drawable;
            animation.Start();
        }

        protected override void OnResume()
        {
            base.OnResume();

            Task.Run(async () => {
                await Task.Delay(3000);
                if (!IsFinishing)
                {
                    StartActivity(typeof(MainActivity));
                    OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
                }
            });
        }

        protected override void OnPause()
        {
            base.OnPause();
            Finish();
        }
    }
}