using PK.BuildingBlocks.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA.Domain.Entities
{
    [Table("ProductType", Schema = "CP")]
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
