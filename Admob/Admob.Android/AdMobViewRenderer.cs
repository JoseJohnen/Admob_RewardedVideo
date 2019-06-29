using System.ComponentModel;
using Admob;
using Admob.Droid;
using Android.Content;
using Android.Gms.Ads;
using Android.Gms.Ads.Reward;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobViewRenderer))]
namespace Admob.Droid
{
    public class AdMobViewRenderer : ViewRenderer<AdMobView, AdView>, IRewardedVideoAdListener
	{
        string adUnitId = "ca-app-pub-3940256099942544/5224354917"; //Prueba Banner "ca-app-pub-3940256099942544/6300978111"; //Mio Banner "ca-app-pub-7050516707411195/4597911989";
        AdSize adSize = AdSize.SmartBanner;

        public AdMobViewRenderer(Context context) : base(context) { }
		
		protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null && Control == null)
			{
                //CreateAdViewInterstitialAd().Show();
                SetNativeControl(CreateAdView());
            }
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == nameof(AdView.AdUnitId))
				Control.AdUnitId = Element.AdUnitId;
		}
        
        private RewardedVideoAd CreateRewardVideo()
        {
            var adView = new RewardedVideoAd(Context);//(Context)

            //adView.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            adView.LoadAd(adUnitId, new AdRequest.Builder().Build());

            return adView;
        }

        private InterstitialAd CreateAdViewInterstitialAd()
        {
            var adView = new InterstitialAd(Context)
            {
                //AdSize = AdSize.SmartBanner,
                AdUnitId = Element.AdUnitId
            };

            //adView.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            adView.LoadAd(new AdRequest.Builder().Build());
            
            return adView;
        }

        private AdView CreateAdView()
        {
            var adView = new AdView(Context)
            {
                AdSize = AdSize.SmartBanner,
                AdUnitId = adUnitId //Element.AdUnitId
            };
			
			adView.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent); 

			adView.LoadAd(new AdRequest
							.Builder()
							.Build());
		
			return adView;
		}

        public void OnRewardedVideoAdLeftApplication()
        {
            Toast.MakeText(Forms.Context, "onRewardedVideoAdLeftApplication", ToastLength.Short).Show();
        }

        public void OnRewardedVideoAdClosed()
        {
            Toast.MakeText(Forms.Context, "onRewardedVideoAdClosed", ToastLength.Short).Show();
        }

        public void OnRewardedVideoAdFailedToLoad(int errorCode)
        {
            Toast.MakeText(Forms.Context, "onRewardedVideoAdFailedToLoad", ToastLength.Short).Show();
        }

        public void OnRewardedVideoAdLoaded()
        {
            Toast.MakeText(Forms.Context, "onRewardedVideoAdLoaded", ToastLength.Short).Show();
        }

        public void OnRewardedVideoAdOpened()
        {
            Toast.MakeText(Forms.Context, "onRewardedVideoAdOpened", ToastLength.Short).Show();
        }

        public void OnRewardedVideoStarted()
        {
            Toast.MakeText(Forms.Context, "onRewardedVideoStarted", ToastLength.Short).Show();
        }

        public void OnRewardedVideoCompleted()
        {
            Toast.MakeText(Forms.Context, "onRewardedVideoCompleted", ToastLength.Short).Show();
        }

        public void OnRewarded(IRewardItem reward)
        {
            Toast.MakeText(Forms.Context, "onRewarded! currency: ${reward.type} amount: ${reward.amount}", ToastLength.Short).Show();
            // Reward the user.
        }
    }

}