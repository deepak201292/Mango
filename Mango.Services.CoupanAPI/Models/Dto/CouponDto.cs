namespace Mango.Services.CoupanAPI.Models.Dto
{
    public class CouponDto
    {
        public int CoupanId { get; set; }
        public string CoupanCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MiniAmount { get; set; }
    }
}
