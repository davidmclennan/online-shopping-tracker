using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace OnlineShoppingTracker.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Priority { get; set; }
        public string Stage { get; set; }
    }
}
