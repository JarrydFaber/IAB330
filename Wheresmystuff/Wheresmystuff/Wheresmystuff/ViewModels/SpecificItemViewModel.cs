/* Title: Where's My Stuff
 * Subject: IAB330 
 * Group Members: Doug Brennan, Andrew Wallington, Jarryd Bent, Joseph Richards
 * Date: 29/10/17
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheresmystuff.Databases;
using Wheresmystuff.Models;
using System.Collections.ObjectModel;

namespace Wheresmystuff.ViewModels { 
    public class SpecificItemViewModel : ViewModelBase {
        private readonly MyDatabase db;
        private ObservableCollection<Boxes> box;
        private ObservableCollection<Items> item;

        public ObservableCollection<Boxes> Box {
            get { return box; }
            set {
                box = value;
                OnPropertyChanged(); 
            }
        }

        public ObservableCollection<Items> Item {
            get { return item; }
            set {
                item = value;
                OnPropertyChanged();
            }
        }

        public SpecificItemViewModel(int itemID) {
            db = new MyDatabase();
            item = new ObservableCollection<Items>(db.GetAllItems().Where(x => x.ItemID == itemID));
        }
    }
}
