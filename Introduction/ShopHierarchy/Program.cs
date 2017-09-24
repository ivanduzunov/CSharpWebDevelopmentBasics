using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Microsoft.EntityFrameworkCore;

namespace ShopHierarchy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ShopDBContext context = new ShopDBContext();
            ClearDatabase(context);

            using (context)
            {
                RegisterSalaesman(context);

                while (true)
                {
                    var input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    var elements = input.Split(';');

                    RegisterItem(context, elements);
                }

                while (true)
                {
                    var input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    var elements = input.Split('-');

                    switch (elements[0])
                    {
                        case "register":
                            RegisterCustomer(context, elements);
                            break;

                        case "order":
                            RegisterOrder(context, elements);
                            break;

                        case "review":
                            RegisterReview(context, elements);
                            break;
                    }

                }



                //var customerId = int.Parse(Console.ReadLine());
                //var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);
                //var orders = customer.Orders;
                //var reviews = customer.Reviews.Count;
                //foreach (var order  in orders)
                //{
                //    Console.WriteLine($"order {order.Id}: {order.Items.Count} items");
                //}
                //Console.WriteLine($"reviews: {reviews}");

                //var custs = context.Customers
                //    .Include(c => c.Reviews)
                //    .Include(c => c.Orders)
                //    .OrderByDescending(x => x.Orders.Count)
                //    .ThenByDescending(x => x.Reviews.Count);
                //foreach (var customer in custs)
                //{
                //    Console.WriteLine($"{customer.Name}");
                //    Console.WriteLine($"Orders: {customer.Orders.Count}");
                //    Console.WriteLine($"Reviews: {customer.Reviews.Count}");
                //}
            }
        }

        private static void RegisterItem(ShopDBContext context, string[] elements)
        {
            context.Items
                .Add(new Item
                {
                    Name = elements[0],
                    Price = double.Parse(elements[1])
                });

            context.SaveChanges();
        }

        private static void RegisterReview(ShopDBContext context, string[] elements)
        {
            var arguments = elements[1].Split(';').Select(int.Parse).ToArray();

            int custId = arguments[0];

            Review review = new Review
            {
                CustomerId = custId,
                ItemId = arguments[1]
            };

            context.Reviews.Add(review);
            context.SaveChanges();
        }

        private static void RegisterOrder(ShopDBContext context, string[] elements)
        {
            var arguments = elements[1].Split(';').Select(int.Parse).ToArray();
            int custId = arguments[0];

            var order = new Order { CustomerId = custId };

            for (int i = 1; i < arguments.Length; i++)
            {
                int currId = arguments[i];
                order.Items.Add(new OrdersItems
                {
                    ItemId = currId
                });
            }

            context.Orders.Add(order);

            context.SaveChanges();
        }

        private static void RegisterCustomer(ShopDBContext context, string[] elements)
        {
            var custSalesmanPair = elements[1].Split(';');

            context.Salespeople
                .Where(s => s.Id == int.Parse(custSalesmanPair[1]))
                .FirstOrDefault()
                .Customers.Add(new Customer { Name = custSalesmanPair[0] });
            context.SaveChanges();
        }

        private static void RegisterSalaesman(ShopDBContext context)
        {
            var salesmanNames = Console.ReadLine().Split(';').ToArray();

            foreach (var name in salesmanNames)
            {
                context.Salespeople.Add(new Salesman { Name = name });
                context.SaveChanges();
            }
        }

        public static void ClearDatabase(ShopDBContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Console.WriteLine("Database cleared!");
        }
    }
}

