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
        public EditBoxPage(int boxID) {
            InitializeComponent();
            BindingContext = new SpecificBoxViewModel(boxID);
    }

        private void addCategory(object sender, EventArgs e) {

        }

        private void editItem(object sender, EventArgs e) {

        }


    }
}