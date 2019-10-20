using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace DataApp2.Models
{
    public class PhoneDb :DbContext
    {
       
        public DbSet<Phone> Phones { get; set; }
        public PhoneDb(DbContextOptions<PhoneDb> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        
    }
}
