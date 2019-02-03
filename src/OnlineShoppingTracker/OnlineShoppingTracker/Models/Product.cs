using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

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

        [Ignore]
        public Color PriorityColour
        {
            get
            {
                switch (Priority)
                {
                    case "LOW":
                        return Color.FromHex("#69C452");
                    case "MED":
                        return Color.FromHex("#DE8F47");
                    case "HIGH":
                        return Color.FromHex("#DE3535");
                    default:
                        return Color.FromHex("#69C452");
                }
            }
        }
    }
}
