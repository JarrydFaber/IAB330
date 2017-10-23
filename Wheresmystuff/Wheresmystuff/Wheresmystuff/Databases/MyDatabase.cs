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
        static SQLiteConnection database;

        public MyDatabase()
        {
            database = new SQLiteConnection(DependencyService.Get<ISQLitePlatform>(), 
                DependencyService.Get<IFileHelper>().GetLocalpath("ToDoSQLite.db"));

            database.CreateTable<Boxes>();
        }
        
        public int Insert(Boxes box)
        {
            var item = database.Insert(box);
            database.Commit();
            return item;

        }
        public int InsertOrUpdate(Boxes box)
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
        public int Delete(Boxes box)
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
            //return database.Table<Boxes>().Where(tablerow => tablerow.Id == key).FirstOrDefault();
        }
    }
}
