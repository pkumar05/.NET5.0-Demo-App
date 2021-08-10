using DA.Domain.DTO;
using DA.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DempApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]  // Remove this later as it need to be authorize
    public class CustomerServiceController : DemoAppControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerServiceController(ICustomerService customerService,
            ILogger<CustomerServiceController> logger
            ) : base(logger)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCustomer")]
        //[HasPermission(ProcessName = "ADMIN", SubProcessName = "CREATE")]
        public async Task<IActionResult> AddCustomer(AddCustomerRequest request)
        {
            string user = User.Identity.Name;
            try
            {
                var result = await _customerService.AddCustomer(request, user);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return HandleUserException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchField"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCustomerData")]
        //[HasPermission(ProcessName = "ADMIN", SubProcessName = "CREATE")]
        public async Task<IActionResult> GetCustomerData(string searchField)
        {
            string user = User.Identity.Name;
            try
            {
                var result = await _customerService.GetCutomerData(searchField, user);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return HandleUserException(ex);
            }
        }

    }
}
