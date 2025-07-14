using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BailamMVC.Models.Entities;
public class DaiLy
{
    [Key]
    public string? MaDaiLy { get; set; }
    public string? TenDaiLy { get; set; }
    public string? DiaChi { get; set; }
    public string? NguoiDaiDien { get; set; }
    public string? DienThoai { get; set; }
    [ForeignKey("HeThongPhanPhoi")]
    public string? MaHTTP { get; set; }
    // dùng để thiết lập mối quan hệ giữa hai thực thể
}