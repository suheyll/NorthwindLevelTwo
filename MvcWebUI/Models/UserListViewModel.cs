using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace MvcWebUI.Models
{
    public class UserListViewModel
    {
        public List<User> Users { get; set; }
        public User User { get; set; }
        
    }
}
