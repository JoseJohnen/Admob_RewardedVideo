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
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IRewardedVideoAdListener
    {
        private IRewardedVideoAd mRewardedVideoAd;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            MobileAds.Initialize(ApplicationContext, "ca-app-pub-3940256099942544~3347511713");
            //"ca-app-pub-7050516707411195/8444756290");


            // Use an activity context to get the rewarded video instance.
            mRewardedVideoAd = MobileAds.GetRewardedVideoAdInstance(this);
            //mRewardedVideoAd.RewardedVideoAdListener = this;

            loadRewardedVideoAd();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            
        }

        public void LoadVideo(object sender, EventArgs e)
        {
            if (mRewardedVideoAd.IsLoaded)
            {
                mRewardedVideoAd.Show();
            }
        }

        public void loadRewardedVideoAd()
        {
            mRewardedVideoAd.LoadAd("ca-app-pub-3940256099942544/5224354917",new AdRequest.Builder().Build());
        }

        public void OnRewarded(IRewardItem reward)
        {
            Toast.MakeText(this, "onRewarded! currency: ${reward.type} amount: ${reward.amount}",ToastLength.Short).Show();
            // Reward the user.
        }

        public void OnRewardedVideoAdLeftApplication()
        {
            Toast.MakeText(this, "onRewardedVideoAdLeftApplication", ToastLength.Short).Show();
        }

        public void OnRewardedVideoAdClosed()
        {
            Toast.MakeText(this, "onRewardedVideoAdClosed", ToastLength.Short).Show();
        }

        public void OnRewardedVideoAdFailedToLoad(int errorCode)
        {
            Toast.MakeText(this, "onRewardedVideoAdFailedToLoad", ToastLength.Short).Show();
        }

        public void OnRewardedVideoAdLoaded()
        {
            Toast.MakeText(this, "onRewardedVideoAdLoaded", ToastLength.Short).Show();
        }

        public void OnRewardedVideoAdOpened()
        {
            Toast.MakeText(this, "onRewardedVideoAdOpened", ToastLength.Short).Show();
        }

        public void OnRewardedVideoStarted()
        {
            Toast.MakeText(this, "onRewardedVideoStarted", ToastLength.Short).Show();
        }

        public void OnRewardedVideoCompleted()
        {
            Toast.MakeText(this, "onRewardedVideoCompleted", ToastLength.Short).Show();
        }
    }
}

