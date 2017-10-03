using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wheresmystuff
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		void InventoryButton (object sender, EventArgs args)
		{
			// Write code here to move onto inventory page
			Navigation.PushModalAsync(new Page1());
		}

		void BoxesButton(object sender, EventArgs args)
		{
			// Write code here to move onto inventory page
			Navigation.PushModalAsync(new BoxPage());
		}

		void ScanButton(object sender, EventArgs args)
		{
			// Write code here to move onto inventory page
			Navigation.PushModalAsync(new ScanPage());
		}

		void PrintButton(object sender, EventArgs args)
		{
			// Write code here to move onto inventory page
			Navigation.PushModalAsync(new PrintPage());
		}

		private void inventoryButton_Clicked(object sender, EventArgs e)
		{

		}

	}
}
