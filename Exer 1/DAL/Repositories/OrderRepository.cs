using DAL;
using System.Collections.Generic;
using System.Linq;


public class OrderRepository
{
    private SaleManagementDBEntities _db = new SaleManagementDBEntities();
    public List<Order> GetAll() =>
        _db.Orders.Include("Agent").Include("OrderDetail").ToList();

    public Order GetById(int id) =>
        _db.Orders.Include("Agent")
                    .Include("OrderDetail.Item")
                    .FirstOrDefault(o => o.OrderID == id);

    public void Add(Order order)
    {
        _db.Orders.Add(order);
        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        var order = _db.Orders.Find(id);
        if (order != null)
        {
            _db.OrderDetails.RemoveRange(order.OrderDetails);
            _db.Orders.Remove(order);
            _db.SaveChanges();
        }
    }
}
