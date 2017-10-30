/* Title: Where's My Stuff
 * Subject: IAB330 
 * Group Members: Doug Brennan, Andrew Wallington, Jarryd Bent, Joseph Richards
 * Date: 29/10/17
 */

using SQLite.Net;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheresmystuff.Interfaces;
using Wheresmystuff.Models;
using Xamarin.Forms;

namespace Wheresmystuff.Databases { 
    public class MyDatabase {
        public SQLiteConnection database;

        public MyDatabase() { //Establishes a connection to the database 
            database = new SQLiteConnection(DependencyService.Get<ISQLitePlatform>(), 
                DependencyService.Get<IFileHelper>().GetLocalpath("WheresMyStuffSQLite.db"));
        }

        public void CreateTables() { //Initialises the database tables
            database.CreateTable<Boxes>();
            database.CreateTable<Items>();
        }

        public void DeleteTables() {
            database.DropTable<Boxes>();
            database.DropTable<Items>();
        }

//Boxes
        public int InsertBox(Boxes box) { //Add a box instance to the Boxes table
            var item = database.Insert(box);
            database.Commit();
            return item;
        }

        public int InsertOrUpdateBox(Boxes box) { //Updates Boxes instance if it exists, if not box is inserted into Boxes table
            int num;
            if (database.Table<Boxes>().Any(x=> x.BoxID == box.BoxID)) {
                num = database.Update(box);
            } else {
                num = database.Insert(box);
            }
            database.Commit();
            return num;
        }

        public int DeleteBox(Boxes box) { //Deletes box instance
            int num;
            num = database.Delete<Boxes>(box);
            //database.Commit();
            return num;
        }

        public List<Boxes> GetAllBoxes() { //Returns each Boxes instance from the table
            return database.Table<Boxes>().ToList();
        }

        public Boxes GetBox(Boxes box) { //Returns a box using its BoxID
            return database.Table<Boxes>().Where(x => x == box).FirstOrDefault();
        }

//Items
        public int AddItem(Items item) { //Adds an item instance to the Items table
            var item_temp = database.Insert(item);
            database.Commit();
            return item_temp;
        }

        public int InsertOrUpdateItem(Items item) { //Updates Items instance if it exists, if not item is inserted into Items table
            int num;
            if (database.Table<Items>().Any(x => x.ItemID == item.ItemID)) {
                num = database.Update(item);
            } else {
                num = database.Insert(item);
            }
            database.Commit();
            return num;
        }

        public int DeleteItem(Items item) { //Deletes Items instance
            int num;
            num = database.Delete<Items>(item);
            database.Commit();
            return num;
        }

        public List<Items> GetAllItems() { //Returns all instances in Items table
            return database.Table<Items>().ToList();
        }

        public Items GetItem(Items item) { //Returns a specific item 
            return database.Table<Items>().Where(x => x.ItemID == item.ItemID).FirstOrDefault();
        }

        public List<Items> GetItemsInBox(Boxes box) { //Returns all items which have been assigned to a specific BoxID
            return database.Table<Items>().Where(x => x.BoxID == box.BoxID).ToList();
        }
    }
}
