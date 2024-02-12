using FlightManagement.Database;
using FlightManagement.Entitys;

namespace FlightManagement.Services
{
    public class UserService : IUserInterface
    {
        private readonly FlightContext Context = null;
        public UserService(FlightContext context)
        {
            Context = context;
           
        }
        public void AddUser(User user)
        {
            try
            {
                if (user != null)
                {
                    Context.Users.Add(user);
                    Context.SaveChanges();
                  
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                User user = Context.Users.SingleOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    Context.Users.Remove(user);
                    Context.SaveChanges();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }



        public User GetUserById(int userId)
        {
            try
            {
                var res = Context.Users.SingleOrDefault(u => u.UserId == userId);

                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<User> GetUserByRoleName(string Role)
        {
            var res = Context.Users.Where(u => u.Role == Role).ToList();
            return res;
        }

        public List<User> GetUsers()
        {
            try
            {
                var Result = Context.Users .ToList();
                return Result;
                // return Context.Users.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateUser(User user)
        {

            try
            {
                Context.Users.Update(user);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public User ValidteUser(string email, string password)
        {
            return Context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
        
        public User GetUserByName(string userName)
        {
            return Context.Users.SingleOrDefault(u => u.UserName == userName);
        }

        List<User> IUserInterface.GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}

