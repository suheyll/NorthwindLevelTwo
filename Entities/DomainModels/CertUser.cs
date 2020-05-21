using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.DomainModels
{
   public class CertUser:IDomainModel
    {
        public CertUser()
        {
            CertLines = new List<CertLine>();
        }
        public List<CertLine> CertLines { get; set; }

    }
}
