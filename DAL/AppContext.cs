using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Configuration;
namespace DAL
{
    public class AppContext :DbContext
    {
        public AppContext() : base("CoffeeAppDb")
        {
            // Khởi tạo database nếu chưa tồn tại
            Database.SetInitializer(new CreateDatabaseIfNotExists<AppContext>());
        }
        private void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillInfo> BillInfos { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<TableFood> TableFoods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new BillConfiguration());
            modelBuilder.Configurations.Add(new BillInfoConfiguration());
            modelBuilder.Configurations.Add(new FoodConfiguration());
            modelBuilder.Configurations.Add(new FoodCategoryConfiguration());
            modelBuilder.Configurations.Add(new TableFoodConfiguration());
            modelBuilder.Configurations.Add(new PasswordResetTokenConfiguration());
            base.OnModelCreating(modelBuilder);

        }
    }
}
