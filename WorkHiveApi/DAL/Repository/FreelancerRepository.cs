using DAL.Repository.Interface;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class FreelancerRepository : IFreelancerRepository
    {
    //    private readonly AppDbContext _dbContext;

    //    public FreelancerRepository(AppDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }
    //    public List<Freelancer> GetFreelancers()
    //    {
    //        try
    //        {
    //            var freelancers = (from user in _dbContext.Users
    //                               join freelancer in _dbContext.Freelancers
    //                               on user.UserId equals freelancer.UserId
    //                               select new Freelancer
    //                               {
    //                                   Id=freelancer.Id,
    //                                  // Name = user.Name,
    //                                   Designation = freelancer.Designation,
    //                                  // Email = user.Email,
    //                                   Skills = freelancer.Skills,
    //                                  // ProfileImage = user.ProfileImage,
    //                                   //Phone = user.Phone,
    //                                  // Location = user.Location,
    //                                   Experience = user.Location,
    //                                   HourlyRate = freelancer.HourlyRate,
    //                                   UserDetails=user

    //                               }).ToList();
    //            return freelancers;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }

    //    public IEnumerable<Freelancer> GetPopularFreelancers()
    //    {
    //        try
    //        {
    //            var freelancers = (from user in _dbContext.Users
    //                               join freelancer in _dbContext.Freelancers
    //                               on user.UserId equals freelancer.UserId
    //                               select new Freelancer
    //                               {
    //                                   Id = freelancer.Id,
    //                                   //Name = user.Name,
    //                                   Designation = freelancer.Designation,
    //                                   //Email = user.Email,
    //                                   Skills = freelancer.Skills,
    //                                   //ProfileImage = user.ProfileImage,
    //                                   //Phone = user.Phone,
    //                                   //Location = user.Location,
    //                                   Experience = user.Location,
    //                                   HourlyRate = freelancer.HourlyRate,
    //                                   UserDetails = user

    //                               }).Take(3).ToList();
    //            return freelancers;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }

    //    public Freelancer GetFreelancerDetails(int userId)
    //    {
    //        try
    //        {

    //            var details = _dbContext.Freelancers
    //.Join(_dbContext.Users,
    //   f => f.UserId,
    //   u => u.UserId,
    //    (f, u) => new { freelancer = f, user = u }
    // )
    // .Where(x => x.user.UserId == userId)
    //  .Select(cp => new Freelancer
    //  {
    //      UserId = cp.freelancer.UserId,
    //      Description = cp.freelancer.Description,
    //      Designation = cp.freelancer.Designation,
    //     // Email = cp.freelancer.Email,
    //      Experience = cp.freelancer.Experience,
    //      HourlyRate = cp.freelancer.HourlyRate,
    //     // Location = cp.freelancer.Location,
    //     // Name = cp.freelancer.Name,
    //     // Password = cp.freelancer.Password,
    //      //Phone = cp.freelancer.Phone,
    //     // ProfileImage = cp.freelancer.ProfileImage,
    //      //UserType=cp.user.UserType,
    //      Skills = cp.freelancer.Skills,
    //      UserDetails=cp.user
    //  }).SingleOrDefault();

    //            return details;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }

       
    //    public bool UpdateFreelancerDetails(Freelancer freelancer)
    //    {
    //        try
    //        {
    //            var user = _dbContext.Users.Where(x => x.UserId == freelancer.UserDetails.UserId).FirstOrDefault();
    //            user.Phone = freelancer.UserDetails.Phone;
    //            user.Location = freelancer.UserDetails.Email;
    //            user.Email = freelancer.UserDetails.Email;
    //            user.Name = freelancer.UserDetails.Name;
    //            user.Password = freelancer.UserDetails.Password;
    //            user.ProfileImage = freelancer.UserDetails.ProfileImage;

    //            var freelancerDetails = _dbContext.Freelancers.Where(x => x.UserId == freelancer.UserDetails.UserId).FirstOrDefault();
    //            freelancerDetails.Description = freelancer.Description;
    //            freelancerDetails.Designation = freelancer.Designation;
    //            freelancerDetails.HourlyRate = freelancer.HourlyRate;
    //            freelancerDetails.Experience = freelancer.Experience;
    //            freelancerDetails.Skills = freelancer.Skills;


    //            _dbContext.SaveChanges();
    //            return true;
    //        }

    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }

    }
}
