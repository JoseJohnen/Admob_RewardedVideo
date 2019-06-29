using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Ads;
using Android.Gms.Ads.Reward;

namespace Admob.Droid
{
    [Activity(Label = "Admob", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance;

        RewardedVideoAd mRewardedVideoAd;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            base.OnCreate(bundle);

            //"ca-app-pub-7050516707411195/8444756290");

            // Use an activity context to get the rewarded video instance.
            //loadRewardedVideoAd();
            

            global::Xamarin.Forms.Forms.Init(this, bundle);
            MobileAds.Initialize(ApplicationContext, "ca-app-pub-7050516707411195~2913281915");

            LoadApplication(new App());
        }

        //public void LoadVideo(object sender, EventArgs e)
        //{
        //    if (mRewardedVideoAd.IsLoaded)
        //    {
        //        mRewardedVideoAd.Show();
        //    }
        //}

        //public void loadRewardedVideoAd()
        //{
        //    mRewardedVideoAd.LoadAd("ca-app-pub-3940256099942544/5224354917",new AdRequest.Builder().Build());
        //}
    }
}

