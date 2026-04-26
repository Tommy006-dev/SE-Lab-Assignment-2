using DAL;
using System.Collections.Generic;
using System.Linq;

public class OrderService
{
    private OrderRepository _repo = new OrderRepository();

    public List<Order> GetAllOrders() => _repo.GetAll().ToList();

    public Order GetOrder(int id) => _repo.GetById(id);

    public bool AddOrder(Order order)
    {
        if (order == null) return false;
        _repo.Add(order);
        return true;
    }

    public void DeleteOrder(int id) => _repo.Delete(id);
    //// Thống kê: top items bán chạy
    //public List<Item> GetBestSellingItems()
    //{
    //    // logic truy vấn tổng hợp (xem bước 9)
    //}
}
