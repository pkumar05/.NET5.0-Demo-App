using DA.Domain.DTO;
using DA.Domain.Entities;
using DA.Domain.Interfaces;
using DA.ServicesInterfaces;
using DM.ApplicationServices.Helper;
using PK.BuildingBlocks.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.ApplicationServices
{
    public class ProductService : IProductsService
    {

        readonly IProductsRequestRepos _productsRequestRepos;
        readonly IProductTypeRequestRepos _productTypeRequestRepos;
        //readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        public ProductService(
              IProductsRequestRepos productsRequestRepos,
              IProductTypeRequestRepos productTypeRequestRepos,
        // IMapper mapper,
         IUnitOfWork unitOfWork
            )
        {
            _productsRequestRepos = productsRequestRepos;
            _productTypeRequestRepos = productTypeRequestRepos;
            _unitOfWork = unitOfWork;
        }

        readonly ServiceResponse _response = new ServiceResponse();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> AddProduct(AddProductsRequest request, string createdBy)
        {
            return await Task.Run(() => _response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> AddProductType(AddProductTypeRequest request, string createdBy)
        {
            if (string.IsNullOrEmpty(createdBy))
                createdBy = CommonConstants.SYSTEM;

            var productTypeData = _productTypeRequestRepos.Get(x => x.Active && x.Name == request.Name && x.Code == request.Code);

            if (productTypeData == null)
            {
                var productType = new ProductType
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name.TitleCase(),
                    Code = request.Code.ToUpper(),
                    Description = request.Description,

                    Active = true,
                    CreatedBy = createdBy,
                    CreatedDate = DateTime.Now,

                };
                _productTypeRequestRepos.Add(productType);
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

        public async Task<ServiceResponse> DeleteProduct()
        {
            return await Task.Run(() => _response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> GetProduct(GetProductDetailsRequest request, string userName)
        {
            return await Task.Run(() => _response);
        }

        /// <summary>
        /// Method added to get the product type data/list
        /// </summary>
        /// <param name="searchField"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> GetProductType(string searchField, string userName)
        {
            // var data = _productTypeRequestRepos.GetAll(x => x.Active && x.Name.Contains(searchField) || x.Code.Contains(searchField)).ToList().OrderBy(a => a.Name);

            var data = _productTypeRequestRepos.GetAll(x => x.Active)
                          .Where(a => a.Name.Contains(searchField) || a.Code.Contains(searchField) || string.IsNullOrEmpty(searchField))
                         .ToList().OrderBy(c => c.Name);

            if (data.Any())
            {
                _response.data = data;
                _response.msg = CommonConstants.RecordsRetrievedSuccessfully;
            }
            else
                _response.msg = CommonConstants.NoDataAvailable;
            _response.success = true;
            return await Task.Run(() => _response);
        }

        public async Task<ServiceResponse> UpdateProduct()
        {
            return await Task.Run(() => _response);
        }

        public async Task<ServiceResponse> UpdateProductType()
        {
            return await Task.Run(() => _response);
        }
    }
}
