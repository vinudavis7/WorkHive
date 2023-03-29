using DAL.Repository.Interface;
using Entities;
using Entities.ViewModel;
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


        public List<Job> GetJobs(AppDbContext _dbContext, JobSearchViewModel searchParams)
        {
            try
            {
                var list = _dbContext.Jobs.AsQueryable();
                if (!string.IsNullOrEmpty(searchParams.SearchTitle))
                {
                    list = list.Where(x => x.Title.Contains(searchParams.SearchTitle));
                }
                if (!string.IsNullOrEmpty(searchParams.SearchJobType))
                {
                    list = list.Where(x => x.JobType.Contains(searchParams.SearchJobType));
                }
                if (!string.IsNullOrEmpty(searchParams.SearchLocation))
                {
                    list = list.Where(x => x.Location.Contains(searchParams.SearchLocation));
                }
                //if (searchParams.ClientID > 0)
                //{
                //    list = list.Where(x => x.ClientId == searchParams.ClientID);
                //}

                return list.ToList();
                    //.Include(b => b.Category).Include(b => b.Client).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Job GetJobDetails(AppDbContext _dbContext,int jobId)
        {
            try
            {
                return _dbContext.Jobs.Where(x => x.JobId == jobId).FirstOrDefault();

                //return _dbContext.Jobs.Where(x => x.JobId == jobId).Include(b => b.Category).Include(b => b.Client).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetJobCount(AppDbContext _dbContext)
        {
            try
            {
                var count = _dbContext.Jobs.Count();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public  List<Job> GetRecentJobs(AppDbContext _dbContext)
        {
            try
            {
                var recentJobs = _dbContext.Jobs.OrderByDescending(p => p.DatePosted).Take(5).ToList();
                return recentJobs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Job CreateJob(AppDbContext _dbContext, Job job)
        {
            try
            {
                _dbContext.Jobs.Add(job);
                return job;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Job UpdateJob(AppDbContext _dbContext, Job job)
        {
            try
            {
                var obj = _dbContext.Jobs.FirstOrDefault(x => x.JobId == job.JobId);
               // obj.CategoryId = job.CategoryId;
               // obj.ClientId = job.ClientId;
                obj.Title = job.Title;
                obj.Location = job.Location;
                obj.Description = job.Description;
                obj.Budget = job.Budget;
                obj.SkillTags = job.SkillTags;
                obj.Deadline = job.Deadline;
                //_dbContext.Jobs.Add(job);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddBidToCollection(AppDbContext context, Bid bid, Job job)
        {
            job.Bids.Add(bid);
        }

    }
}
