using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Wheresmystuff.Models
{
    public class Users
    {
        [PrimaryKey, AutoIncrement] //Sets the Primary Key for the table and switches on AutoIncrement
        public int UserId { get; set; }

        [ForeignKey(typeof(Accounts))] //Sets AccountId as the Foreign Key
        public int AccountId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddr { get; set; }
        public string UserPwd { get; set; }
        public string Salt { get; set; }

        [ManyToOne] //Establishes the Many-to-One relationship between Users and Accounts.
        public Accounts Accounts { get; set; }
    }
}
