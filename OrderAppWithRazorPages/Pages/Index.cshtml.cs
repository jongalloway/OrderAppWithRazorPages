using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderApp.Models;
using OrderApp.Services;

namespace OrderApp.Pages
{
    public class IndexModel : PageModel
    {
        public Order Order;
        public List<(Product product, int quantity)> OrderDetails;
        public int ShippingPercent { get; private set; }
        public decimal Total { get; private set; }
        public (string Message, int Step) ShippingStatus { get; private set; }

        private IOrdersService _ordersService;

        public IndexModel(IOrdersService ordersService)
        {
            _ordersService = ordersService; 
        }

        public void OnGet()
        {
            Order = _ordersService.GetOrder();
            OrderDetails = _ordersService.GetOrderDetails(Order.OrderId);
            ShippingStatus = _ordersService.GetShippingStatus(Order.OrderId);
            ShippingPercent = (ShippingStatus.Step * 20) + 20; 
            Total = _ordersService.GetOrderTotal(Order.OrderId);
        }

        public string GetShippingStepClass(int Step)
        {
            if (ShippingStatus.Step > Step)
            {
                return "complete";
            }
            else if (ShippingStatus.Step == Step)
            {
                return "active";
            }
            return string.Empty;
        }
    }
}
