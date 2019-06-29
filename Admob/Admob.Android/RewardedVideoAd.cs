using System;
using Android.Content;
using Android.Gms.Ads;
using Android.Gms.Ads.DoubleClick;
using Android.Gms.Ads.Reward;
using Android.Widget;
using Xamarin.Forms;
using System.Diagnostics;

namespace Admob.Droid
{
    public class RewardedVideoAd : Java.Lang.Object, IRewardedVideoAd
    {
        private Context context;

        public RewardedVideoAd(Context context)
        {
            this.context = context;
        }

        public string AdUnitId { get; set; }

        public IntPtr Handle => Admob.AdMobView.;

        public bool IsLoaded => throw new NotImplementedException();

        public string MediationAdapterClassName => throw new NotImplementedException();

        public IRewardedVideoAdListener RewardedVideoAdListener { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            Toast.MakeText(Forms.Context, new StackTrace().GetFrame(0).GetMethod().Name, ToastLength.Short).Show();
        }

        public void Destroy()
        {
            Toast.MakeText(Forms.Context, new StackTrace().GetFrame(0).GetMethod().Name, ToastLength.Short).Show();
        }

        public void Destroy(Context context)
        {
            Toast.MakeText(Forms.Context, new StackTrace().GetFrame(0).GetMethod().Name, ToastLength.Short).Show();
        }

        public void LoadAd(string adUnitId, AdRequest adRequest)
        {
            Toast.MakeText(Forms.Context, new StackTrace().GetFrame(0).GetMethod().Name, ToastLength.Short).Show();
        }

        public void LoadAd(string adUnitId, PublisherAdRequest adRequest)
        {
            Toast.MakeText(Forms.Context, new StackTrace().GetFrame(0).GetMethod().Name, ToastLength.Short).Show();
        }

        public void Pause()
        {
            Toast.MakeText(Forms.Context, new StackTrace().GetFrame(0).GetMethod().Name, ToastLength.Short).Show();
        }

        public void Pause(Context context)
        {
            Toast.MakeText(Forms.Context, new StackTrace().GetFrame(0).GetMethod().Name, ToastLength.Short).Show();
        }

        public void Resume()
        {
            Toast.MakeText(Forms.Context, new StackTrace().GetFrame(0).GetMethod().Name, ToastLength.Short).Show();
        }

        public void Resume(Context context)
        {
            Toast.MakeText(Forms.Context, new StackTrace().GetFrame(0).GetMethod().Name, ToastLength.Short).Show();
        }

        public void SetImmersiveMode(bool immersiveModeEnabled)
        {
            Toast.MakeText(Forms.Context, new StackTrace().GetFrame(0).GetMethod().Name, ToastLength.Short).Show();
        }

        public void Show()
        {
            Toast.MakeText(Forms.Context, new StackTrace().GetFrame(0).GetMethod().Name, ToastLength.Short).Show();
        }
    }
}