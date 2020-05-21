using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class CertManager:ICertService
   {
       private ICertDal _certDal;

       public CertManager(ICertDal certDal)
       {
           _certDal = certDal;
       }

       public List<Cert> GetAll()
       {
           return _certDal.GetList();
       }

        public Cert GetById(int certId)
        {
            return _certDal.Get(c => c.Id == certId);
        }

        public void DeleteFromDb(Cert cert)
        {
            _certDal.Delete(cert);
        }

        public void UpdateFromDb(Cert cert)
        {
            _certDal.Update(cert);
        }
    }
}
