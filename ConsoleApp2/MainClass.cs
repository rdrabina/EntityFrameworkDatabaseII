using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class MainClass
    {
        static void Main(string[] args)
        {
            //string name = Console.ReadLine();
            Category category = new Category
            {
                //Name = name
            };

            Category category1 = new Category
            {
                Name = "Category1"
            };
            Category category2 = new Category
            {
                Name = "Category2"
            };
            Category category3 = new Category
            {
                Name = "Category3"
            };
            Order order1 = new Order
            {
                Name = "Order1"
            };
            Product product1 = new Product
            {
                Name = "Product1",
                CategoryId = 1
            };
            Product product2 = new Product
            {
                Name = "Product2",
                CategoryId = 1
            };
            Product product3 = new Product
            {
                Name = "Product3",
                CategoryId = 2
            };
            Product product4 = new Product
            {
                Name = "Product4",
                CategoryId = 3
            };
            Product product5 = new Product
            {
                Name = "Product5",
                CategoryId = 2
            };

            using (ProdContext context = new ProdContext())
            {
                
                /*context.Categories.Add(category1);
                context.Categories.Add(category2);
                context.Categories.Add(category3);*/
                
                //context.Orders.Add(order1);
                context.Products.Add(product1);
               context.Products.Add(product2);
                context.Products.Add(product3);
                context.Products.Add(product4);
                context.Products.Add(product5);
                context.SaveChanges();

                /*IQueryable query = from c in context.Categories
                                   orderby c.Name descending
                                   select c.Name;

                List<string> categoryNameList = context.Categories.OrderByDescending(c => c.Name).Select(c => c.Name).ToList();

                foreach (var c in query)
                {
                    Console.WriteLine(c);
                }
                Console.WriteLine('\n');

                foreach (var c in categoryNameList)
                {
                    Console.WriteLine(c);
                }
                -----------
                var queryJoin = from c in context.Categories
                                       join p in context.Products
                                       on c.CategoryId equals p.CategoryId
                                       select new
                                       {
                                           CategoryName = c.Name,
                                           ProductName = p.Name
                                       };

                foreach (var x in queryJoin)
                {
                    Console.WriteLine("{0}\t{1}", x.CategoryName, x.ProductName);
                }

                Console.WriteLine();

                var queryJoin2 = context.Categories.Join(
                    context.Products, p => p.CategoryId, c => c.CategoryId, (c, p) => new
                    {
                        CategoryName = c.Name,
                        ProductName = p.Name
                    });
                foreach (var x in queryJoin2)
                {
                    Console.WriteLine("{0}\t{1}", x.CategoryName, x.ProductName);
                }
                --------
                


                IQueryable query = from c in context.Categories
                                   select c;

                foreach(Category c in query)
                {
                    Console.WriteLine(c.Name);
                    foreach (var p in c.Products)
                    {
                        Console.WriteLine(p.Name);
                    }
                }  
                
                ------
                    

                context.Configuration.LazyLoadingEnabled = true;
                IList<Category> categories = context.Categories.ToList<Category>();

                foreach(Category c in categories)
                {
                    Console.WriteLine(c.Name);
                    foreach (Product p in c.Products)
                    {
                        Console.WriteLine(p.Name);
                    }
                }

                ----
                    
                IList<Category> categories = context.Categories.Include("Products").ToList();

                foreach(Category c in categories)
                {
                    Console.WriteLine(c.Name);
                    foreach(Product p in c.Products)
                    {
                        Console.WriteLine(p.Name);
                    }
                }
                -----
                
                var query = from c in context.Categories
                                   join p in context.Products
                                   on c.CategoryId equals p.CategoryId
                                   select new
                                   {
                                       CategoryName = c.Name,
                                       ProductCount = c.Products.Count()
                                   };
                foreach (var a in query)
                {
                    Console.WriteLine("{0} \t {1}", a.CategoryName, a.ProductCount);
                }
                ------
                    

                var query = context.Categories.Join(
                        context.Products, p => p.CategoryId, c => c.CategoryId, (c, p) => new
                        {
                            CategoryName = c.Name,
                            ProductCount = c.Products.Count()
                        });
                foreach (var x in query)
                {
                    Console.WriteLine("{0}\t{1}", x.CategoryName, x.ProductCount);
                }

            }
            ---
                

                Console.WriteLine("Prosze podać nazwę zamówienia, a następnie wybrać produkty:");

                string orderName = Console.ReadLine();
                Order order = new Order
                {
                    Name = orderName
                };
                context.Orders.Add(order);
                context.SaveChanges();

                var query = (from p in context.Products
                             group p by p.Name into g
                             select new
                             {
                                 Name = g.Key,
                             }).ToList();
                int i = 0;
                Console.WriteLine(i + ". Exit");
                foreach (var name in query)
                {
                    i++;
                    Console.WriteLine(i + ". " + name.Name);
                }
                while (true)
                {
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice <= 0 || choice > i) break;

                    string name = query[choice - 1].Name;

                        Product orderedProduct = context.Products
                            .Where(product => product.Name == name)
                            .Select(product => product).First();

                        Order orderedOrder = context.Orders
                            .OrderByDescending(o => o.OrderId)
                            .Select(c => c).First();

                        OrderedProduct ordered = new OrderedProduct
                        {
                            OrderId = orderedOrder.OrderId,
                            ProductId = orderedProduct.ProductId
                        };

                        context.OrderedProducts.Add(ordered);
                        context.SaveChanges();
                    

                }
                -----------
                
                context.Configuration.LazyLoadingEnabled = true;
                var eagerOrders = context.Orders.Include("OrderedProducts").ToList();
                OrderedProduct eagerOrderedProduct = eagerOrders[0].OrderedProducts[0];
                -----------
             */
                Console.WriteLine("Category form zaraz się pojawi...");
                CategoryForm categoryForm = new CategoryForm();
                categoryForm.ShowDialog();
                Console.ReadLine();
            }
        }
    }
}
