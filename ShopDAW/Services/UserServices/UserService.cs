using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ShopDAW.Entities;
using ShopDAW.Models.Constants;
using ShopDAW.Models.Entities;
using ShopDAW.Models.Entities.DTOs;
using ShopDAW.Repositories.SessionTokenRepository;
using ShopDAW.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAW.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _repository;
        private readonly ISessionTokenRepository _repositoryST;
        public UserService(UserManager<User> userManager, IUserRepository repository, ISessionTokenRepository repositoryST)
        {
            _userManager = userManager;
            _repository = repository;
            _repositoryST = repositoryST;
        }
        public async Task<bool> RegisterUserAsync(RegisterUserDTO dto)
        {
            var registerUser = new User();
            registerUser.UserName = dto.email;
            registerUser.Email = dto.email;
            registerUser.firstName = dto.firstName;
            registerUser.lastName = dto.lastName;
           

            var result = await _userManager.CreateAsync(registerUser, dto.password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(registerUser, UserRoleType.User);
                return true;
            }
            return false;
        }
        public async Task<bool> RegisterAdminAsync(RegisterUserDTO dto)
        {
            var registerUser = new User();
            registerUser.UserName = dto.email;
            registerUser.Email = dto.email;
            registerUser.firstName = dto.firstName;
            registerUser.lastName = dto.lastName;


            var result = await _userManager.CreateAsync(registerUser, dto.password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(registerUser, UserRoleType.Admin);
                return true;
            }
            return false;
        }
        public async Task<string> LoginUser(LoginUserDTO dto)
        {
            User user = await _userManager.FindByEmailAsync(dto.email);
            if (user != null)
            {
                user = await _repository.GetByIdWithRoles(user.Id);
                List<string> roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();

                var newJti = Guid.NewGuid().ToString();
                var tokenHandler = new JwtSecurityTokenHandler();
                var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my super secret key for auth"));
                var token = GenerateJwtToken(signinkey, user, roles, tokenHandler, newJti);

                _repositoryST.Create(new SessionToken(newJti, user.Id, token.ValidTo));
                await _repositoryST.SaveAsync();

                return tokenHandler.WriteToken(token); //security token -> string

            }

            return " ";
        }
        private SecurityToken GenerateJwtToken(SymmetricSecurityKey signinkey, User user, List<string> roles, JwtSecurityTokenHandler tokenHandler, string jti)
        {
            var subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, user.Email),
                                                           new Claim(ClaimTypes.Name, user.firstName + " " + user.lastName),
                                                           new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                                                           new Claim(JwtRegisteredClaimNames.Jti, jti)
            });

            foreach (var role in roles)
            {
                subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = new SigningCredentials(signinkey, SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }

    }
}
