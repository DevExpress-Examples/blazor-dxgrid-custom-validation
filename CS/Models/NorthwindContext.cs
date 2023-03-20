using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CustomValidation.Models;

public partial class NorthwindContext : DbContext {
    public NorthwindContext() {}

    public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options) {}

    public virtual DbSet<Employee> Employees { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=Northwind;Integrated Security=true");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
        modelBuilder.Entity<Employee>(entity => {
            entity.HasIndex(e => e.EmployeeId, "EmployeeId");
            entity.HasIndex(e => e.LastName, "LastName");
            entity.HasIndex(e => e.FirstName, "FirstName");
            entity.HasIndex(e => e.Title, "Title");
            entity.HasIndex(e => e.HireDate, "HireDate");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
