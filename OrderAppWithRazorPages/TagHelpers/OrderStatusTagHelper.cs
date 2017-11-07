using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Razor.TagHelpers;
using OrderApp.Extensions;
using OrderApp.Models;

namespace OrderApp.TagHelpers
{
    public class OrderStatusTagHelper : TagHelper
    {
        public OrderStatus Status { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            foreach(OrderStatus value in Enum.GetValues(typeof(OrderStatus)))
            {
                output.Content.AppendHtml($@"<div class=""col-md-2 {GetOrderStatusClass(value)}"">
    <span class=""fa glyphicon glyphicon-{GetOrderStatusIcon(value)}""></span>
    <p>{value.GetAttribute<DescriptionAttribute>().Description}</p>
</div>");
            }
        }

        private string GetOrderStatusClass(OrderStatus status)
        {
            if (this.Status > status)
            {
                return "complete";
            }
            else if (this.Status == status)
            {
                return "active";
            }

            return string.Empty;
        }

        private string GetOrderStatusIcon(OrderStatus status)
        {
            var icon = string.Empty;
            switch (status)
            {
                case OrderStatus.Ordered:
                    icon = "shopping-cart";
                    break;
                case OrderStatus.Filled:
                    icon = "check";
                    break;
                case OrderStatus.Shipped:
                    icon = "plane";
                    break;
                case OrderStatus.OutForDelivery:
                    icon = "road";
                    break;
                case OrderStatus.Delivered:
                    icon = "home";
                    break;
            }

            return icon;
        }
    }
}
