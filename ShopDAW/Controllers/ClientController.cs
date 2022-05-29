using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Entities;
using ShopDAW.Entities.DTOs;
using ShopDAW.Repositories.ClientRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;
        public ClientController(IClientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _repository.GetAllClientsWithAddress();
            var clientsToReturn = new List<ClientDTO>();
            foreach (var client in clients)
            {
                clientsToReturn.Add(new ClientDTO(client));
            }
            return Ok(clientsToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientDTO dto)
        {
            Client newClient = new Client();
            newClient.name = dto.name;
            newClient.address = dto.address;
            newClient.email = dto.email;
            _repository.Create(newClient);
            await _repository.SaveAsync();
            return Ok(new ClientDTO(newClient));
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetClientByEmail(string email)
        {
            var user = await _repository.GetByEmail(email);
            return Ok(new ClientDTO(user));
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteClient(string email)
        {
            var client = await _repository.GetByEmail(email);
            if (client == null)
                return NotFound("Client doesn't exist!");
            _repository.Delete(client);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{email}")]
        public async Task<IActionResult> UpdateName(string email, CreateClientDTO dto)
        {

            var client = await _repository.GetByEmail(email);
            if (client == null)
                return NotFound("Client doesn't exist");
            client.name = dto.name;
            await _repository.SaveAsync();
            return Ok(new ClientDTO(client));
        }

    }
}
