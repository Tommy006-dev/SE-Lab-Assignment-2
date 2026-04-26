using DAL;
using System.Collections.Generic;
using System.Linq;

public class ItemRepository : IRepository<Item>
{
    private SaleManagementDBEntities _db = new SaleManagementDBEntities();

    public IEnumerable<Item> GetAll() => _db.Items.ToList();

    public Item GetById(int id) => _db.Items.Find(id);

    public void Add(Item item)
    {
        _db.Items.Add(item);
        _db.SaveChanges();
    }

    public void Update(Item item)
    {
        var existing = _db.Items.Find(item.ItemID);
        if (existing != null)
        {
            existing.ItemName = item.ItemName;
            existing.Size = item.Size;
            existing.Price = item.Price;
            _db.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var item = _db.Items.Find(id);
        if (item != null) { _db.Items.Remove(item); _db.SaveChanges(); }
    }
}
