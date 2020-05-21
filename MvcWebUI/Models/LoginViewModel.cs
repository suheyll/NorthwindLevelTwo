using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class LoginViewModel
    {
        public string Name { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
