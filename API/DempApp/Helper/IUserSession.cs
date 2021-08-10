using DA.Domain.DTO;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace DempApp.Helper
{
    public interface IUserSession
    {
        RefreshTokenRequest GetUser();
    }

    public class UserSession : IUserSession
    {
        HttpContext _context;


        public UserSession(IHttpContextAccessor context)
        {
            _context = context.HttpContext;

        }

        public RefreshTokenRequest GetUser()
        {
            var identity = _context.User.Identity as ClaimsIdentity;
            RefreshTokenRequest user = new RefreshTokenRequest();

            if (identity != null && identity.Claims != null && identity.Claims.Count() > 0 && !string.IsNullOrEmpty(identity.Name))
            {
                user.UserGroup = identity.Claims.Where(x => x.Type == "USERGROUP").FirstOrDefault()?.Value?.Split(',');
                user.UserName = identity.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault().Value;
                user.OrganizationUnit = identity.Claims.Where(x => x.Type == "OrganizationUnit ").FirstOrDefault()?.Value?.Split(',');
                user.Email = identity.Claims.Where(x => x.Type == "EMAIL").FirstOrDefault().Value;

            }
            return user;

        }

    }
}
