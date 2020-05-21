using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
  public  interface ICertService
    {

        List<Cert> GetAll();
        Cert GetById(int certId);
        void DeleteFromDb(Cert cert);
        void UpdateFromDb(Cert cert);
    }
}
