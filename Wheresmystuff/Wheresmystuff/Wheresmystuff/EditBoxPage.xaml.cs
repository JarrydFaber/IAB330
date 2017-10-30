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
        private Boxes temp_box;
        public int item_counter = 0;

        public EditBoxPage(Boxes box) {
            temp_box = box;
            BindingContext = new SpecificBoxViewModel(box);
            InitializeComponent();
            boxName.Text = "Box Name: " + box.BoxName;
            boxID.Text = "Box ID: " + box.BoxID.ToString();
            BindingContext = new SpecificBoxViewModel(box);
        }

        private void AddNewItem_Clicked(object sender, EventArgs e) {
            string text = item_entry.Text;
            Items item = new Items();
            item.ItemID = item_counter + 1;
            item.ItemName = text;
            item.BoxID = temp_box.BoxID;
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
                Navigation.PushModalAsync(new EditItemPage(item));
            }
        }

        private void DeleteBox(object sender, EventArgs e) {
            MyDatabase new_user = new MyDatabase();
            new_user.DeleteBox(temp_box);
            Navigation.PushModalAsync(new BoxPage());
        }
    }
}