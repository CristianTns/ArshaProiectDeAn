using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BusinessLogic.MainBL
{
    public class SessionContext : DbContext
    {
        public SessionContext() :
            base("name=Arsha")
        {
        }

        public virtual DbSet<Session> Sessions { get; set; }
    }
}
