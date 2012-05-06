using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FunWithSignalR.Data.Model;

namespace FunWithSignalR.Data.Context
{
    public class BlogPostContext : DbContext
    {
        private string _schemaName = string.Empty;
        public BlogPostContext(string connectionName, string schemaName)
            : base(connectionName)
        {
            _schemaName = schemaName;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BlogPostContext>(null);
            
            modelBuilder.Entity<BlogPost>().ToTable("BlogPosts", _schemaName);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}