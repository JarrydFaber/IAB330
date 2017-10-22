using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Wheresmystuff.Models
{
    public class Boxes
    {
        [PrimaryKey, AutoIncrement] //Sets the Primary Key for the table and switches on AutoIncrement
        public int BoxId { get; set; }

        [ForeignKey (typeof(Accounts))] //Sets AccountId as a Foreign Key
        public int AccountId { get; set; }

        public string BoxName { get; set; }
        public string QRcd { get; set; }
        public string Category { get; set; }

        [ManyToOne] //Establishes Many-to-One r/ship between Boxes and Accounts.
        public Accounts Accounts { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)] //Sets One-to-Many r/ship between Boxes and Accounts
        public List<Items_> Items{ get; set; } //Creates an indexed list of Items

    }
}
