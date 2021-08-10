using DA.Domain.DTO;
using System.Threading.Tasks;

namespace DA.ServicesInterfaces
{
    public interface IProductsService
    {
        Task<ServiceResponse> AddProductType(AddProductTypeRequest request, string createdBy);
        Task<ServiceResponse> GetProductType(string searchField, string userName);
        Task<ServiceResponse> UpdateProductType();
        Task<ServiceResponse> AddProduct(AddProductsRequest request, string createdBy);
        Task<ServiceResponse> GetProduct(GetProductDetailsRequest request, string userName);
        Task<ServiceResponse> UpdateProduct();
        Task<ServiceResponse> DeleteProduct();
    }
}
