using System;
using System.Collections.Generic;
using System.Text;
using Entities.Dtos;

namespace Business.Abstract
{
   public interface IUserCertService
   {
       List<UserCert> GetAll(int userId);
       void AddUserCert(UserCert userCert);
        void DeleteFromDb(UserCert userCert);
        void UpdateFromDb(UserCert userCert);
    }
}
