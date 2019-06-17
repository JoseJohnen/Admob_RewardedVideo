using Xamarin.Forms;

namespace Admob
{
	public class MainPageViewModel: BindableObject
    {

        public string AdUnitId { get; set; } = "ca-app-pub-3940256099942544/6300978111";
            //"ca-app-pub-3940256099942544/1033173712"; //Intersticial test
            //"ca-app-pub-3940256099942544/6300978111"; //Banner Test (Original)
            //"ca-app-pub-7050516707411195/8444756290";

        public void Test()
		{
			if (Device.RuntimePlatform == Device.iOS)
				AdUnitId = "iOS Key";
			else if (Device.RuntimePlatform == Device.Android)
				AdUnitId = "Android Key";
		}
	}
}
