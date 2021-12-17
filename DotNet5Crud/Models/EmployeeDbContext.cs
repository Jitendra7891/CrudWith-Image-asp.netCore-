using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNet5Crud.Models
{
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext()
        {
        }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
           : base(options)
        { }
        public virtual DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeSalary)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeCity)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            }
            );
           // OnModelCreatingPartial(modelBuilder);

        }

       
       // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
    
}
