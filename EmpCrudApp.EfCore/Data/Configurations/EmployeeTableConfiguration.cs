﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using EmpCrudApp.EfCore.Data;
using EmpCrudApp.EfCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EmpCrudApp.EfCore.Data.Configurations
{
    public partial class EmployeeTableConfiguration : IEntityTypeConfiguration<EmployeeTable>
    {
        public void Configure(EntityTypeBuilder<EmployeeTable> entity)
        {
            entity.Property(e => e.EmailId).HasMaxLength(250);

            entity.Property(e => e.Name).HasMaxLength(250);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<EmployeeTable> entity);
    }
}