using Entities;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public  interface IJobService
    {
    public List<Job> GetJobs(JobSearchViewModel searchParams);
        public Job GetJobDetails(int jobId);
        public Job CreateJob(JobRequest job);
        public Job UpdateJob(JobRequest job);
        public int GetJobCount();

        public List<Job> GetRecentJobs();
    }
}
