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

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        private string details;

        public string Details
        {
            get { return details; }
            set
            {
                details = value;
                OnPropertyChanged();
            }
        }

        private bool complete;

        public bool Complete
        {
            get { return complete; }
            set
            {
                complete = value;
                OnPropertyChanged();
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public ICommand SecondPageCommand { protected set; get; }
        public MainViewModel()
        {
            db = new MyDatabase();
            //SubmitCommand = new Command(Submit);
            SecondPageCommand = new Command(() =>
            {
            });
        }

        //public void Submit()
        //{
        //    db.Insert(new ToDoItem()
        //    {
        //        Title = this.Title,
        //        Details = Details,
        //        Complete = Complete
        //    });
        //    Title = String.Empty;
        //    Details = String.Empty;
        //    Complete = false;
        //}
    }
}
