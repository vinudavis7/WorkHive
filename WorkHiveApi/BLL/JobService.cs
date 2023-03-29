using BLL.Interface;
using DAL;
using DAL.Repository;
using DAL.Repository.Interface;
using Entities;
using Entities.ViewModel;
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
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        public JobService(IJobRepository jobRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _jobRepository = jobRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }
        public List<Job> GetJobs(JobSearchViewModel searchParams)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                  return  _jobRepository.GetJobs(context,searchParams);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Job GetJobDetails(int jobId)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return _jobRepository.GetJobDetails(context,jobId);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetJobCount()
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return _jobRepository.GetJobCount(context);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public  List<Job> GetRecentJobs()
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return  _jobRepository.GetRecentJobs(context);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Job CreateJob(JobRequest job)
        {
            try
            {
                Job obj = new Job
                {
                    Title = job.Title,
                    DatePosted = job.DatePosted,
                    Budget = job.Budget,
                    Deadline = job.Deadline,
                    Description = job.Description,
                    JobType = job.JobType,
                    Location = job.Location,
                    SkillTags = job.SkillTags,
                };
                using (AppDbContext context = new AppDbContext())
                {
                    User user = _userRepository.GetUserDetails(context, job.UserId);
                    Category category = _categoryRepository.GetCategoryDetails(context, job.CategoryId);
                    _jobRepository.CreateJob(context, obj);
                    _userRepository.AddJobToCollection(context, obj, user);
                    _categoryRepository.AddJobToCollection(context, obj, category);
                    context.SaveChanges();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Job UpdateJob(JobRequest job)
        {
            try
            {
                Job obj = new Job
                {
                    Title = job.Title,
                    DatePosted = job.DatePosted,
                    Budget = job.Budget,
                    Deadline = job.Deadline,
                    Description = job.Description,
                    JobType = job.JobType,
                    Location = job.Location,
                    SkillTags = job.SkillTags,
                };
                using (AppDbContext context = new AppDbContext())
                {
                    _jobRepository.UpdateJob(context, obj);
                    context.SaveChanges();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
