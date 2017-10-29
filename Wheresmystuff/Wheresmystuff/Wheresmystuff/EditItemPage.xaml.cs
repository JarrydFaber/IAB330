using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheresmystuff.ViewModels;
using Wheresmystuff.Databases;
using Wheresmystuff.Models;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wheresmystuff {
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class EditItemPage : ContentPage {
        private int temp_itemID;

        public EditItemPage(int itemID) {
            temp_itemID = itemID;
            InitializeComponent();
            MyDatabase new_user = new MyDatabase();
            Items item = new_user.GetItem(itemID);
            itemName.Text = "Name: " + item.ItemName;
            itemQuantity.Text = "Quantity: " + item.Quantity.ToString();
            itemDescription.Text = "Description: " + item.TextDesc;
            itemId.Text = "ID: " + item.ItemID;
            BindingContext = new SpecificItemViewModel(itemID);
        }

        private void DeleteItem(object sender, EventArgs e) {
            MyDatabase new_user = new MyDatabase();
            Items item = new_user.GetItem(temp_itemID);
            new_user.DeleteItem(item);
        }
    }
}