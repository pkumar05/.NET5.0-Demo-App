using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Domain.DTO
{
   public class GetProductDetailsRequest
    {
       // [Required]
        public string Name { get; set; }
       // [Required]
        public string Code { get; set; }

        //[Required]
        public string ProductType { get; set; }
        public string ProductTypeCode { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

    }
}
