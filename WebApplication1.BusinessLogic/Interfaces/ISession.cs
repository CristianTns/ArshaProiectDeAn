using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.Responces;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.BusinessLogic.Interfaces
{
    internal interface ISession
    {
        ULoginResponce UserLoginAction(ULoginData data);
    }
}
