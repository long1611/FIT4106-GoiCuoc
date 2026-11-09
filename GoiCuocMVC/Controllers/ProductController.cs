using GoiCuocMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoiCuocMVC.Controllers
{
    public class ProductController : Controller
    {
        // Danh sách tĩnh lưu trong bộ nhớ máy chủ (thay cho cơ sở dữ liệu).
        // "static" giúp dữ liệu được giữ lại giữa các request,
        // nhưng sẽ mất khi khởi động lại ứng dụng.
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "DATA30", Price = 30000, Category = "Gói data",
                ValidityDays = 30, Description = "15GB data tốc độ cao, hết dung lượng ngừng truy cập." },
            new Product { Id = 2, Name = "NGAY5", Price = 5000, Category = "Gói ngày",
                ValidityDays = 1, Description = "2GB data dùng trong 24 giờ." },
            new Product { Id = 3, Name = "THOAI50", Price = 50000, Category = "Gói thoại",
                ValidityDays = 30, Description = "Miễn phí gọi nội mạng dưới 10 phút, 50 phút ngoại mạng." },
            new Product { Id = 4, Name = "COMBO120", Price = 120000, Category = "Gói combo",
                ValidityDays = 30, Description = "4GB/ngày, miễn phí gọi nội mạng, 100 phút ngoại mạng." },
            new Product { Id = 5, Name = "DATA6T", Price = 600000, Category = "Gói data",
                ValidityDays = 180, Description = null }
        };

        // GET: /Product hoặc /
        public IActionResult Index()
        {
            return View(_products);
        }

        // GET: /san-pham/chi-tiet/1
        [Route("san-pham/chi-tiet/{id:int}")]
        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: /Product/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product model)
        {
            if (!ModelState.IsValid)
            {
                // Trả lại form kèm dữ liệu đã nhập để hiển thị lỗi
                return View(model);
            }

            // Tự tăng Id: lấy Id lớn nhất hiện có + 1 (nếu danh sách rỗng thì bắt đầu từ 1)
            model.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
