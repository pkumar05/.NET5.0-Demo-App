using System;
using System.ComponentModel.DataAnnotations;

namespace DA.Domain.DTO
{
    public class RefreshTokenRequest
    {
        // Intial refereshToken count to zero.
        int refreshCount = 0;
        DateTime requestRefreshTokenTimeStamp = DateTime.UtcNow;
        /// <summary>
        /// Properties added for Refresh Token Count
        /// </summary>
        public int RefreshTokenCount { get; set; }
        //   public int RefreshTokenCount { get => refreshCount++; set { refreshCount = ++value; } }

        //  public DateTime RequestRefreshTokenTimeStamp { get => requestRefreshTokenTimeStamp; set { requestRefreshTokenTimeStamp = value; } }
        /// <summary>
        /// Properties added to place expired token value
        /// </summary>
        [Required(ErrorMessage = "There should be valid token value needs to pass.")]
        public string ExpiredToken { get; set; }
        /// <summary>
        /// Properties added to place Refresh token
        /// </summary>
        [Required(ErrorMessage = "There should be valid Refresh token value needs to pass.")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //[Required]
        //[StringLength(maximumLength: 65, MinimumLength = 7)]
        //[RegularExpression(@"[a-zA-Z0-9_.@]*", ErrorMessage = "Please provide valid User Name.")]
        public string UserName { get; set; }


        /// <summary>
        /// Properties added to get full name
        /// </summary>
        public string FullName { get; set; }


        /// <summary>
        /// User Group Addded
        /// </summary>
        //[Required(ErrorMessage ="User Group is mandatory.")]
        public string[] UserGroup { get; set; }
        /// <summary>
        /// User Active status added
        /// </summary>
        [Required(ErrorMessage = "User Activ shoudl be passed internally")]
        public bool UserActive { get; set; }
        /// <summary>
        /// Is User Regsitration Completed
        /// </summary>
        [Required(ErrorMessage = "User Registration completion status needs to check")]
        public bool IsUserRegistrationCompleted { get; set; }
        /// <summary>
        /// property added to to check whethere user authenticated
        /// </summary>
        public bool IsUserAuthenticated { get; set; }
        /// <summary>
        /// Properties added to retrieve Code
        /// </summary>
        public string Domain { get; set; }
        public string Email { get; set; }
        public string[] OrganizationUnit { get; set; }

        public Boolean IsInternal { get; set; }
    }
}
