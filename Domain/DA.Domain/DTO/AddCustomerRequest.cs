using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Domain.DTO
{
   public class AddCustomerRequest
    {
        [Required]
        public string FullName { get; set; }
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Description { get; set; }
        public bool IsGoldMember { get; set; }
        public bool IsDiamondMember { get; set; }
    }
}
