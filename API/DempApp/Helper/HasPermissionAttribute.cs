using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DempApp.Helper
{
    public class HasPermission : ActionFilterAttribute
    {
        public string ServiceName = "IDM",
               ProcessName = string.Empty,
               SubProcessName = string.Empty;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                //var _adminService = (IAdministrationService)filterContext.HttpContext.RequestServices.GetService(typeof(IAdministrationService));
                //var _userSession = (IUserSession)filterContext.HttpContext.RequestServices.GetService(typeof(IUserSession));
                //var userDetail = _userSession.GetUser();
                //if (userDetail == null) filterContext.Result = new StatusCodeResult(statusCode: 401);
                //var result = _adminService.ValidatePermission(userDetail.UserName, ServiceName, ProcessName, SubProcessName).Result;
            }
            catch (Exception)
            {
                filterContext.Result = new StatusCodeResult(403);
            }
        }
    }
}
