using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheresmystuff.Interfaces;
using Wheresmystuff.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wheresmystuff
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            //InitializeComponent();
            BindingContext = new SecondViewModel();
        }
    }
}