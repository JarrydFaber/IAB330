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
    //private readonly MyDatabase db;
    //private ObservableCollection<Boxes> box;
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class EditBoxPage : ContentPage {
        private int temp_boxID;

        public EditBoxPage(int boxID) {
            temp_boxID = boxID;
            InitializeComponent();
            BindingContext = new SpecificBoxViewModel(boxID);
        }

        private void AddNewItem_Clicked(object sender, EventArgs e) {
            string text = item_entry.Text;
            Items item = new Items();
            item.ItemName = text;
            item.BoxID = temp_boxID;
            item.Quantity = 1;
            item.TextDesc = "default";
            MyDatabase new_user = new MyDatabase();
            new_user.AddItem(item);
            BindingContext = new ItemViewModel();
        }

        private void AddCategory(object sender, EventArgs e) {
            Category.Text = new Entry().Text;
            Boxes box = new Boxes();
            box.Category = Category.Text;
            MyDatabase new_user = new MyDatabase();
            new_user.InsertOrUpdateBox(box);
        }

        private void EditItem(object sender, SelectedItemChangedEventArgs e) {
            var selecteditem = e.SelectedItem as Items;
            if (selecteditem == null) {
                throw new Exception();
            } else {
                var item = new Items() {
                    ItemID = selecteditem.ItemID,
                    //AccountId = ((int)Application.Current.Properties["userId"]),
                    BoxID = selecteditem.BoxID,
                    ItemName = selecteditem.ItemName,
                    Quantity = selecteditem.Quantity,
                    TextDesc = selecteditem.TextDesc
                };
                Navigation.PushModalAsync(new EditItemPage(item.ItemID));
            }
        }
    }
}