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
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Wheresmystuff.Models
{
    public class Accounts
    {
        [PrimaryKey, AutoIncrement] //Sets the Primary Key for the table and switches on AutoIncrement
        public int AccountId { get; set; }
        

        [ForeignKey(typeof(Boxes))] //Sets BoxId as a Foreign Key
        public int BoxId { get; set; }

        [ForeignKey(typeof(Items))] //Sets ItemId as a Foreign Key
        public int ItemId { get; set; }

        public string AccountName { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)] //Sets One-to-Many r/ship between Accounts and Boxes
        public List<Boxes> Boxes { get; set; } //Creates an indexed list of Boxes

        [OneToMany(CascadeOperations = CascadeOperation.All)] //Sets One-to-Many r/ship between Accounts and Items
        public List<Items> Items { get; set; } //Creates an indexed list of Items

        [OneToMany(CascadeOperations = CascadeOperation.All)] //Sets One-to-Many r/ship between Accounts and Users
        public List<Users> Users { get; set; } //Creates an indexed list of Users


    }
}
