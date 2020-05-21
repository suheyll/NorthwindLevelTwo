using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Cert:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Data { get; set; }
        public string Questions { get; set; }
        public string Link { get; set; }

    }
}
