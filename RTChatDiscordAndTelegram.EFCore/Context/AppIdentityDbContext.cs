using Microsoft.EntityFrameworkCore;
using RTChatDiscordAndTelegram.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTChatDiscordAndTelegram.EFCore.Context
{
    public class AppIdentityDbContext: DbContext
    {
        public AppIdentityDbContext() { }
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            :base(options) { }

        DbSet<Identity> Identities { get; set; }
    }
}
