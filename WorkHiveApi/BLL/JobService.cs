using BLL.Interface;
using DAL;
using DAL.Repository;
using DAL.Repository.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class JobService:IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public List<Jobs> GetJobs()
        {
            try
            {
                return _jobRepository.GetJobs();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Jobs GetJobDetails(int jobId)
        {
            try
            {
                return _jobRepository.GetJobDetails(jobId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
