using apicompanies.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace apicompanies.Db
{
    public class EnterpriseDb : DbContext
    {
        public EnterpriseDb(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
                property.SetColumnType("varchar");


            #region Index

            modelBuilder.Entity<Department>().HasIndex(b => b.Name).HasDatabaseName("IX_NameDepartment").IsUnique();
            modelBuilder.Entity<Enterprise>().HasIndex(b => b.Name).HasDatabaseName("IX_NameEnterprise").IsUnique();


            modelBuilder.Entity<Department_Employe>().HasIndex(x => new { x.DepartmentId, x.EmproyeId }).HasDatabaseName("IX_DepartmentEmploye").IsUnique();

            #endregion


        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Department_Employe> Departments_Employees { get; set; }
        public DbSet<Employe> Employees { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
    }
}
