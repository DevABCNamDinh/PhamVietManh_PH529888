using Microsoft.AspNetCore.Mvc;
using PhamVietManh_PH529888.Models;

namespace PhamVietManh_PH529888.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly SanPhamDBContext _db;
        public SanPhamController(SanPhamDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var sanphamList=_db.sanPhams.ToList();
            return View(sanphamList);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(SanPham sanPham, IFormFile imgFile)
        {//là một interface trong asp.net core
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img",imgFile.FileName);
            //tạo một đối tượng filestream để ghi dữ liệu vào file mới tại vừa tạo
            var stream = new FileStream(path, FileMode.Create);
            //sao chép ảnh vào thư  mục root
            imgFile.CopyTo(stream);
            //gán tên file ảnh cho thuộc tính
            sanPham.ImgURL = imgFile.FileName;  
            _db.sanPhams.Add(sanPham);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null )
            {
                return NotFound();
            }
            //tìm categor cần sửa
            var sanphamEdit = _db.sanPhams.Find(id);
            if (sanphamEdit == null)
            {
                return NotFound();
            }
            return View(sanphamEdit);
        }
        [HttpPost]
        public IActionResult Edit(Guid? id,SanPham sanPham, IFormFile imgFile)
        {
            var spEdit = _db.sanPhams.Find(id);
            if (spEdit == null)
            {
                return NotFound();
            }
            spEdit.Name=sanPham.Name;
            spEdit.SoLuong=sanPham.SoLuong;
            if (imgFile != null ) {
                //định nghĩa đường dẫn để lưu file
                string fileName = Path.GetFileName(imgFile.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img",imgFile.FileName);
                //kiểm tra và tọa thư mục nết chưa tồn tại
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                //lưu ảnh mới
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imgFile.CopyTo(stream);
                }
                spEdit.ImgURL = fileName;
                 _db.sanPhams.Update(spEdit);
                 _db.SaveChanges();
            }
           
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? id)
        {
            var sanPhamRemove = _db.sanPhams.Find(id);
            _db.sanPhams.Remove(sanPhamRemove);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
