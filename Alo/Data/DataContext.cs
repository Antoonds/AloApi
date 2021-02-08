using Alo.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alo.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>,AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }
        public DbSet<FillIn> FillIns { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
               .HasMany(ur => ur.UserRoles)
               .WithOne(u => u.Role)
               .HasForeignKey(ur => ur.RoleId)
               .IsRequired();

            builder.Entity<Request>()
                .HasOne(a => a.Requester)
                .WithMany(b => b.Requests)
                .HasForeignKey(c => c.RequesterId);

            builder.Entity<FillIn>()
                .HasOne(a => a.FillInRequester)
                .WithMany(b => b.FillInRequests)
                .HasForeignKey(c => c.FillInRequesterId);

            builder.Entity<FillIn>()
                .HasOne(a => a.Filler)
                .WithMany(b => b.FillIns)
                .HasForeignKey(c => c.FillerId);

        }
    }
}
