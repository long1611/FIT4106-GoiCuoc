using System.ComponentModel.DataAnnotations;

namespace GoiCuocMVC.Models
{
    // Mỗi đối tượng Product đại diện cho một gói cước viễn thông
    public class Product
    {
        [Display(Name = "Mã gói")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên gói cước")]
        [StringLength(50, ErrorMessage = "Tên gói cước tối đa 50 ký tự")]
        [Display(Name = "Tên gói cước")]
        public string Name { get; set; } = string.Empty;

        // Dùng decimal? (cho phép null) để [Required] bắt được trường hợp bỏ trống
        // và hiển thị đúng thông báo tiếng Việt
        [Required(ErrorMessage = "Vui lòng nhập giá cước")]
        [Range(1000, 5000000, ErrorMessage = "Giá cước phải từ 1.000 đến 5.000.000 VNĐ")]
        [Display(Name = "Giá cước (VNĐ)")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn loại gói")]
        [Display(Name = "Loại gói")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập thời hạn sử dụng")]
        [Range(1, 365, ErrorMessage = "Thời hạn phải từ 1 đến 365 ngày")]
        [Display(Name = "Thời hạn (ngày)")]
        public int? ValidityDays { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả tối đa 500 ký tự")]
        [Display(Name = "Mô tả ưu đãi")]
        public string? Description { get; set; }
    }
}
