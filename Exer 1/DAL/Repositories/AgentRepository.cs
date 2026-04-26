using DAL;
using System.Collections.Generic;
using System.Linq;


public class AgentRepository : IRepository<Agent>
{
    private SaleManagementDBEntities _db = new SaleManagementDBEntities();

    public IEnumerable<Agent> GetAll() => _db.Agents.ToList();
    public Agent GetById(int id) => _db.Agents.Find(id);

    public void Add(Agent agent)
    {
        _db.Agents.Add(agent);
        _db.SaveChanges();
    }

    public void Update(Agent agent)
    {
        var existing = _db.Agents.Find(agent.AgentID);
        if (existing != null)
        {
            existing.AgentName = agent.AgentName;
            existing.Address = agent.Address;
            _db.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var agent = _db.Agents.Find(id);
        if (agent != null) { _db.Agents.Remove(agent); _db.SaveChanges(); }
    }
}
