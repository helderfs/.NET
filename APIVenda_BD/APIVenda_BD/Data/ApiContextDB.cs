using APIVenda_BD.Models;
using Microsoft.EntityFrameworkCore;

namespace APIVenda_BD.Data
{
    public class ApiContextDB : DbContext
    {

        public ApiContextDB(DbContextOptions<ApiContextDB> options) : base(options) {
            
        }

        public DbSet<VendasMod> VendasMod { get; set; }
    }
}
