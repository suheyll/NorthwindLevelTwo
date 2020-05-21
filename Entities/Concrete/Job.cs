using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Job:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Condition { get; set; }
        public string Term { get; set; }    
        public string Cert { get; set; }

    }
}
