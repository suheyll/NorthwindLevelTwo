using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DomainModels
{
  public  class UserDomainModel:IDomainModel

  {
      public UserDomainModel()
      {
          User = new User();
      }
      public User User { get; set; }
     
    }
}
