using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson04.Models
{
    public class User
    {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public long RoleId { get; set; }
    }

    public class Role
    {
        public long RoleId { get; set; }

        public string Name { get; set; }
    }
}