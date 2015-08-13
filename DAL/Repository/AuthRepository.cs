using DAL.Context;
using DomainModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class AuthRepository : IDisposable
    {
        private AuthContext ctx;

        private UserManager<IdentityUser> userManager;

        public AuthRepository()
        {
            ctx = new AuthContext();
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = await userManager.CreateAsync(user, userModel.Password);

            return result;
        }        

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(IdentityUser user, string authenticationType)
        {
            return await userManager.CreateIdentityAsync(user, authenticationType);
        }

        public void Dispose()
        {
            ctx.Dispose();
            userManager.Dispose();

        }
    }
}
