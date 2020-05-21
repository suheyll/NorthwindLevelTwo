using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dtos;

namespace Business.Concrete
{
    public class UserCertManager:IUserCertService
    {
        private IUserCertDal _userCertDal;

        public UserCertManager(IUserCertDal userCertDal)
        {
            _userCertDal = userCertDal;
        }

        public List<UserCert> GetAll(int userId)
        {
            return _userCertDal.GetList(uc => uc.UserId == userId);
        }

        public void AddUserCert(UserCert userCert)
        {
            _userCertDal.Add(userCert);
        }

        public void DeleteFromDb(UserCert userCert)
        {
            _userCertDal.Delete(userCert);
        }

        public void UpdateFromDb(UserCert userCert)
        {
            _userCertDal.Update(userCert);
        }
    }
}
