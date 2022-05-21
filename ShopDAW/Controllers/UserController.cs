using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Entities;
using ShopDAW.Entities.DTOs;
using ShopDAW.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repository.GetAllUsersWithAddress();
            var usersToReturn = new List<UserDTO>();
            foreach (var user in users)
            {
                usersToReturn.Add(new UserDTO(user));
            }
            return Ok(usersToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO dto)
        {
            User newUser = new User();
            newUser.name = dto.name;
            newUser.address = dto.address;
            newUser.email = dto.email;
            _repository.Create(newUser);
            await _repository.SaveAsync();
            return Ok(new UserDTO(newUser));
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _repository.GetByEmail(email);
            return Ok(new UserDTO(user));
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            var user = await _repository.GetByEmail(email);
            if (user == null)
                return NotFound("User doesn't exist!");
            _repository.Delete(user);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{email}")]
        public async Task<IActionResult> UpdateName(string email, CreateUserDTO dto)
        {

            var user = await _repository.GetByEmail(email);
            if (user == null)
                return NotFound("Account doesn't exist");
            user.name = dto.name;
            await _repository.SaveAsync();
            return Ok(new UserDTO(user));
        }

    }
}
