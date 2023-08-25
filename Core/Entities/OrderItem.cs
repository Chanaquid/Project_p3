using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class OrderItem : BaseEntity
    {
        public int ProductId {get; set;}
        public Product Product {get; set;}
        public int Quantity {get; set;}
        public decimal TotalPrice {get; set;}
        public int OrderId {get; set;}
        public Order Order {get; set;}
    }
}