using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Migrations;

namespace ConsoleApp2
{
    class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        [ForeignKey("OrderId")]
        public List<OrderedProduct> OrderedProducts { get; set; }
       // public Customer Customer { get; set; }
    }
}
