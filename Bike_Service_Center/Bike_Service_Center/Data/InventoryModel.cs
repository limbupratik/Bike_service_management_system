using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Service_Center.Data
{
    internal class InventoryModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Item { get; set; }
        public int Quantity { get; set; }
        public string Approved_by { get; set; }
        public string Taken_by { get; set; }

        public DateTime Date_taken_out { get; set; }= DateTime.Now;



    }
}