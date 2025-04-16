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
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillInfo> BillInfos { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<TableFood> TableFoods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new AccountConfiguration());
            modelBuilder.Configurations.Add(new BillConfiguration());
            modelBuilder.Configurations.Add(new BillInfoConfiguration());
            modelBuilder.Configurations.Add(new FoodConfiguration());
            modelBuilder.Configurations.Add(new FoodCategoryConfiguration());
            modelBuilder.Configurations.Add(new TableFoodConfiguration());

            base.OnModelCreating(modelBuilder);

        }
    }
}
