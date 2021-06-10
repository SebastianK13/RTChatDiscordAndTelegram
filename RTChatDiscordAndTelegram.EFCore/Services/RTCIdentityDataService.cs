using Microsoft.EntityFrameworkCore;
using RTChatDiscordAndTelegram.Data.Models;
using RTChatDiscordAndTelegram.Data.Services;
using RTChatDiscordAndTelegram.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTChatDiscordAndTelegram.EFCore.Services
{
    public class RTCIdentityDataService : IRTCIdentityService
    {
        private readonly AppIdentityDbContext _context;
        public RTCIdentityDataService() =>
            _context = new AppIdentityDbContext();

        public async Task CreateNewUser(string username, string password)
        {
            Identity identity = new Identity()
            {
                Username = username,
                PasswordHash = password
            };

            _context.Identities.Add(identity);

            await _context.SaveChangesAsync();
        }

        public string GetHashPswd(string username) =>
            _context.Identities
                .Where(u => u.Username == username)
                .Select(p => p.PasswordHash)
                .FirstOrDefault();
    }
}
