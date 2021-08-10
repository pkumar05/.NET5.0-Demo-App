using PK.BuildingBlocks.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA.Domain.Entities
{
    [Table("Customers", Schema = "CP")]
    public class Customers : BaseEntity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Description { get; set; }
        public bool IsGoldMember { get; set; }
        public bool IsDiamondMember { get; set; }
        public bool Active { get; set; }
    }
}
