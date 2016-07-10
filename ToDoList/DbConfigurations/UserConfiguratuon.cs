using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace ToDoList.DbConfigurations
{
    public class UserConfiguratuon:EntityTypeConfiguration<Models.User>
    {
        public UserConfiguratuon()
        {
            ToTable("Users");
            HasKey(u => u.Id);
            Property(u => u.Name).HasMaxLength(50);
            Property(u => u.Name).HasColumnName("FIO");
            Property(u => u.Password).HasMaxLength(255);
            Property(u => u.Email).HasMaxLength(100);
            Property(u => u.AutId).HasMaxLength(255);

        }
    }
}