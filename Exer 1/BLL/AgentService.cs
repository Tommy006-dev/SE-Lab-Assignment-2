using DAL;
using System.Collections.Generic;
using System.Linq;

public class AgentService
{
    private AgentRepository _repo = new AgentRepository();

    public List<Agent> GetAllAgents() => _repo.GetAll().ToList();

    public Agent GetAgent(int id) => _repo.GetById(id);

    public bool AddAgent(Agent agent)
    {
        if (string.IsNullOrWhiteSpace(agent.AgentName)) return false;
        _repo.Add(agent);
        return true;
    }

    public bool UpdateAgent(Agent agent)
    {
        if (string.IsNullOrWhiteSpace(agent.AgentName)) return false;
        _repo.Update(agent);
        return true;
    }

    public void DeleteAgent(int id) => _repo.Delete(id);

}

