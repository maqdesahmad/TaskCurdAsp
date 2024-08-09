using AspTaskCurd.Data;
using AspTaskCurd.Models;
using TaskCurdAsp.Models;

namespace TaskCurdAsp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
               Product p = new Product() { Name = "Laptop", Price = 300 };
               Product p1 = new Product() { Name = "Smartphone", Price = 150 };
               Product p2 = new Product() { Name = "Headphones", Price = 400 };
               Product p3 = new Product() { Name = "Smartwatch", Price = 350 };
               Order o = new Order() { Address = "jenin" };
               Order o1 = new Order() { Address = "Jerusalem" };
               Order o2 = new Order() { Address = "Hebron" };
               Order o3 = new Order() { Address = "Nablus" };
               dbContext.Products.Add(p);
               dbContext.Products.Add(p1);
               dbContext.Products.Add(p2);
               dbContext.Products.Add(p3);
               dbContext.Orders.Add(o);
               dbContext.Orders.Add(o1);
               dbContext.Orders.Add(o2);
               dbContext.Orders.Add(o3);
               dbContext.SaveChanges();
            var product = dbContext.Products.ToList();
            foreach (var item in product)
            {
                Console.WriteLine($"Id=> {item.Id} , Name => {item.Name}, Price => {item.Price} ");
            }
            var order = dbContext.Orders.ToList();
            foreach (var item in order)
            {
                Console.WriteLine($"Id=> {item.Id} , Adress => {item.Address}, Created At => {item.CreatedAt} ");
            }

            var product2 = dbContext.Products.First(p => p.Id == 1);
            product2.Name = "Camera";
            dbContext.SaveChanges();

            var order2 = dbContext.Orders.First(p => p.Id == 2);
            order2.CreatedAt = DateTime.Now;
            dbContext.SaveChanges();
            var productremove = dbContext.Products.First(p => p.Id == 2);
            dbContext.Products.Remove(productremove);
            dbContext.SaveChanges();
            var orderremove = dbContext.Orders.First(p => p.Id == 3);
            dbContext.Orders.Remove(orderremove);
            dbContext.SaveChanges();

        }
    }
}
