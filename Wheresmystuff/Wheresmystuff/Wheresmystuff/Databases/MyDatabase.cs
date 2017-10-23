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

namespace Wheresmystuff.Databases
{
    public class MyDatabase
    {
        public SQLiteConnection database;

        public MyDatabase()
        {
            database = new SQLiteConnection(DependencyService.Get<ISQLitePlatform>(), 
                DependencyService.Get<IFileHelper>().GetLocalpath("WheresMyStuffSQLite.db"));

        }

        public void CreateTables() {
            database.CreateTable<Boxes>();
            database.CreateTable<Items>();
        }
        
        public int InsertBox(Boxes box)
        {
            var item = database.Insert(box);
            database.Commit();
            return item;

        }
        public int InsertOrUpdateBox(Boxes box)
        {
            int num;
            if (database.Table<Boxes>().Any(x=> x.BoxId == box.BoxId))
            {
                num = database.Update(box);
            }
            else
            {
                num = database.Insert(box);
            }
            database.Commit();
            return num;
        }
        public int DeleteBox(Boxes box)
        {
            int num;
            num = database.Delete<Boxes>(box.BoxId);
            database.Commit();
            return num;
        }

        public List<Boxes> GetAllBoxes()
        {
            return database.Table<Boxes>().ToList();
        }

        public Boxes GetBox(int key)
        {
            return database.Table<Boxes>().Where(x => x.BoxId == key).FirstOrDefault();
        }

//Items
        public int AddItem(Items item) {
            var item_temp = database.Insert(item);
            database.Commit();
            return item_temp;

        }
        //public int InsertOrUpdateBox(Items item) { *This should fix itself when sql library error is resolved* //TODO
        //    int num;
        //    if (database.Table<Items>().Any(x => x.ItemId == item.ItemId)) {
        //        num = database.Update(item);
        //    } else {
        //        num = database.Insert(item);
        //    }
        //    database.Commit();
        //    return num;
        //}
        //public int DeleteItem(Items item) { *This should fix itself when sql library error is resolved* //TODO
        //    int num;
        //    num = database.Delete<Items>(item.ItemId);
        //    database.Commit();
        //    return num;
        //}

        public List<Items> GetAllItems() {
            return database.Table<Items>().ToList();
        }

        public Items GetItem(int key) { // Change return statement when sql error is resolved
            return null; //TODO
            //return database.Table<Items>().Where(x => x.ItemId == key).FirstOrDefault();
            //return database.Table<Boxes>().Where(tablerow => tablerow.Id == key).FirstOrDefault();
        }
    }
}
