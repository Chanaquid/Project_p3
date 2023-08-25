using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string Username{get; set;}
        public string PasswordHash{get; set;}
        public string Email{get; set;}
        public string FullName {get; set;}
        public bool IsAdmin{get; set;} = false;
        public ICollection<Order> Orders{get; set;}
    }
    
}