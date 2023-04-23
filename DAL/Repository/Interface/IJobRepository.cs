using Entities;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public  interface IJobRepository
    {
        public List<Job> GetJobs(AppDbContext context ,JobSearchViewModel searchParams);
        public Job GetJobDetails(AppDbContext context ,int jobId);
        public int GetJobCount(AppDbContext context);
        public Job CreateJob(AppDbContext context , Job job);
        public Job UpdateJob(AppDbContext context , UpdateJobRequest job);
        public List<Job> GetRecentJobs(AppDbContext context);
        public void AddBidToCollection(AppDbContext context, Bid bid, Job job);

    }
}
