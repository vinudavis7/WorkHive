using Entities;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public  interface IDashboardService
    {
    public Task<object> GetDashboardData();
    public Task<IDictionary<string, int>> GetDashboardSummary();

    }
}
