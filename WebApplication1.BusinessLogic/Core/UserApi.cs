using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.BusinessLogic.Core
{
    public class UserApi
    {
        public ULogInResponse RLogInUpService(ULoginData data)
        {
            return new ULoginResponse { Status = false };
        }
    }
}
