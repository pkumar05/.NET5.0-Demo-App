using DA.Domain.Entities;
using DA.Domain.Interfaces;
using DA.Infrastructure.SQL.Data;
using Microsoft.Extensions.Configuration;
using PK.BuildingBlocks.Repository;

namespace DA.Infrastructure.SQL.Repositories
{
    public class ProductTypeRequestRepository : RepositoryEF<ProductType>, IProductTypeRequestRepos
    {
        private readonly DADBContext _dbContext;
        public IConfiguration _configuration;

        public ProductTypeRequestRepository(DADBContext dBContext, IConfiguration configuration) : base(dBContext)
        {
            _dbContext = dBContext;
            _configuration = configuration;

        }
    }
}
