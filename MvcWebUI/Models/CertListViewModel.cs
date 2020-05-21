using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace MvcWebUI.Models
{
    public class CertListViewModel
    {
        public List<Cert> Certs { get; set; }
        public Cert Cert { get; set; }
    }
}
