using System.ComponentModel.DataAnnotations;
namespace BailamMVC.Models.Entities.HeThongPhanPhoi;

public class HeThongPhanPhoi
{
    [Key]
    public string? MaHTTP { get; set; }
    public string? TenHTPP { get; set; }
    
    // Quan hệ 1 - N: Một HTPP có nhiều Đại lý
    public List<DaiLy>? DaiLy { get; set; }
}