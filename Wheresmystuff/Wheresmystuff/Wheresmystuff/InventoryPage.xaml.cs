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
    public partial class InventoryPage : ContentPage {
        public InventoryPage() {
            InitializeComponent();
            BindingContext = new ItemViewModel();
        }

        private void addNewItem_Clicked(object sender, EventArgs e) {
            string text = item_entry.Text;
            Items item = new Items();
            item.ItemName = text;
            MyDatabase database = new MyDatabase();
            database.AddItem(item); 
            BindingContext = new ItemViewModel();
        }
    }
}