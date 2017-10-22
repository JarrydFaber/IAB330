using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Wheresmystuff.Models
{
    public class Items_
    {
        [PrimaryKey, AutoIncrement] //Sets the Primary Key for the table and switches on AutoIncrement
        public int ItemId { get; set; }

        [ForeignKey(typeof(Accounts))] //Sets AccountId as a Foreign Key
        public int AccountId { get; set; }

        [ForeignKey(typeof(Boxes))] //Sets BoxId as a Foreign Key
        public int BoxId { get; set; }

        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string TextDesc { get; set; }

        [ManyToOne]
        public Accounts Accounts { get; set; }

        [ManyToOne] //Establishes the Many-to-One relationship between Items and Boxes.
        public Boxes Boxes { get; set; }




    }
}
