using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVmain
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : PopupPage
    {
        

		public Page1 (string sn)
		{
			InitializeComponent();
           
            animV.Animation = sn;

        }

        private void AnimationView_OnFinish(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }

      
    }
}