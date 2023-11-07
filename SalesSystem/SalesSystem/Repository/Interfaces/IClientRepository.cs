using SalesSystem.Model;

namespace SalesSystem.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<List<ClientModel>> GetAllClients();
        Task<ClientModel> GetClientById(int id);
        Task<ClientModel> AddNewClient(ClientModel client);
        Task<ClientModel> UpdateClient(ClientModel client, int id);
        Task<bool> DeleteClient(int id);

        Task<ClientModel> BuyProduct(int idClient, int idProduct, int quantity);
    }
}
