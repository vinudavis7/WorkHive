using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public  interface IJobService
    {
    public List<Job> GetJobs();
        public Job GetJobDetails(int jobId);
        public Job CreateJob(Job job);
        public Job UpdateJob(Job job);
    }
}
