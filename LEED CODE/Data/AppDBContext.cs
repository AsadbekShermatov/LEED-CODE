using LEED_CODE.ApiResponse;
using LEED_CODE.Models;
using Microsoft.EntityFrameworkCore;

namespace LEED_CODE.Data
{
    public class AppDBContext : DbContext
    {
       public DbSet<UserDb> UserDbs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-G3SP2SRJPL7; Database=ApiResponseDB; Trusted_Connection=True; TrustServerCertificate=True;");
        }
    }
}
