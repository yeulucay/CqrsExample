using DAL.Repository;
using DomainModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization
{
    public class UserBusiness
    {
        AuthRepository authRepo = null;

        public UserBusiness()
        {
            authRepo = new AuthRepository();
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            return await authRepo.RegisterUser(userModel);
        }
    }
}
