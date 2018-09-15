using System.Collections.Generic;

namespace GraphQLDotNet.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string BillingAddress { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
