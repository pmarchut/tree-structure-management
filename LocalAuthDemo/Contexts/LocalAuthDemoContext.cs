using LocalAuthDemo.Models;
using LocalAuthDemo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalAuthDemo.Contexts
{
    public class LocalAuthDemoContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public IConfiguration _config;

        public DbSet<Node> Nodes { get; set; }

        public LocalAuthDemoContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["database:connection"]);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Node>()
                .HasMany(p => p.SubNodes)
                .WithOne(p => p.ParentNode)
                .HasForeignKey(p => p.ParentId);

            builder.Entity<User>(b =>
            {
                b.ToTable("Users");
            });

            builder.Entity<IdentityUserClaim<Guid>>(b =>
            {
                b.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<Guid>>(b =>
            {
                b.ToTable("UserLogins");
            });

            builder.Entity<IdentityUserToken<Guid>>(b =>
            {
                b.ToTable("UserTokens");
            });

            builder.Entity<IdentityRole<Guid>>(b =>
            {
                b.ToTable("Roles");
            });

            builder.Entity<IdentityRoleClaim<Guid>>(b =>
            {
                b.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserRole<Guid>>(b =>
            {
                b.ToTable("UserRoles");
            });

            builder.Entity<Node>().HasData(new Node {Id = 1, ParentId = null });

            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>
                { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole<Guid>
                { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "User", NormalizedName = "User".ToUpper() });
        }
    }
}
