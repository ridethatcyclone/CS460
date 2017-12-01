namespace HW8.Controllers
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArtInfoContext : DbContext
    {
        public ArtInfoContext()
            : base("name=ArtInfoContext")
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ArtWork> ArtWorks { get; set; }
        public virtual DbSet<Classification> Classifications { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
