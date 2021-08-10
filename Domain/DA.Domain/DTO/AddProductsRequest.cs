using System.ComponentModel.DataAnnotations;

namespace DA.Domain.DTO
{
    public class AddProductsRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }

        [Required]
        public string ProductTypeId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
