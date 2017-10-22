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

            database.CreateTable<ToDoItem>();
        }
        
        public int Insert(ToDoItem toDoItem)
        {
            var item = database.Insert(toDoItem);
            database.Commit();
            return item;

        }
        public int InsertOrUpdate(ToDoItem toDoItem)
        {
            int num;
            if (database.Table<ToDoItem>().Any(x=> x.Id == toDoItem.Id))
            {
                num = database.Update(toDoItem);
            }
            else
            {
                num = database.Insert(toDoItem);
            }
            database.Commit();
            return num;
        }
        public int Delete(ToDoItem toDoItem)
        {
            int num;
            num = database.Delete<ToDoItem>(toDoItem.Id);
            database.Commit();
            return num;
        }

        public List<ToDoItem> GetAllToDoItems()
        {
            return database.Table<ToDoItem>().ToList();
        }

        public ToDoItem GetToDoItem(int key)
        {
            return database.Table<ToDoItem>().Where(tablerow => tablerow.Id == key).FirstOrDefault();
        }
    }
}
