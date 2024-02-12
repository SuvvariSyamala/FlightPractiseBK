using FlightManagement.Entitys;

namespace FlightManagement.Services
{
    public interface IUserInterface
    {
        void AddUser(User user);
        List<User> GetUsers();
        User GetUserById(int UserId);
        List<User> GetUserByRoleName(string Role);
        void UpdateUser(User user);
        void DeleteUser(int UserId);
        User ValidteUser(string email, string password);
    }
}
