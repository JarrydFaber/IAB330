using SQLite.Net;
using Wheresmystuff.Databases;
using Wheresmystuff.Interfaces;
using Wheresmystuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Wheresmystuff.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly MyDatabase db;

        private string boxName;

        public string BoxName
        {
            get { return boxName; }
            set
            {
                boxName = value;
                OnPropertyChanged();
            }
        }
        private string qrcd;

        public string QRCD
        {
            get { return qrcd; }
            set
            {
                qrcd = value;
                OnPropertyChanged();
            }
        }

        private string category;

        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged();
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public ICommand SecondPageCommand { protected set; get; }
        public MainViewModel()
        {
            db = new MyDatabase();
            SubmitCommand = new Command(Submit);
            SecondPageCommand = new Command(() =>
            {
            });
        }

        public void Submit()
        {
            db.InsertBox(new Boxes()
            {
                BoxName = this.BoxName,
                QRcd = QRCD,
                Category = Category
            });
            BoxName = String.Empty;
            qrcd = String.Empty;
            Category = String.Empty;
        }
    }
}
