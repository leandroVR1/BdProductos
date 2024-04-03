
using Microsoft.EntityFrameworkCore;
using Bdproductos.Models;

namespace Bdproductos.Data{
    public class BaseContext : DbContext{
        public BaseContext(DbContextOptions<BaseContext> options) : base(options){
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

    }

}