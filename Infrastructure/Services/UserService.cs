using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {
            var users = await _userRepository.ListAllAsync();
            var model = new List<UserResponseModel>();
            foreach (var user in users)
            {
                model.Add(new UserResponseModel { 
                    DateOfBirth = Convert.ToDateTime(user.DateOfBirth),
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });
            }
            return model;
        }

        public async Task<UserResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            return new UserResponseModel
            {
                Email = user.Email,
                DateOfBirth = Convert.ToDateTime(user.DateOfBirth),
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<UserLoginResponseModel> Login(string email, string password)
        {
            var dbUser = await _userRepository.GetUserByEmail(email);
            if (dbUser == null)
            {
                throw new NotFoundException("Email does not exists, please register first");
            }

            var hashedPassword = HashPassword(password, dbUser.Salt);
            if (hashedPassword == dbUser.HashedPassword)
            {
                var userLoginResponse = new UserLoginResponseModel
                {
                    Id = dbUser.Id,
                    Email = dbUser.Email,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    DateOfBirth = dbUser.DateOfBirth.GetValueOrDefault()
                };
                return userLoginResponse;
            }
            return null;
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel requestModel)
        {
            // Make sure email does not exists in database User table
            var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);
            if (dbUser != null)
            {
                //throw new Exception("Email already exists");
                throw new ConflictException("Email arleady exists");
            }

            // create a unique salt
            var salt = CreateSalt();
            var hashedPassword = HashPassword(requestModel.Password, salt);
            var user = new User
            {
                Email = requestModel.Email,
                Salt = salt,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                HashedPassword = hashedPassword
            };
            // save to database by calling UserRepository add method
            var createdUser = await _userRepository.AddAsync(user);
            var userResponse = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                LastName = createdUser.LastName,
                FirstName = createdUser.FirstName
            };

            return userResponse;
        }

        private string CreateSalt()
        {

            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string HashPassword(string password, string salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
               password: password,
               salt: Convert.FromBase64String(salt),
               prf: KeyDerivationPrf.HMACSHA1,
               iterationCount: 10000,
               numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
