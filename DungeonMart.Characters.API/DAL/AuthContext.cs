using Microsoft.AspNet.Identity.EntityFramework;

namespace DungeonMart.Characters.API.DAL
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base("AuthContext") { }
    }
}