using data_and_repo_pattern.database;
using data_and_repo_pattern.uow;
using data_and_repo_pattern.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace food_order_system.Services.UserService
{
    public class UserService : IUserService
    {
        IUnitOfWork _uow;
        public UserService(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<List<tbUser>> GetAllUsers()
        {
            List<tbUser> users = await _uow.userRepo.GetWithoutTracking().ToListAsync();
            return users;
        }

        public async Task<tbUser> GetUserByID(int id)
        {
            tbUser user = await _uow.userRepo.GetWithoutTracking().Where(a => a.UserID == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<UserViewModel> CreateNewUser(RegisterViewModel user)
        {
            UserViewModel uvm = new UserViewModel();
            tbUser obj = new tbUser
            {
                Email = user.Email,
                Password = user.Password,
                Username = user.Username
            };

            tbUser existingUser = await _uow.userRepo.GetWithoutTracking().Where(a => a.Email == user.Email).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                uvm.status = "user with that email already exists";
                return uvm;
            }
            else
            {
                if(user.Password != user.ConfirmPassword)
                {
                    uvm.status = "Password does not match";
                    return uvm;
                }
                else
                {
                    tbUser newUser = await _uow.userRepo.InsertReturnAsync(obj);
                    string token = GenerateJwtToken(newUser);
                    uvm.status = "success";
                    uvm.token = token;
                    uvm.userid = newUser.UserID;
                    return uvm;
                }
                
            }
        }

        public async Task<UserViewModel> LoginUser(tbUser user)
        {
            UserViewModel uvm = new UserViewModel();
            tbUser existingUser = await _uow.userRepo.GetWithoutTracking().Where(a => a.Email == user.Email).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                if(existingUser.Password == user.Password)
                {
                    string token = GenerateJwtToken(existingUser);
                    uvm.status = "success";
                    uvm.token = token;
                    uvm.userid = existingUser.UserID;
                    return uvm;
                }
                else
                {
                    uvm.status = "Incorrect email or password";
                    return uvm;
                }
            }
            else
            {
                uvm.status = "user does not exist";
                return uvm;
            }
        }

        private string GenerateJwtToken(tbUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = GenerateRandomKey();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
            new Claim(ClaimTypes.Name, user.Username.ToString()),
            new Claim(ClaimTypes.Email, user.Email.ToString())
                    // Add more claims as needed, e.g., user roles, email, etc.
                }),
                Expires = DateTime.UtcNow.AddDays(7), // Token expires in 7 days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private byte[] GenerateRandomKey()
        {
            using (var generator = RandomNumberGenerator.Create())
            {
                var key = new byte[32]; // 256 bits
                generator.GetBytes(key);
                return key;
            }
        }


    }
}
