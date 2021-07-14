using BookContactControl.Domain.Models;
using System.Data.Entity;
using BookContactControl.Infraestructure.Data.Map;

namespace BookContactControl.Infraestructure.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext() : base("AppConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContactMap());
        }
    }
}