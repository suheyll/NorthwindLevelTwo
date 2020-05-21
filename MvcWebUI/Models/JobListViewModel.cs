using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace MvcWebUI.Models
{
    public class JobListViewModel
    {
        public List<Job> Jobs { get; set; }
        public Job Job { get; set; }
    }
}
