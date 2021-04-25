using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CommonBaseData.Model
{
    public partial class BaseData_Contexts : DbContext
    {
        public BaseData_Contexts()
        {
        }

        public BaseData_Contexts(DbContextOptions<BaseData_Contexts> options)
            : base(options)
        { 
        }

        public virtual DbSet<TblCommonBaseData> TblCommonBaseData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=(local);Database=Charity_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblCommonBaseData>(entity =>
            {
                entity.Property(e => e.BaseCode).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
