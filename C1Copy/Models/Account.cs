using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1Copy.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }

    }
    public class Role
    {
        public int RoleID { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
        
    }
}