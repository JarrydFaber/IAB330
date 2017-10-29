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

    public partial class EditItemPage : ContentPage {
        private int temp_itemID;

        public EditItemPage(int itemID) {
            temp_itemID = itemID;
            InitializeComponent();
            BindingContext = new SpecificItemViewModel(itemID);
        }
    }
}