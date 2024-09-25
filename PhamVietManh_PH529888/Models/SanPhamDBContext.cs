using Microsoft.EntityFrameworkCore;

namespace PhamVietManh_PH529888.Models
{
    public class SanPhamDBContext : DbContext
    {
        public SanPhamDBContext(DbContextOptions<SanPhamDBContext> options) : base(options) { }
        public DbSet<SanPham> sanPhams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>().HasData(
                new SanPham { id=Guid.NewGuid(), Name = "Hung", SoLuong = 1,ImgURL="..." },
                new SanPham { id = Guid.NewGuid(), Name = "Banh", SoLuong = 9 , ImgURL = "..." },
                new SanPham { id = Guid.NewGuid(), Name = "Keo", SoLuong = 5 , ImgURL = "..." },
                new SanPham { id = Guid.NewGuid(), Name = "Khoai", SoLuong = 8 , ImgURL = "..." },
                new SanPham { id = Guid.NewGuid(), Name = "Dua hau", SoLuong = 5 , ImgURL = "..." }
                );
        }
    }
}
