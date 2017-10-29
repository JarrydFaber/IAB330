using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;


/* Title: Where's My Stuff
 * Subject: IAB330 
 * Group Members: Doug Brennan, Andrew Wallington, Jarryd Bent, Joseph Richards
 * Date: 29/10/17
 */

namespace Wheresmystuff.Models
{
    public class Items
    {
        [PrimaryKey, AutoIncrement] //Sets the Primary Key for the table and switches on AutoIncrement
        public int ItemID { get; set; }

        [ForeignKey(typeof(Accounts))] //Sets AccountId as a Foreign Key
        public int AccountId { get; set; }

        [ForeignKey(typeof(Boxes))] //Sets BoxId as a Foreign Key
        public int BoxID { get; set; }

        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string TextDesc { get; set; }

        [ManyToOne]
        public Accounts Accounts { get; set; }

        [ManyToOne] //Establishes the Many-to-One relationship between Items and Boxes.
        public Boxes Boxes { get; set; }




    }
}
