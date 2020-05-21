using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DomainModels;
using Microsoft.AspNetCore.Http;
using MvcWebUI.Extensions;

namespace MvcWebUI.Helpers
{
    public class LoginSessionHelper:ILoginSessionHelper
    {
        private IHttpContextAccessor _httpContextAccessor;

        public LoginSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserDomainModel GetUser(string key)
        {
            UserDomainModel userToCheck = _httpContextAccessor.HttpContext.Session.GetObject<UserDomainModel>(key);
            if (userToCheck == null)
            {
                SetUser(key, new UserDomainModel());
                userToCheck = _httpContextAccessor.HttpContext.Session.GetObject<UserDomainModel>(key);
            }

            return userToCheck;
        }

    

        public void SetUser(string key, UserDomainModel user)
        {
            _httpContextAccessor.HttpContext.Session.SetObject(key, user);
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }
    }
}
