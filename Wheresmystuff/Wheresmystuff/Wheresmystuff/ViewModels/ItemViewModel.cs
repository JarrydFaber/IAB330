﻿/* Title: Where's My Stuff
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
    public class ItemViewModel : ViewModelBase {
        private readonly MyDatabase db;
        private ObservableCollection<Items> items;

        public ObservableCollection<Items> Items {
            get { return items; }
            set {
                items = value;
                OnPropertyChanged(); 
            }
        }

        public ItemViewModel() { //Creates a new view model containing all instances of Items
            db = new MyDatabase();
            items = new ObservableCollection<Items>(db.GetAllItems());
        }
    }
}
