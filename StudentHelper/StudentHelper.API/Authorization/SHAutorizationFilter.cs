using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentHelper.API.Models;
using StudentHelper.API.Services.IServices;

namespace StudentHelper.API.Authorization
{
    public class SHAutorizationFilter : IAuthorizationFilter
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _role;
        public SHAutorizationFilter(IHttpContextAccessor httpContextAccessor,IAuthService authService,string role)
        {
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var token = _httpContextAccessor.HttpContext.Request.Headers["Access-Token"];
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            var response = _authService.VerifyToken<ResponseDto>(token,_role);

            if(!response.IsSuccess)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
