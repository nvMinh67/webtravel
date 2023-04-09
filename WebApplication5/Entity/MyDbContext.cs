using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Entity
{
    public class MyDbContext : IdentityDbContext    
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options){}
        #region
        public DbSet<DIADIEM> DIADIEMs { get; set; }
        public DbSet<image_DIADIEM> image_DIADIEMs { get; set; }
        public DbSet<Tour> tours { get; set; }
        public DbSet<DetailTour> detailTours { get; set; }

        public DbSet<Booking> booking { get; set; }

        public DbSet<Booking_Detail> booking_Details { get; set; }

        #endregion
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DIADIEM>(d =>
            {
                d.ToTable("DIADIEMs");
                d.HasKey(dd => dd.ID);
            });
            modelBuilder.Entity<image_DIADIEM>(i =>
            {
                i.ToTable("image_DIADIEM");
                i.HasKey(e => e.ID);
                i.HasOne(e => e.dIADIEM).WithMany(e => e.image_DIADIEMs).HasForeignKey(e => e.id_DIADIEM);
            });
            modelBuilder.Entity<Tour>(t =>
            {
                t.ToTable("tours");
                t.HasKey(k => k.Id);
            });
            modelBuilder.Entity<DetailTour>(dt =>
            {
                dt.ToTable("detailTours");
                dt.HasKey(k => k.Id);
              
            });
            modelBuilder.Entity<Booking>(b =>
            {
                b.ToTable("booking");
                b.HasKey(b => b.Id);
            });
            modelBuilder.Entity<Booking_Detail>(db =>
            {
                db.ToTable("bookind_Details");
                db.HasKey(b => b.Id);
            });
            
        }

    }
}
