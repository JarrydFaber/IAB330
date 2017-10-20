using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wheresmystuff
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InventoryPage : ContentPage
	{
		public InventoryPage()
		{
			InitializeComponent();
		}

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondPage());
        }
    }
}