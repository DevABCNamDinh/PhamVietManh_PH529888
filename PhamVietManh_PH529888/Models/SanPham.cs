using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhamVietManh_PH529888.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public Guid id { get; set; }
        public string Name{ get; set; }
        public int SoLuong { get; set; }
        public string ImgURL { get; set; }
    }
}
