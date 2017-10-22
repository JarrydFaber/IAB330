using Wheresmystuff.Databases;
using Wheresmystuff.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheresmystuff.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
        private readonly MyDatabase db;
        private ObservableCollection<ToDoItem> toDoItems;

        public ObservableCollection<ToDoItem> ToDoItems
        {
            get { return toDoItems; }
            set
            {
                toDoItems = value;
                OnPropertyChanged();
            }
        }

        public SecondViewModel()
        {
            db = new MyDatabase();
            //ToDoItems = new ObservableCollection<ToDoItem>(db.GetAllToDoItems());
        }
    }
}
