using api.Models;
using IMDB.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Infrastructure
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        public IdentityService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string?> GetUserNameAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user?.UserName;
        }
        public async Task<Dictionary<string, string?>> GetUserNamesAsync(IEnumerable<string> userIds)
        {
            var ids = userIds.Distinct().ToList();
            return (await _userManager.Users.Where(u => ids.Contains(u.Id)).ToListAsync())
                .ToDictionary(u => u.Id, u => u.UserName);
        }
    }
}
