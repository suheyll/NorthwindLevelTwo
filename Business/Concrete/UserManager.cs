using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public List<User> GetAll()
        {
            return _userDal.GetList();
        }

        public User GetByUsername(string userName)
        {
            return _userDal.Get(p => p.UserName == userName);
        }

        public bool IsloginSuccess(string userName, string password)
        {
            User user = _userDal.Get(u => u.UserName.Equals(userName) && u.Password.Equals(password));
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }

           
        }

        public void AddUser(User user)
        {
           _userDal.Add(user);
        }
    }
}
