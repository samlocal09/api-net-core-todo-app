using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using TodoListApp.Model.Common.EntityFramework.Common;
using TodoListApp.Model.Common.EntityFramework.UserManagement;

namespace TodoListApp.Data.Common
{
    public class TodoAppNetCoreDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public TodoAppNetCoreDBContext(DbContextOptions options) : base(options)
        {
            //
        }

        public DbSet<Task> Tasks { set; get; }
        public DbSet<StateStatus> StateStatus { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Config Identities

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("ApplicationUserClaims").HasKey(x => x.Id);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("ApplicationRoleClaims")
                .HasKey(x => x.Id);

            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("ApplicationUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("ApplicationUserRoles")
                .HasKey(x => new { x.RoleId, x.UserId });

            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("ApplicationUserTokens")
               .HasKey(x => new { x.UserId });

            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers");
            modelBuilder.Entity<ApplicationRole>().ToTable("ApplicationRoles");

            #endregion Config Identities
        }

        //public override int SaveChanges()
        //{
        //    var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

        //    foreach (EntityEntry item in modified)
        //    {
        //        var changedOrAddedItem = item.Entity as IDateTracking;
        //        if (changedOrAddedItem != null)
        //        {
        //            if (item.State == EntityState.Added)
        //            {
        //                changedOrAddedItem.DateCreated = DateTime.Now;
        //            }
        //            changedOrAddedItem.DateModified = DateTime.Now;
        //        }
        //    }
        //    return base.SaveChanges();
        //}
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TodoAppNetCoreDBContext>
    {
        public TodoAppNetCoreDBContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<TodoAppNetCoreDBContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new TodoAppNetCoreDBContext(builder.Options);
        }
    }
}