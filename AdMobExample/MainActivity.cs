using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Gms.Ads;
using Android;
using Android.Gms.Ads.Reward;
using Google.Ads.Mediation.Admob;

namespace AdMobExample
{
	[Activity (Label = "@string/app_name", MainLauncher = true)]
	public class MainActivity : AppCompatActivity, IRewardedVideoAdListener
	{
        public IRewardedVideoAd RewardedVideoAd { get; set; }
        public Button DisplayVideoButton { get; set; }

        protected AdView mAdView;
        protected InterstitialAd mInterstitialAd;
        protected Button mLoadInterstitialButton;

        protected IRewardedVideoAd _rewardedVideoAd;
        private bool _isRewardedVideoLoading;
        private static object _lock = new object();

        private static string AD_UNIT_ID = "ca-app-pub-3940256099942544/5224354917";

        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.activity_main);

			mAdView = FindViewById<AdView> (Resource.Id.adView);
			var adRequest = new AdRequest.Builder ().Build ();
			mAdView.LoadAd (adRequest);

			mInterstitialAd = new InterstitialAd (this);
			mInterstitialAd.AdUnitId = GetString (Resource.String.test_interstitial_ad_unit_id);

			mInterstitialAd.AdListener = new AdListener (this);

			mLoadInterstitialButton = FindViewById<Button> (Resource.Id.load_interstitial_button);
			mLoadInterstitialButton.SetOnClickListener (new OnClickListener (this));

            RewardedVideoAd = MobileAds.GetRewardedVideoAdInstance(this);
            RewardedVideoAd.RewardedVideoAdListener = this;
            LoadRewardedVideoAd();

            DisplayVideoButton = FindViewById<Button>(Resource.Id.DisplayVideoButton);
            DisplayVideoButton.Click += (o, e) =>
            {
                ShowRewardedVideo();
            };
        }

        public void LoadRewardedVideoAd()
        {
            lock (_lock)
            {
                if (!_isRewardedVideoLoading && !RewardedVideoAd.IsLoaded)
                {
                    _isRewardedVideoLoading = true;
                    Bundle extras = new Bundle();
                    extras.PutBoolean("_noRefresh", true);
                    var adMobAdapter = new AdMobAdapter();
                    AdRequest adRequest = new AdRequest.Builder()
                        //.AddTestDevice(AdRequest.DeviceIdEmulator)
                        //.AddTestDevice("FE5692B3DAD1B4CE3BE3BDA2FF4B6103")
                        //.AddNetworkExtrasBundle(adMobAdapter.Class, extras)
                        .Build();
                    RewardedVideoAd.UserId = "pub-74XXXXXXXXXXXXXX";
                    RewardedVideoAd.LoadAd(AD_UNIT_ID, adRequest);
                }
            }
        }

        public void ShowRewardedVideo()
        {
            if (RewardedVideoAd.IsLoaded)
            {
                RewardedVideoAd.Show();
            }
        }

        protected void RequestNewInterstitial ()
		{
			var adRequest = new AdRequest.Builder ().Build ();
			mInterstitialAd.LoadAd (adRequest);
		}

		protected void BeginSecondActivity ()
		{
			var intent = new Intent (this, typeof(SecondActivity));
			StartActivity (intent);
		}

		protected override void OnPause ()
		{
			if (mAdView != null) {
				mAdView.Pause ();
			}
			base.OnPause ();
		}

		protected override void OnResume ()
		{
			base.OnResume ();
			if (mAdView != null) {
				mAdView.Resume ();
			}
			if (!mInterstitialAd.IsLoaded) {
				RequestNewInterstitial ();
			}
		}

		protected override void OnDestroy ()
		{
			if (mAdView != null) {
				mAdView.Destroy ();
			}
			base.OnDestroy ();
		}

        public void OnRewarded(IRewardItem reward)
        {
            Toast.MakeText(this, string.Format("OnRewarded ! currency: {0} amount: {1}", reward.GetType(), reward.Amount), ToastLength.Short).Show();
        }

        public void OnRewardedVideoAdClosed()
        {
            Toast.MakeText(this, "OnRewardedVideoAdClosed", ToastLength.Short).Show();
            LoadRewardedVideoAd();
        }

        public void OnRewardedVideoAdFailedToLoad(int errorCode)
        {
            lock (_lock)
            {
                _isRewardedVideoLoading = false;
            }
            Toast.MakeText(this, "OnRewardedVideoAdFailedToLoad Code error : " + errorCode, ToastLength.Short).Show();
        }

        public void OnRewardedVideoAdLeftApplication()
        {
            Toast.MakeText(this, "OnRewardedVideoAdLeftApplication", ToastLength.Short).Show();
        }

        public void OnRewardedVideoAdLoaded()
        {
            lock (_lock)
            {
                _isRewardedVideoLoading = false;
            }
            Toast.MakeText(this, "OnRewardedVideoAdLoaded", ToastLength.Short).Show();
        }

        public void OnRewardedVideoAdOpened()
        {
            Toast.MakeText(this, "OnRewardedVideoAdOpened", ToastLength.Short).Show();
        }

        public void OnRewardedVideoStarted()
        {
            Toast.MakeText(this, "OnRewardedVideoStarted", ToastLength.Short).Show();
        }

        class AdListener : Android.Gms.Ads.AdListener
		{
			MainActivity that;

			public AdListener (MainActivity t)
			{
				that = t;
			}

			public override void OnAdClosed ()
			{
				that.RequestNewInterstitial ();
				that.BeginSecondActivity ();
			}
		}

		class OnClickListener : Java.Lang.Object, View.IOnClickListener
		{
			MainActivity that;

			public OnClickListener (MainActivity t)
			{
				that = t;
			}

			public void OnClick (View v)
			{
				if (that.mInterstitialAd.IsLoaded) {
					that.mInterstitialAd.Show ();
				} else {
					that.BeginSecondActivity ();
				}
			}
		}
	}
}


