using System.Collections.Generic;
using UserService.Models;
namespace UserService.Data{
    public interface IUserRepository{

        bool SaveChanges();
        IEnumerable<User> GetUsers();
        User GetUserById(string id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}