using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RTChatDiscordAndTelegram.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace RTChatDiscordAndTelegram.EFCore.Context
{
    public class AppIdentityDbContext: DbContext
    {
        public AppIdentityDbContext() { }
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            :base(options) { }

        public DbSet<Identity> Identities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Identity>(e => 
            {
                e.HasIndex(m => m.Email).IsUnique();
                e.HasIndex(u => u.Username).IsUnique();
            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfiguration configuration = configBuilder.Build();
            var directory = (Directory.GetCurrentDirectory()).Split("\\bin");
            optionsBuilder.UseSqlServer(configuration["Data:RTCIdentity:ConnectionString"].Replace("[DataDirectory]", directory.FirstOrDefault()));
        }
    }
}
