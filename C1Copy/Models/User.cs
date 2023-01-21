using System.ComponentModel.DataAnnotations;
using C1Copy.ViewModels;

namespace C1Copy.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Слишком больше имя")]
        public string Name { get; set; } = ""; // имя пользователя
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class ClientModel
    {
        public Client Client { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }

    public class UserModel
    {
        public IEnumerable<User> Users;
        public User User;
        
        public LoginModel loginModel;
        public RegisterModel registerModel;
        public Account Account;
    }
}
