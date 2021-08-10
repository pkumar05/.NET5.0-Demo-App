using AutoMapper;

namespace DA.Domain.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            #region Commented Codes
            ////Company
            //CreateMap<CompanyRequest, IM_COMPANY>()
            //    .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(des => des.Address, opt => opt.MapFrom(src => src.Address))
            //    .ForMember(des => des.Address1, opt => opt.MapFrom(src => src.Address1))
            //    .ForMember(des => des.Address2, opt => opt.MapFrom(src => src.Address2))
            //    .ForMember(des => des.Domain, opt => opt.MapFrom(src => src.Domain))
            //    .ForMember(des => des.FaxNumber, opt => opt.MapFrom(src => src.FaxNumber))
            //    .ForMember(des => des.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            //    .ForMember(des => des.TradeLicense, opt => opt.MapFrom(src => src.TradeLicense))
            //    .ForMember(des => des.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            //    .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            //    .ForMember(des => des.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
            //    .ForMember(des => des.Active, opt => opt.MapFrom(src => src.Active))
            //    .ForMember(des => des.ID, opt => opt.MapFrom(src => src.ID));

            //CreateMap<IM_COMPANY, CompanyRequest>()
            //    .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(des => des.Address, opt => opt.MapFrom(src => src.Address))
            //    .ForMember(des => des.Address1, opt => opt.MapFrom(src => src.Address1))
            //    .ForMember(des => des.Address2, opt => opt.MapFrom(src => src.Address2))
            //    .ForMember(des => des.Domain, opt => opt.MapFrom(src => src.Domain))
            //    .ForMember(des => des.FaxNumber, opt => opt.MapFrom(src => src.FaxNumber))
            //    .ForMember(des => des.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            //    .ForMember(des => des.TradeLicense, opt => opt.MapFrom(src => src.TradeLicense))
            //    .ForMember(des => des.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            //    .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            //    .ForMember(des => des.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
            //    .ForMember(des => des.Active, opt => opt.MapFrom(src => src.Active))
            //    .ForMember(des => des.ID, opt => opt.MapFrom(src => src.ID));

            ////OU
            //CreateMap<OURequest, IM_OU>()
            //    .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(des => des.Company_Id, opt => opt.MapFrom(src => src.Company_Id))
            //    .ForMember(des => des.Code, opt => opt.MapFrom(src => src.Code))
            //    .ForMember(des => des.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            //    .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            //    .ForMember(des => des.ID, opt => opt.MapFrom(src => src.ID));

            //CreateMap<IM_OU, OURequest>()
            // .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
            // .ForMember(des => des.Company_Id, opt => opt.MapFrom(src => src.Company_Id))
            // .ForMember(des => des.Code, opt => opt.MapFrom(src => src.Code))
            // .ForMember(des => des.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            // .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            // .ForMember(des => des.ID, opt => opt.MapFrom(src => src.ID))
            // .ForMember(des => des.CompanyName, opt => opt.MapFrom(src => src.Company.Name));


            ////User OU
            //CreateMap<GroupOURequest, IM_GROUPS_OU>()
            //    .ForMember(des => des.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            //    .ForMember(des => des.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
            //    .ForMember(des => des.ID, opt => opt.MapFrom(src => src.ID))
            //    .ForMember(des => des.ACTIVE, opt => opt.MapFrom(src => src.Active));


            //CreateMap<ProfileRequest, IM_PROFILES>()
            //  .ForMember(des => des.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            //  .ForMember(des => des.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
            //  .ForMember(des => des.ID, opt => opt.MapFrom(src => src.Id))
            //  .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
            //  .ForMember(des => des.Active, opt => opt.MapFrom(src => src.Active));

            //CreateMap<GroupProfileRequest, IM_GROUPS_PROFILES>()
            //   .ForMember(des => des.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            //   .ForMember(des => des.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
            //   .ForMember(des => des.ID, opt => opt.MapFrom(src => src.Id))
            //   .ForMember(des => des.Group_Id, opt => opt.MapFrom(src => src.Group_Id))
            //   .ForMember(des => des.Profile_Id, opt => opt.MapFrom(src => src.Profile_Id))
            //   .ForMember(des => des.Active, opt => opt.MapFrom(src => src.Active));

            //CreateMap<UserRegistrationRequest, IM_USERS>()
            //   .ForMember(des => des.FullName, opt => opt.MapFrom(src => src.FullName))
            //   .ForMember(des => des.UserName, opt => opt.MapFrom(src => src.UserName))
            //   .ForMember(des => des.UserEmail, opt => opt.MapFrom(src => src.UserEmail))
            //   .ForMember(des => des.Password, opt => opt.MapFrom(src => src.Password))
            //   .ForMember(des => des.Telephone, opt => opt.MapFrom(src => src.Telephone))
            //   .ForMember(des => des.Address, opt => opt.MapFrom(src => src.Address))
            //   .ForMember(des => des.Address1, opt => opt.MapFrom(src => src.Address1))
            //   .ForMember(des => des.Address2, opt => opt.MapFrom(src => src.Address2))
            //   .ForMember(des => des.Remarks, opt => opt.MapFrom(src => src.Remarks));

            //CreateMap<RefreshTokenRequest, LoginRequest>()
            //    .ForMember(des => des.UserName, opt => opt.MapFrom(src => src.UserName))
            //    .ForMember(des => des.UserGroup, opt => opt.MapFrom(src => src.UserGroup))
            //    .ForMember(des => des.IsUserAuthenticated, opt => opt.MapFrom(src => src.IsUserAuthenticated))
            //    .ForMember(des => des.refreshTokenCount, opt => opt.MapFrom(src => src.RefreshTokenCount))
            //    .ForMember(des => des.IsUserRegistrationCompleted, opt => opt.MapFrom(src => src.IsUserRegistrationCompleted))
            //    .ForMember(des => des.UserActive, opt => opt.MapFrom(src => src.UserActive))
            //    .ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email))
            //    .ForMember(des => des.FullName, opt => opt.MapFrom(src => src.FullName))
            //    .ForMember(des => des.IsInternal, opt => opt.MapFrom(src => src.IsInternal));

            //CreateMap<IM_GROUPS, GroupsRequest>()
            //   .ForMember(des => des.GroupName, opt => opt.MapFrom(src => src.Name))
            //   .ForMember(des => des.Remarks, opt => opt.MapFrom(src => src.Remarks))
            //   .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            //   .ForMember(des => des.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            //   .ForMember(des => des.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
            //   .ForMember(des => des.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
            //   .ForMember(des => des.Active, opt => opt.MapFrom(src => src.Active));

            #endregion

        }
    }
}
