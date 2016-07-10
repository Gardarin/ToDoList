using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace ToDoList.DbConfigurations
{
    public class ItemConfiguration:EntityTypeConfiguration<Models.Item>
    {
        public ItemConfiguration()
        {
            ToTable("Users");
            HasKey(u => u.Id);
            Property(u => u.Name).HasMaxLength(50);
            Property(u => u.Name).HasColumnName("Name");
            Property(u => u.Description).HasMaxLength(255);
            Property(u => u.Description).HasColumnName("WhatToDo");
        }
    }
}