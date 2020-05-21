using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IJobService
    {
        List<Job> GetAll();
        Job GetById(int jobId);
        void DeleteFromDb(Job job);
        void UpdateFromDb(Job job);
    }
}
