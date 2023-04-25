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
                var list = _dbContext.Jobs.ToList();

                if (!string.IsNullOrEmpty(searchParams.SearchCategory) && searchParams.SearchCategory != "All")
                {
                    List<Category> categoryList = _dbContext.Categories.Include(x => x.Jobs).Where(x => x.CategoryName.ToLower().Contains(searchParams.SearchCategory.ToLower())).ToList();
                    if (categoryList.Count == 1)
                        list = categoryList[0].Jobs.ToList();
                }

                if (!string.IsNullOrEmpty(searchParams.SearchTitle))
                {
                    list = list.Where(x => x.Title.ToLower().Contains(searchParams.SearchTitle.ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(searchParams.SearchLocation))
                {
                    list = list.Where(x => x.Location.ToLower().Contains(searchParams.SearchLocation.ToLower())).ToList();
                }
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Job GetJobDetails(AppDbContext _dbContext, int jobId)
        {
            try
            {
                return _dbContext.Jobs.Where(x => x.JobId == jobId).Include(job=>job.Bids).FirstOrDefault();
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
        public List<Job> GetRecentJobs(AppDbContext _dbContext)
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
        public Job UpdateJob(AppDbContext _dbContext, UpdateJobRequest job)
        {
            try
            {
                var obj = _dbContext.Jobs.FirstOrDefault(x => x.JobId == job.JobId);
                obj.Title = job.Title;
                obj.Location = job.Location;
                obj.Description = job.Description;
                obj.Budget = job.Budget;
                obj.SkillTags = job.SkillTags;
                obj.Deadline = job.Deadline;
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteJob(AppDbContext context, Job job)
        {
            try
            {
                var obj = context.Jobs.Remove(job);
                return true;
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
        public void RemoveBidFromCollection(AppDbContext context, Job job)
        {
            for (int i = job.Bids.Count - 1; i >= 0; i--)
            {
                var bid = job.Bids.ElementAt(i);
                job.Bids.Remove(bid);
            }
        }
    }
}
