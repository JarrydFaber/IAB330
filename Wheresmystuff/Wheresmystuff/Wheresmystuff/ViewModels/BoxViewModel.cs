using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheresmystuff.Databases;
using Wheresmystuff.Models;
using System.Collections.ObjectModel;

namespace Wheresmystuff.ViewModels { 
    public class BoxViewModel : ViewModelBase {
        private readonly MyDatabase db;
        private ObservableCollection<Boxes> boxes;

        public ObservableCollection<Boxes> Boxes {
            get { return boxes; }
            set {
                boxes = value;
                OnPropertyChanged(); 
            }
        }

        public BoxViewModel() {
            db = new MyDatabase();
            Boxes = new ObservableCollection<Boxes>(db.GetAllBoxes());
        }
    }
}
