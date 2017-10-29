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
            MyDatabase new_user = new MyDatabase();
            new_user.AddItemToBox(item);
            BindingContext = new SpecificBoxViewModel(temp_boxID);
        }


        private void AddCategory(object sender, EventArgs e) {

        }

        private void EditItem(object sender, EventArgs e) {

        }


    }
}