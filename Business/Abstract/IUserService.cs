using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IUserService
    {
        List<User> GetAll();
        User GetByUsername(string userName);

        bool IsloginSuccess(string userName, string password);

        void AddUser(User user);
    }
}
