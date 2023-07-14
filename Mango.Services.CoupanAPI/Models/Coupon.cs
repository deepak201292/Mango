using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CoupanAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CoupanId { get; set; }
        [Required]
        public string CoupanCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public int MiniAmount { get; set;}
    }
}
