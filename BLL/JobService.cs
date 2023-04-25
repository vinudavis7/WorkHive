using BLL.Interface;
using DAL;
using DAL.Repository;
using DAL.Repository.Interface;
using Entities;
using Entities.ViewModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IConfiguration _configuration;

        public JobService(IJobRepository jobRepository, IUserRepository userRepository, ICategoryRepository categoryRepository, IConfiguration configuration)
        {
            _jobRepository = jobRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _configuration = configuration;

        }
        public List<Job> GetJobs(JobSearchViewModel searchParams)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return _jobRepository.GetJobs(context, searchParams);
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
                    return _jobRepository.GetJobDetails(context, jobId);
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
        public List<Job> GetRecentJobs()
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return _jobRepository.GetRecentJobs(context);
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
        public Job UpdateJob(UpdateJobRequest job)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    var result = _jobRepository.UpdateJob(context, job);
                    context.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteJob(int jobId)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    //fetch the job to be deleted
                    var job = _jobRepository.GetJobDetails(context, jobId);
                    //removing all bids associated with this job
                    _jobRepository.RemoveBidFromCollection(context, job);
                    var result = _jobRepository.DeleteJob(context, job);
                    context.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SendNotifications()
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    //get all jobs posted on the current day
                    var jobs = _jobRepository.GetRecentJobs(context);
                    string html = "";
                    if (jobs.Count > 0)
                    {
                        //create links  to jobs page using job title and jobID
                        foreach (Job item in jobs.AsEnumerable())
                        {
                            string jobTitle = item.Title;
                            string url = _configuration.GetValue<string>("webAppBaseURL").ToString() + "/Jobs/JobDetails?jobId=" + item.JobId;
                            html += "<a href='"+ url + "'>" + jobTitle + "</a><br>";
                        }
                        string emailBody =_configuration.GetValue<string>("notificationEmailTemplate");
                        emailBody = emailBody + html;
                        string subject= "New Job Notification";
                        List<string> users = new List<string>();
                        //fetch all users who enabled job notifications
                        var userList = _userRepository.GetUsersByRole(context, "Freelancer");
                        foreach (User user in userList)
                        {
                            if (user.Profile.ReceiveJobNotifications)
                            {
                                users.Add(user.Email);
                            }
                        }
                        Helper helper = new Helper(_configuration);
                        helper.SendEmail(emailBody, subject, users);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
    }
}
