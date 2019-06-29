using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Admob
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();

            //MessagingCenter.Subscribe<MainPage, string>(this, "LoadVideo", (s, a) => {

            //});
		}

        //public void LoadVideo(object sender, EventArgs e)
        //{
        //    //MainActivity.Instance.LoadVideo();
        //}
    }
}
