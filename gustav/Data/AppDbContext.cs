using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Threading.Tasks;
using gustav.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;

namespace gustav.Data
{ 
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Login> Logins { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //DataSeed.SeedRoles(modelBuilder);

            //  Exclude all soft deleted items
            //  https://github.com/aspnet/EntityFrameworkCore/issues/10257
            //foreach (var entity in modelBuilder.Model.GetEntityTypes())
            //{
            //    if (typeof(ISoftDeletable).IsAssignableFrom(entity.ClrType))
            //    {
            //        modelBuilder
            //            .Entity(entity.ClrType)
            //            .HasQueryFilter(ConvertFilterExpression<ISoftDeletable>(e => !e.Deleted, entity.ClrType));
            //    }
            //}

            //modelBuilder.ApplyConfiguration(new ApplicationUserConfig());
            //modelBuilder.ApplyConfiguration(new ApplicationUserRoleConfig());

            //modelBuilder.ApplyConfiguration(new AuditConfig());

        }

        /// <summary>
        /// Checks if database exists
        /// </summary>
        /// <returns></returns>
        public bool Exists()
        {
            return ((RelationalDatabaseCreator)Database.GetService<IDatabaseCreator>()).Exists();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();

            var entries = ChangeTracker.Entries().ToList();
            return base.SaveChangesAsync(cancellationToken);
        }
        

        private static LambdaExpression ConvertFilterExpression<TInterface>(Expression<Func<TInterface, bool>> filterExpression, Type entityType)
        {
            var newParam = Expression.Parameter(entityType);
            var newBody = ReplacingExpressionVisitor.Replace(filterExpression.Parameters.Single(), newParam, filterExpression.Body);

            return Expression.Lambda(newBody, newParam);
        }
    }

}

