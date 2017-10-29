﻿using System;
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
    //[XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class EditBoxPage : ContentPage {
        private int temp_itemID;

        public EditBoxPage(int itemID) {
            temp_itemID = itemID;
            InitializeComponent();
            BindingContext = new SpecificItemViewModel(itemID);
        }

        private void AddNewItem_Clicked(object sender, EventArgs e) {
            string text = item_entry.Text;
            Items item = new Items();
            item.ItemName = text;
            MyDatabase new_user = new MyDatabase();
            new_user.AddItemToBox(item);
            BindingContext = new ItemViewModel();
        }

        private void AddCategory(object sender, EventArgs e) {

        }

        private void EditItem(object sender, EventArgs e) {
            //int temp_itemID = editBoxButton.CommandParameter;
            int temp_itemID = 1; // has been set to 1 until major issue has been fixed
            Navigation.PushModalAsync(new EditItemPage(temp_itemID));
        }
    }
}