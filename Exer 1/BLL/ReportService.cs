using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class ReportService
    {
        private ReportRepository _repo = new ReportRepository();

        public List<BestSellingItemDTO> GetBestSellingItems()
            => _repo.GetBestSellingItems();

        public List<AgentItemDTO> GetItemsByAgent(int agentId)
            => _repo.GetItemsByAgent(agentId);

        public List<ItemAgentDTO> GetAgentsByItem(int itemId)
            => _repo.GetAgentsByItem(itemId);
    }
}
