using BLL.Interface;
using DAL;
using DAL.Repository;
using DAL.Repository.Interface;
using Entities;
using Entities.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DashboardService: IDashboardService
    {
        private readonly IJobRepository _jobRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBidRepository _proposalRepository;
        private readonly UserManager<User> _userManager;


        public DashboardService(IJobRepository jobRepository, ICategoryRepository categoryRepository, IBidRepository proposalRepository, IUserRepository userRepository, UserManager<User> userManager)
        {
            _jobRepository = jobRepository;
            _categoryRepository= categoryRepository;
            _proposalRepository = proposalRepository;
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async Task<object> GetDashboardData()
        {
            var data = new object();
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    var recentJobs = _jobRepository.GetRecentJobs(context);
                    var popularCategory = _categoryRepository.GetPopularCategories(context);
                    var freelancers =  _userRepository.GetUsersByRole(context, "Freelancer").Take(3);
                     data = new
                    {
                        PopularCategories = popularCategory,
                        RecentJobs = recentJobs,
                        PopularFreelancers= freelancers
                    };
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IDictionary<string, int>> GetDashboardSummary()
        {
            IDictionary<string, int> summary = new Dictionary<string, int>();

            try
            {
                using (AppDbContext context = new AppDbContext())
                {

                    var jobsCount =  _jobRepository.GetJobCount(context);
                    var FreelancersCount =await _userRepository.GetUserCount(_userManager, "Freelancer");
                    var ClientsCount = await _userRepository.GetUserCount(_userManager, "Client");
                    var ProposalsCount =  _proposalRepository.GetBidCount(context);

                    summary.Add("Freelancers", FreelancersCount);
                    summary.Add("Clients", ClientsCount);
                    summary.Add("Jobs", jobsCount);
                    summary.Add("Proposals", ProposalsCount);
                }
                return summary;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

    }
}
