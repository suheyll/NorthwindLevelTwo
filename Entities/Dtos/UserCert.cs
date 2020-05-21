using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class UserCert:IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CertId { get; set; }

    }
}
