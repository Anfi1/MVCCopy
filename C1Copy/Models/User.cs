using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage ="Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
         
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
