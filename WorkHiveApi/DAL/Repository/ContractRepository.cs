using DAL.Repository.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ContractRepository : IContractRepository
    {
        private readonly AppDbContext _dbContext;

        public ContractRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Contracts> GetContracts()
        {
            try
            {
                return _dbContext.Contracts.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
