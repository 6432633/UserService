using UserService.Models;

namespace UserService.Data
{
    public class SqlUserRepository : IUserRepository
    {
        public UserContext UserContext { get; }
        public SqlUserRepository(UserContext userContext)
        {
            UserContext = userContext;
        }

        public User GetUserById(string id)
        {
            return UserContext.Users.FirstOrDefault(x => x.Id.ToString() == id);
        }

        public IEnumerable<User> GetUsers()
        {
           return UserContext.Users.ToList();
        }
        public void CreateUser(User user)
        {
            if(user == null) throw new ArgumentNullException("user");
            UserContext.Users.Add(user);
        }
        public void DeleteUser(User user)
        {
            UserContext.Users.Remove(user);
        }
        public void UpdateUser(User user)
        {
           
        }

        public bool SaveChanges() { return UserContext.SaveChanges() >= 0; }
    }
}
