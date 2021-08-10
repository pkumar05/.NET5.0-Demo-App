using PK.BuildingBlocks.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA.Domain.Entities
{
    [Table("CustomerOrders", Schema = "CP")]
    public class CustomerOrders : BaseEntity
    {
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
