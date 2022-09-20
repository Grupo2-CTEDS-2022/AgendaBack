using AgendaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBack.Repositories
{
    public static class UserRepository
    {
        public static User Get(string Name, string Password)
        {
            var users = new List<User>();

            return users.Where(x => x.Name.ToLower() == Name.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
