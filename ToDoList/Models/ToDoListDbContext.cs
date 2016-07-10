using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ToDoList.Models
{
    public class ToDoListDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DbConfigurations.UserConfiguratuon());
            modelBuilder.Configurations.Add(new DbConfigurations.ItemConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}