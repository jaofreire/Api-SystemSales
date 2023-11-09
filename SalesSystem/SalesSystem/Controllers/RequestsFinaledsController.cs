using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.Model;
using SalesSystem.Repository.Interfaces;

namespace SalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsFinaledsController : ControllerBase
    {
        private readonly IRequestsFinaledsRespository _requests;

        public RequestsFinaledsController(IRequestsFinaledsRespository requests)
        {
            _requests = requests;
        }

        [HttpGet]
        public async Task<ActionResult<List<RequestsFinaledsModel>>> GetAll()
        {
            return await _requests.GetAllRequests();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<RequestsFinaledsModel>> AddRequest(int id, RequestsFinaledsModel request)
        {
            
            return await _requests.AddRequestFinaled(id, request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteRequest(int id)
        {
            return await _requests.DeleteRequestFinaled(id);
        }

    }
}
