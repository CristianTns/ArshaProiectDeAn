﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApplication.Domain.Entities.User;
using WebApplication1.Domain.Entities.Responces;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ULoginResponce UserLoginAction(ULoginData data);
        HttpCookie GenCookie(string loginCredetial);
        UserMinimal GetUserByCookie( string apiCookieValue);
    }
}
