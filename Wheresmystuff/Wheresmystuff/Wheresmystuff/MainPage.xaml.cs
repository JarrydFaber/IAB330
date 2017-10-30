using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Wheresmystuff.Databases;
using Wheresmystuff.ViewModels;

namespace Wheresmystuff {
	public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();
            MyDatabase new_user = new MyDatabase();
            //new_user.CreateTables();
            BindingContext = new MainViewModel();
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
            Navigation.PushModalAsync(new InventoryPage());
        }

        private void DeleteData(object sender, EventArgs e) {
            MyDatabase new_user = new MyDatabase();
            new_user.DeleteTables();
            new_user.CreateTables();
        }


    }
}
