using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.Responces;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.BusinessLogic.Core
{
    public class UserApi
    {
        public ULoginResponce RLogInUpService(ULoginData data)
        {
            return new ULoginResponce { Status = false };
        }
    }
}
