using Microsoft.AspNetCore.Mvc;
using StudentHelper.API.Authorization;
using System.Data;

namespace StudentHelper.API.Filters
{
    public class SHAuthorizationAttribute : TypeFilterAttribute
    {
        public SHAuthorizationAttribute() : base(typeof(SHAutorizationFilter))
        {
            Arguments = new object[] { string.Empty };
        }
        public SHAuthorizationAttribute(string role) : base(typeof(SHAutorizationFilter)) 
        { 
            Arguments = new object[] { role };
        }
    }
}
