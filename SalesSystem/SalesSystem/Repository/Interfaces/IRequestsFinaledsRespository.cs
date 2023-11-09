using SalesSystem.Data;
using SalesSystem.Model;

namespace SalesSystem.Repository.Interfaces
{
    public interface IRequestsFinaledsRespository
    {
        Task<List<RequestsFinaledsModel>> GetAllRequests();
        Task<RequestsFinaledsModel> AddRequestFinaled(int id, RequestsFinaledsModel request);
        Task<bool> DeleteRequestFinaled(int id);

      

    }
}
