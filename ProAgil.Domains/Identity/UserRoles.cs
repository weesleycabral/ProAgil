using Microsoft.AspNetCore.Identity;
namespace ProAgil.Domains.Identity

{
    public class UserRoles : IdentityUserRole<int>
    {
        public User User { get; set; }
        public Roles Role { get; set; }
    }
}