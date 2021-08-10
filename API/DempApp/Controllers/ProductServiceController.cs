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
    public class ProductServiceController : DemoAppControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductServiceController(IProductsService productsService,
            ILogger<ProductServiceController> logger
            ) : base(logger)
        {
            _productsService = productsService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProductType")]
        //[HasPermission(ProcessName = "ADMIN", SubProcessName = "CREATE")]
        public async Task<IActionResult> AddProductType(AddProductTypeRequest request)
        {
            string user = User.Identity.Name;
            try
            {
                var result = await _productsService.AddProductType(request, user);
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
        [Route("GetProductType")]
        //[HasPermission(ProcessName = "ADMIN", SubProcessName = "CREATE")]
        public async Task<IActionResult> GetProductType(string searchField)
        {
            string user = User.Identity.Name;
            try
            {
                var result = await _productsService.GetProductType(searchField, user);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return HandleUserException(ex);
            }
        }

    }
}
