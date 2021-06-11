using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            optionsBuilder.UseSqlServer(configuration["Data:RTCIdentity:ConnectionString"]);
        }
    }
}
