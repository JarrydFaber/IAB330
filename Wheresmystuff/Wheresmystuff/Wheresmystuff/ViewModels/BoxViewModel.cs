using System;
using System.Collections.Generic;
using System.Linq;
/* Title: Where's My Stuff
 * Subject: IAB330 
 * Group Members: Doug Brennan, Andrew Wallington, Jarryd Bent, Joseph Richards
 * Date: 29/10/17
 */

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

        public BoxViewModel() { //Creates a new view model containing all instances of Boxes
            db = new MyDatabase();
            Boxes = new ObservableCollection<Boxes>(db.GetAllBoxes());
        }
    }
}
