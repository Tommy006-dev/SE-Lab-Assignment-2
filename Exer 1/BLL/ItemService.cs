using DAL;
using System.Collections.Generic;
using System.Linq;

public class ItemService
{
    private ItemRepository _repo = new ItemRepository();

    public List<Item> GetAllItems() => _repo.GetAll().ToList();

    public Item GetItem(int id) => _repo.GetById(id);

    public bool AddItem(Item item)
    {
        if (string.IsNullOrWhiteSpace(item.ItemName)) return false;
        _repo.Add(item);
        return true;
    }

    public bool UpdateItem(Item item)
    {
        if (string.IsNullOrWhiteSpace(item.ItemName)) return false;
        _repo.Update(item);
        return true;
    }

    public void DeleteItem(int id) => _repo.Delete(id);

    // Thống kê: top items bán chạy
    //public List<Item> GetBestSellingItems()
    //{
    //    using (var db = new SaleManagementDBEntities())
    //    {
    //        return db.OrderDetails
    //                 .GroupBy(od => od.Item)
    //                 .Select(g => new {
    //                     ItemName = g.Key.ItemName,
    //                     TotalQty = g.Sum(x => x.Quantity),
    //                     TotalAmount = g.Sum(x => x.Quantity * x.UnitAmount)
    //                 })
    //                 .OrderByDescending(x => x.TotalQty)
    //                 .ToList<object>();
    //    }
    //}
}
