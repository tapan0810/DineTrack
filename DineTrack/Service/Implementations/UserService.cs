using DineTrack.Data;
using DineTrack.Entities.Dtos;
using DineTrack.Entities.Models;
using DineTrack.Entities.Requests;
using DineTrack.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DineTrack.Service.Implementations
{
    public class UserService(ApplicationDbContext _context) : IUserService
    {
        public async Task BlockUserAsync(int userId)
        {
           var user = await _context.Users.FindAsync(userId);
            if(user == null)
            {
                throw new Exception("User not found");
            }
            user.IsActive = false;
            await _context.SaveChangesAsync();
        }

        public async Task<UserDto> CreateUserAsync(CreateUserRequest request)
        {
            if(await _context.Users.AnyAsync(x => x.Email == request.Email))
            {
                throw new Exception("Email already exists");
            }

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                RoleId = request.RoleId,
                HostelId = request.HostelId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };


            var PasswordHash = new PasswordHasher<User>().HashPassword(user, request.Password);
            user.PasswordHash = PasswordHash;

             _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email
            };

        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            return await _context.Users
                .Select(x => new UserDto
                {
                    UserId = x.UserId,
                    FullName = x.FullName,
                    Email = x.Email 
                }).ToListAsync();
        }
    }
}
