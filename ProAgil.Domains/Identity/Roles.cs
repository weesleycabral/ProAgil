using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
namespace ProAgil.Domains.Identity
{
    public class Roles : IdentityRole<int>
    {
      public List<UserRoles> UserRoles { get; set; } 
    }
}