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
        private readonly IFreelancerRepository _freelancerRepository;
        private readonly IBidRepository _proposalRepository;
        private readonly UserManager<User> _userManager;


        public DashboardService(IJobRepository jobRepository, ICategoryRepository categoryRepository,IFreelancerRepository freelancerRepository, IBidRepository proposalRepository, IUserRepository userRepository, UserManager<User> userManager)
        {
            _jobRepository = jobRepository;
            _categoryRepository= categoryRepository;
            _freelancerRepository = freelancerRepository;
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
                    var freelancers =  _userRepository.GetUsersByRole(context, "Freelancer");

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


        public IDictionary<string, int> GetDashboardSummary()
        {
            try
            {
                //var jobsCount = _jobRepository.GetJobCount();
                //var FreelancersCount = _userRepository.GetUserCount("Freelancer");
                //var ClientsCount = _userRepository.GetUserCount("Client");
                //var ProposalsCount = _proposalRepository.GetProposalCount();

                //IDictionary<string, int> summary = new Dictionary<string, int>();
                //summary.Add("Freelancers", FreelancersCount);
                //summary.Add("Clients", ClientsCount);
                //summary.Add("Jobs", jobsCount);
                //summary.Add("Proposals", ProposalsCount);
               
                return null;
                //summary;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

    }
}
