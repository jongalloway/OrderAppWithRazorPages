using System;
using System.Collections.Generic;
using OrderApp.Models;

namespace OrderApp.Services
{
    public class OrdersService : IOrdersService
    {
        public OrdersService()
        {
        }

        public Order GetOrder() => new Order
        {
            Name = "Jon Galloway",
            Address = "123 Main Street, Denver, CO",
            Phone = "(555) 867-5309",
            Date = DateTime.Now.AddDays(-20)
        };

        public List<(Product product, int quantity)> GetOrderDetails(int OrderId) =>
            new List<(Product product, int quantity)>
        {
            (new Product{ ProductId = 1, Name = "Gummi Bears", Price = 100.00M }, 5),
            (new Product{ ProductId = 2, Name = "Ramen", Price = 10.00M }, 50),
            (new Product{ ProductId = 3, Name = "Xbox One", Price = 500.00M }, 1),
            (new Product{ ProductId = 4, Name = "Mysterious Device", Price = 10000.00M }, 1),
            (new Product{ ProductId = 5, Name = "Party Hats", Price = 1.00M }, 5000)
        };

        public decimal GetOrderTotal(int OrderId)
        {
            var od = GetOrderDetails(OrderId);
            decimal total = 0.00M;
            od.ForEach(o => total += o.quantity * o.product.Price);

            return total;
        }

        public (string Message, int Step) GetShippingStatus(int OrderId) =>
            ("Out for delivery", 3);
    }
}