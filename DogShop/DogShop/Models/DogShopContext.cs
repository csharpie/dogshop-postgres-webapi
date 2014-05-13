using System.Data.Entity;

namespace DogShop.Models
{
    public class DogShopContext : DbContext
    {
        public DogShopContext()
            : base("DogShopContext")
        {

        }
        public DbSet<Dog> Dogs { get; set; }
    }
}