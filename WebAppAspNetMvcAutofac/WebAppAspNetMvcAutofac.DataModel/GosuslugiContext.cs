using System.Data.Entity;

namespace WebAppAspNetMvcAutofac.DataModel
{
    public class GosuslugiContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Citizenship> Citizenships { get; set; }
        public DbSet<AvailableDocument> AvailableDocuments { get; set; }
        public GosuslugiContext() : base("GosuslugiEntity")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasOptional(x => x.Documents).WithRequired().WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }
    }
}