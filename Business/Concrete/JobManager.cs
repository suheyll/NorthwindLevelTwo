using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class JobManager:IJobService
    {
        private IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public List<Job> GetAll()
        {
            return _jobDal.GetList();
        }

        public Job GetById(int jobId)
        {
            return _jobDal.Get(j=>j.Id==jobId);
        }

        public void DeleteFromDb(Job job)
        {
            if(job!=null) _jobDal.Delete(job);

        }

        public void UpdateFromDb(Job job)
        {
            if (job != null) _jobDal.Update(job);
        }
    }
}
