using DAL;
using System.Collections.Generic;
using System.Linq;


public class UserRepository : IRepository<User>
{
    private SaleManagementDBEntities _db = new SaleManagementDBEntities();

    public IEnumerable<User> GetAll() => _db.Users.ToList();

    public User GetById(int id) => _db.Users.Find(id);

    public void Add(User user)
    {
        _db.Users.Add(user);
        _db.SaveChanges();
    }

    public void Update(User user)
    {
        var existing = _db.Users.Find(user.UserID);
        if (existing != null)
        {
            existing.UserName = user.UserName;
            existing.Email = user.Email;
            existing.Password = user.Password;
            existing.Lock = user.Lock;
            _db.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var item = _db.Users.Find(id);
        if (item != null) { _db.Users.Remove(item); _db.SaveChanges(); }
    }
}
