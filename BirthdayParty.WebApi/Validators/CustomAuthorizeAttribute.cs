using BirthdayParty.WebApi.Enums;
using BirthdayParty.WebApi.Utils;
using Microsoft.AspNetCore.Authorization;

namespace BirthdayParty.WebApi.Validators
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(params RoleEnum[] roleEnums) 
        {
            var allowedRolesAsString = roleEnums.Select(x => x.GetDescriptionFromEnum());
            Roles = string.Join(",", allowedRolesAsString);
        }
    }
}
