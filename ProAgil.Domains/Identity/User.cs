using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ProAgil.Domains.Identity
{
    public class User : IdentityUser<int>
    {

        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }
        public List<UserRoles> UserRoles { get; set; }

    }
}