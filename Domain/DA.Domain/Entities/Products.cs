using PK.BuildingBlocks.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA.Domain.Entities
{
    [Table("Products", Schema = "CP")]
    public class Products : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ProductTypeId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
