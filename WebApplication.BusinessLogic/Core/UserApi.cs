using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApplication.BusinessLogic.MainBL;
using WebApplication.Domain.Entities.User;
using WebApplication.Helper;
using WebApplication1.Domain.Entities.Responces;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.BusinessLogic.Core
{
    public class UserApi
    {
        internal ULoginResponce RLogInUpService(ULoginData data)
        {
            UserTable result;
            var Validate = new EmailAddressAttribute();
            if (Validate.IsValid(data.Email))
            {
                //var pass =LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == data.Password);
                }

                if (result == null)
                {
                    return new ULoginResponce { Status = false, ActionStatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LastIp = data.Ip;
                    result.LastLogin = data.LoginTime;
                    //todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }
                return new ULoginResponce { Status = true };
            }
            else
                return new ULoginResponce { Status = false };
        }
        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }
        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UserTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;
            Mapper.Initialize(cfg => cfg.CreateMap<UserTable, UserMinimal>());
            var userminimal = Mapper.Map<UserMinimal>(curentUser);

            return userminimal;
        }
    }
}
