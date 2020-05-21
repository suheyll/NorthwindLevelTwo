using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Entities.DomainModels
{
   public class CertLine:IDomainModel
    {
        public UserCert Cert { get; set; }
      

    }
}
