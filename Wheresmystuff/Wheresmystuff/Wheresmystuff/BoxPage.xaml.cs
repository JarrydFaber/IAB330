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

namespace Wheresmystuff {
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
            box.Category = "default";
            box.QRcd = "default";
            MyDatabase new_user = new MyDatabase();
            new_user.InsertBox(box);
            BindingContext = new BoxViewModel();
        }

        private void EditBox(object sender, SelectedItemChangedEventArgs e) {
            var selectedbox = e.SelectedItem as Boxes;
            if (selectedbox == null) {
            } else {
                var box = new Boxes() {
                    BoxID = selectedbox.BoxID,
                    //AccountId = ((int)Application.Current.Properties["userId"]),
                    BoxName = selectedbox.BoxName,
                    Category = selectedbox.Category,
                    QRcd = selectedbox.QRcd
                };
                Navigation.PushModalAsync(new EditBoxPage(box));
            }
        }
    }
}