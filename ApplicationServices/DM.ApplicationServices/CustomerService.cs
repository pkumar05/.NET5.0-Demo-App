using AutoMapper;
using DA.Domain.DTO;
using DA.Domain.Entities;
using DA.Domain.Interfaces;
using DA.ServicesInterfaces;
using DM.ApplicationServices.Helper;
using PK.BuildingBlocks.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DM.ApplicationServices
{
    public class CustomerService : ICustomerService
    {
        readonly ICustomersRequestRepos _customersRequestRepos;
        readonly ICustomerOrdersRequestRepos _customerOrdersRequestRepos;
        readonly IOrdersRequestRepos _ordersRequestRepos;
        readonly IProductsRequestRepos _productsRequestRepos;
        readonly IProductTypeRequestRepos _productTypeRequestRepos;
        //readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;




        public CustomerService(
         ICustomersRequestRepos customersRequestRepos,
         ICustomerOrdersRequestRepos customerOrdersRequestRepos,
         IOrdersRequestRepos ordersRequestRepos,
         IProductsRequestRepos productsRequestRepos,
         IProductTypeRequestRepos productTypeRequestRepos,
         //   IMapper mapper,
         IUnitOfWork unitOfWork
            )
        {
            _customersRequestRepos = customersRequestRepos;
            _customerOrdersRequestRepos = customerOrdersRequestRepos;
            _ordersRequestRepos = ordersRequestRepos;
            _productsRequestRepos = productsRequestRepos;
            _productTypeRequestRepos = productTypeRequestRepos;
            //  _mapper = mapper;
            _unitOfWork = unitOfWork;
            // _response = response;

        }

        readonly ServiceResponse _response = new ServiceResponse();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> AddCustomer(AddCustomerRequest request, string createdBy)
        {

            if (string.IsNullOrEmpty(createdBy))
                createdBy = CommonConstants.SYSTEM;

            var customerExist = _customersRequestRepos.Get(x => x.Active && x.FullName == request.FullName);
            if (customerExist == null)
            {
                var customer = new Customers
                {
                    Id = Guid.NewGuid().ToString(),
                    FullName = request.FullName.TitleCase(),
                    Address = request.Address,
                    Phone = request.Phone.ToUpper(),
                    Email = request.Email.ToLower(),
                    Description = request.Description,
                    IsGoldMember = request.IsGoldMember,
                    IsDiamondMember = request.IsDiamondMember,
                    Active = true,
                    CreatedBy = createdBy,
                    CreatedDate = DateTime.Now,

                };
                _customersRequestRepos.Add(customer);

                await _unitOfWork.CommitAsync();
                _response.msg = CommonConstants.RecordAddedSuccessfully;
                _response.success = true;
            }
            else
            {
                _response.success = false;
                _response.msg = CommonConstants.AlreadyExist;
            }



            return await Task.Run(() => _response);
        }

        public async Task<ServiceResponse> AddCustomerOrders()
        {
            return await Task.Run(() => _response);
        }

        public async Task<ServiceResponse> GetCustomerOrders()
        {
            return await Task.Run(() => _response);
        }

        /// <summary>
        /// Method added to get the customer data /list
        /// </summary>
        /// <param name="searchField"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> GetCutomerData(string searchField, string userName)
        {
            // var customerRecord = _customersRequestRepos.GetAll(x => x.Active && x.FullName.Contains(searchField) || x.Phone.Contains(searchField)).ToList().OrderBy(a => a.FullName);
            var customerRecord = _customersRequestRepos.GetAll(x => x.Active)
                .Where(a => a.FullName.Contains(searchField) || a.Phone.Contains(searchField) || string.IsNullOrEmpty(searchField))
                         .ToList().OrderBy(c => c.FullName);

            if (customerRecord.Any())
            {
                _response.data = customerRecord;
                _response.msg = CommonConstants.RecordsRetrievedSuccessfully;
            }
            else
                _response.msg = CommonConstants.NoDataAvailable;
            _response.success = true;
            return await Task.Run(() => _response);
        }

        public async Task<ServiceResponse> UpdateCustomer()
        {
            return await Task.Run(() => _response);
        }
    }
}
