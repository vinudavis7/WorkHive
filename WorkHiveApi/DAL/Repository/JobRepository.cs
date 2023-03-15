using DAL.Repository.Interface;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _dbContext;

        public JobRepository(AppDbContext dbContext)
            {
              _dbContext = dbContext;
            }
       public  List<Job> GetJobs()
        {
            try
            {
                return _dbContext.Jobs.Include(b => b.Category).Include(b => b.Client).ToList();
               // return _dbContext.Jobs.Include("Categories").ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public Job GetJobDetails(int jobId)
        {
            try
            {
                return _dbContext.Jobs.Where(x => x.JobId == jobId).Include(b => b.Category).Include(b => b.Client).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Job CreateJob(Job job)
        {
            try
            {
              var client=  _dbContext.Clients.FirstOrDefault(x => x.UserId == job.ClientId);
                job.Client = client;
                 _dbContext.Jobs.Add( job);
                _dbContext.SaveChanges();
                return job;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Job UpdateJob(Job job)
        {
            try
            {
                var obj = _dbContext.Jobs.FirstOrDefault(x => x.JobId == job.JobId);
                obj.CategoryId = job.CategoryId;
                obj.ClientId = job.ClientId;
                obj.Title = job.Title;
                obj.Location = job.Location;
                obj.Description = job.Description;
                obj.Budget = job.Budget;
                obj.SkillTags = job.SkillTags;
                obj.Deadline = job.Deadline;
                //_dbContext.Jobs.Add(job);
                _dbContext.SaveChanges();
                return job;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
