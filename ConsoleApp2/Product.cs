using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryId { get; set; }
        [Column(TypeName = "money")]
        public decimal Unitprice { get; set; }
    }
}
