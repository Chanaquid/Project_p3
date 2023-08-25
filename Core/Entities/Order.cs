using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate {get; set;}
        public int UserId {get; set;}
        public User User {get ;set;}
        public ICollection<OrderItem> OrderItems {get; set;}
    }
}