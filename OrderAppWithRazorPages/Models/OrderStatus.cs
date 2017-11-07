using System.ComponentModel;

namespace OrderApp.Models
{
    public enum OrderStatus
    {
        [Description("Ordered")]
        Ordered,

        [Description("Filled")]
        Filled,

        [Description("Shipped")]
        Shipped,

        [Description("Out for Delivery")]
        OutForDelivery,

        [Description("Delivered")]
        Delivered
    }
}