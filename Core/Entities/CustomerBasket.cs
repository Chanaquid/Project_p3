using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CustomerBasket
    {

        public CustomerBasket()
        {

        }

        public CustomerBasket(string id)
        {
            Id = id;
        }

        public CustomerBasket(string id, List<BasketItem> items)
        {
            Id = id;
            Items = items;
        }
        public string Id {get; set;}
        public List<BasketItem> Items {get; set;} = new List<BasketItem>();
    }
}