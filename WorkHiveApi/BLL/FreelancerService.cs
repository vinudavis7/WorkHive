using BLL.Interface;
using DAL;
using DAL.Repository;
using DAL.Repository.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FreelancerService: IFreelancerService
    {
        private readonly IFreelancerRepository _freelancerRepository;

        public FreelancerService(IFreelancerRepository freelancerRepository)
        {
            _freelancerRepository = freelancerRepository;
        }
  

        public List<Bid> GetFreelancers()
        {
            try
            {
                return null;
                //_freelancerRepository.GetFreelancers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
       

      
        public User GetFreelancerDetails(int userId)
        {
            try
            {
                return null;
                //_freelancerRepository.GetFreelancerDetails(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateFreelancerDetails(User freelancer)
        {
            try
            {
                return false;
                //_freelancerRepository.UpdateFreelancerDetails(freelancer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
