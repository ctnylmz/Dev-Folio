using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Dev_Folio.Models;

namespace Dev_Folio.Data
{
    public class DevFolioContext : IdentityDbContext
    {
        public DevFolioContext(DbContextOptions<DevFolioContext> options) : base(options)
        {

        }

        public DbSet<Home> Homes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
