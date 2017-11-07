using System.Collections.Generic;
using OrderApp.Models;

namespace OrderApp.Services
{
    public interface IOrdersService
    {
        Order GetOrder();
        List<(Product product, int quantity)> GetOrderDetails(int OrderId);
        decimal GetOrderTotal(int OrderId);
        (string Message, int Step) GetShippingStatus(int OrderId);
    }
}