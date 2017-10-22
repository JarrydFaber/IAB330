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

            database.CreateTable<Users>();
            database.CreateTable<Accounts>();
            database.CreateTable<Boxes>();
            database.CreateTable<Items>();
        }


        //Insert methods for each table class
        public int Insert(Users toDoItem)
        {
            var user = database.Insert(toDoItem);
            database.Commit();
            return user;

        }

        public int Insert(Accounts toDoItem)
        {
            var account = database.Insert(toDoItem);
            database.Commit();
            return account;

        }

        public int Insert(Boxes toDoItem)
        {
            var box = database.Insert(toDoItem);
            database.Commit();
            return box;

        }

        public int Insert(Items toDoItem)
        {
            var item = database.Insert(toDoItem);
            database.Commit();
            return item;

        }


        //Insert or Update methods for each table class
        public int InsertOrUpdate(Users toDoItem)
        {
            int num;
            if (database.Table<Users>().Any(x=> x.UserId == toDoItem.UserId))
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


        public int InsertOrUpdate(Accounts toDoItem)
        {
            int num;
            if (database.Table<Accounts>().Any(x => x.AccountId == toDoItem.AccountId))
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

        public int InsertOrUpdate(Boxes toDoItem)
        {
            int num;
            if (database.Table<Boxes>().Any(x => x.BoxId == toDoItem.BoxId))
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

        public int InsertOrUpdate(Items_ toDoItem)
        {
            int num;
            if (database.Table<Items_>().Any(x => x.ItemId == toDoItem.ItemId))
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


        //Delete methods for each table class
        public int Delete(Users toDoItem)
        {
            int num;
            num = database.Delete<Users>(toDoItem.UserId);
            database.Commit();
            return num;
        }

        public int Delete(Accounts toDoItem)
        {
            int num;
            num = database.Delete<Accounts>(toDoItem.AccountId);
            database.Commit();
            return num;
        }

        public int Delete(Boxes toDoItem)
        {
            int num;
            num = database.Delete<Boxes>(toDoItem.BoxId);
            database.Commit();
            return num;
        }

        public int Delete(Items_ toDoItem)
        {
            int num;
            num = database.Delete<Items_>(toDoItem.ItemId);
            database.Commit();
            return num;
        }



        //Return All methods for each table class
        public List<Users> GetAllUsers()
        {
            return database.Table<Users>().ToList();
        }

        public List<Accounts> GetAllAccounts()
        {
            return database.Table<Accounts>().ToList();
        }

        public List<Boxes> GetAllBoxes()
        {
            return database.Table<Boxes>().ToList();
        }

        public List<Items_> GetAllItems()
        {
            return database.Table<Items_>().ToList();
        }

        //Return specified record methods for each table class
        public Users GetUser(int key)
        {
            return database.Table<Users>().Where(tablerow => tablerow.UserId == key).FirstOrDefault();
        }

        public Accounts GetAccount(int key)
        {
            return database.Table<Accounts>().Where(tablerow => tablerow.AccountId == key).FirstOrDefault();
        }

        public Boxes GetBox(int key)
        {
            return database.Table<Boxes>().Where(tablerow => tablerow.BoxId == key).FirstOrDefault();
        }

        public Items_ GetItem(int key)
        {
            return database.Table<Items_>().Where(tablerow => tablerow.ItemId == key).FirstOrDefault();
        }
    }
}
