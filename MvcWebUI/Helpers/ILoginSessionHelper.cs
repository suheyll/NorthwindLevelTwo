using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DomainModels;

namespace MvcWebUI.Helpers
{
    public interface ILoginSessionHelper
    {
        UserDomainModel GetUser(string key);
        void SetUser(string key, UserDomainModel user);
        void Clear();
    }
}
