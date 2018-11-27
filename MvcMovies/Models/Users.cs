using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcMovies.Models
{
    public class Users
    {
        public string Username { get; set; }


    }
    public class UsersDBContext : DbContext
    {
        public DbSet<Users> Movies { get; set; }
    }

}