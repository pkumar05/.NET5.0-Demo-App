using DA.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.ServicesInterfaces
{
   public interface ICustomerService
    {
        Task<ServiceResponse> AddCustomer(AddCustomerRequest request, string createdBy);
        Task<ServiceResponse> GetCutomerData(string searchField, string userName);
        Task<ServiceResponse> UpdateCustomer();
        Task<ServiceResponse> AddCustomerOrders();
        Task<ServiceResponse> GetCustomerOrders();
    }
}
