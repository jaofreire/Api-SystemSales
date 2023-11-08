using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.Model;
using SalesSystem.Repository.Interfaces;

namespace SalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientModel>>> GetAll()
        {
            return await _clientRepository.GetAllClients();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> GetById(int id)
        {
            return await _clientRepository.GetClientById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ClientModel>> AddClient(ClientModel newClient)
        {
            return await _clientRepository.AddNewClient(newClient);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClientModel>> Update(ClientModel client, int id)
        {
            client.Id = id;
            return await _clientRepository.UpdateClient(client, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _clientRepository.DeleteClient(id);
        }

        [HttpPatch("{idClient}")]
        public async Task<ActionResult<ClientModel>> Buy(int idClient, int idProduct, int quantity)
        {
            return await _clientRepository.BuyProduct(idClient, idProduct, quantity);
        }

        [HttpPatch]
        public async Task<ActionResult<ClientModel>> Confirm(int id)
        {
            return await _clientRepository.ConfirmBuy(id);
        }
    }
}
