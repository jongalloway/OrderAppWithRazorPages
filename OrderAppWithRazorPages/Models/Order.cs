using System;

namespace OrderApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
        public string Language { get; set; }
        public string Phone { get; set; }
    }
}
