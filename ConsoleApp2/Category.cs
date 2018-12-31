using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Category  
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        [ForeignKey("CategoryId")]
        public List<Product> Products { get; set; }
        public string Description { get; set; }
    }
}
