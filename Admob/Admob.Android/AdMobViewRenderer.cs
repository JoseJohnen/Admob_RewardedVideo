using System.ComponentModel;
using Admob;
using Admob.Droid;
using Android.Content;
using Android.Gms.Ads;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobViewRenderer))]
namespace Admob.Droid
{
	public class AdMobViewRenderer : ViewRenderer<AdMobView, AdView>
	{
        string adUnitId = "ca-app-pub-7050516707411195/4597911989";
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


        //Android.Gms.Ads.Reward

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

	}
}