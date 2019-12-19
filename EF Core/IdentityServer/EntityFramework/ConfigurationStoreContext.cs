using IdentityServer4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntityFramework
{
    /// <summary>
    /// Configuration store context class
    /// </summary>
    public class ConfigurationStoreContext : DbContext
    {
        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public ConfigurationStoreContext(DbContextOptions<ConfigurationStoreContext> options) : base(options)
        { }
 
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public DbSet<ClientEntity> Clients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public DbSet<ApiResourceEntity> ApiResources { get; set; }
        public DbSet<IdentityResourceEntity> IdentityResources { get; set; }
         
 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ClientEntity>().HasKey(m => m.ClientId);
            builder.Entity<ApiResourceEntity>().HasKey(m => m.ApiResourceName);
            builder.Entity<IdentityResourceEntity>().HasKey(m => m.IdentityResourceName);
            base.OnModelCreating(builder);
        }
    }
}