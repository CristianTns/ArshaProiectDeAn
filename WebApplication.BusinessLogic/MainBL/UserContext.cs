using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BusinessLogic.MainBL
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("name=Arsha")
        {
        }

        public virtual DbSet<UserTable> Users { get; set; }//creaza tabelul
    }
}
