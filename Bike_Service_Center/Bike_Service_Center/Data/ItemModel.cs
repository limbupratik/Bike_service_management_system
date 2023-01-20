using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Service_Center.Data
{
    internal class ItemModel
    {
        
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }

        public DateTime Date { get; set;}

    }
}

