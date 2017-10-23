using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheresmystuff.ViewModels;
using Wheresmystuff.Databases;
using Wheresmystuff.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wheresmystuff
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BoxPage : ContentPage
	{
		public BoxPage ()
		{
			InitializeComponent ();
            BindingContext = new BoxViewModel(); 
        }

        private void addNewBox_Clicked(object sender, EventArgs e) {
            string text = box_entry.Text;
            Boxes box = new Boxes();
            box.BoxName = text;
            MyDatabase new_user = new MyDatabase();
            new_user.Insert(box);
            //var box_name = new Entry { Text = "Add New Box" }; 
        }
    }
}