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

namespace BLL
{
    public class JobService : IJobService
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

        public bool SendNotifications()
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {

                    var jobs = _jobRepository.GetRecentJobs(context);
                    string html = "";
                    if (jobs.Count > 0)
                    {
                        foreach (Job item in jobs.AsEnumerable())
                        {

                            string jobTitle = item.Title;
                            html += "<a href='#'>" + jobTitle + "</a><br>";
                        }
                        string emailBody = "Dear User. New job/s have been posted in WorkHive<br><br>";
                        emailBody = emailBody + html;
                        List<string> users = new List<string>();
                        users.Add("vinudavis8@gmail.com");
                        SendEmail(emailBody, users);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SendEmail(string htmlString, List<string> users)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("notificationsworkhive@gmail.com");
                message.Subject = "New Job Notification";
                message.IsBodyHtml = true; //to make message body as html
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("notificationsworkhive@gmail.com", "xraypifjhdxqbwvy");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                foreach (var email in users)
                {
                    message.To.Add(new MailAddress(email));
                    smtp.Send(message);
                }

            }
            catch (Exception ex)
            {
            }
        }
    }
}
