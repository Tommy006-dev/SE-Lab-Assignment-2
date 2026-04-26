using DAL;
using System.Linq;


public class UserService
{
    private UserRepository _repo = new UserRepository();

    public User Login(string email, string password)
    {
        return _repo.GetAll()
                    .FirstOrDefault(u => u.Email == email
                                     && u.Password == password
                                     && u.Lock == false);
    }
}
