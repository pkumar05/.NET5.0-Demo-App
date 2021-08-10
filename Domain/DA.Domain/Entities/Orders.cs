using PK.BuildingBlocks.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA.Domain.Entities
{
    [Table("Orders", Schema = "CP")]
    public class Orders : BaseEntity
    {
        public string Name { get; set; }
        public string ProductId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
