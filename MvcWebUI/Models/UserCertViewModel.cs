using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DomainModels;
using Entities.Dtos;

namespace MvcWebUI.Models
{
    public class UserCertViewModel
    {
        public  List<UserCert>  UserCerts{ get; set; }
        public  User User { get; set; }

        public List<Cert> Certs { get; set; }
    }
}
