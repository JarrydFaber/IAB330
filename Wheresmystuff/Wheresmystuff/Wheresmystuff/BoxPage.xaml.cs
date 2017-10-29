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
    public partial class BoxPage : ContentPage {
        public BoxPage() {
            InitializeComponent();
            BindingContext = new BoxViewModel();
        }

        private void AddNewBox_Clicked(object sender, EventArgs e) {
            string text = box_entry.Text;
            Boxes box = new Boxes();
            box.BoxName = text;
            MyDatabase new_user = new MyDatabase();
            new_user.InsertBox(box);
            BindingContext = new BoxViewModel();
        }

        private void EditBox(object sender, EventArgs e) {
            //int temp_boxID = editBoxButton.CommandParameter;
            int temp_boxID = 1; // has been set to 1 until major issue has been fixed
            Navigation.PushModalAsync(new EditBoxPage(temp_boxID));
        }
    }
}