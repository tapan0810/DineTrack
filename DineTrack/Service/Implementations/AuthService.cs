using DineTrack.Data;
using DineTrack.Entities.Models;
using DineTrack.Helper.JwtHelper;
using DineTrack.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DineTrack.Service.Implementations
{
    public class AuthService(ApplicationDbContext _context,IJwtHelper _jwtHelper) : IAuthService
    {
        
        public async Task<string> LoginAsync(User request)
        {
            var user = await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user is null)
                throw new Exception("User not found");

            if(user.Email != request.Email)
                throw new Exception("Invalid credentials");

            if(new PasswordHasher<User>().VerifyHashedPassword(user,user.PasswordHash,request.PasswordHash) == PasswordVerificationResult.Failed)
                throw new Exception("Invalid credentials");

            if(!user.IsActive)
                throw new Exception("User is blocked!");

            return _jwtHelper.GenerateJwtToken(user);


        }
    }
}
