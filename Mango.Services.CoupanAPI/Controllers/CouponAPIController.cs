using AutoMapper;
using Azure;
using Mango.Services.CoupanAPI.Data;
using Mango.Services.CoupanAPI.Models;
using Mango.Services.CoupanAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Mango.Services.CoupanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {

        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper  _mapper;
   

        public CouponAPIController(AppDbContext db ,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
                   }

        [HttpGet]
        public ResponseDto Get()
        {
            try {
                IEnumerable<Coupon> objlist = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objlist);
            }
            catch (Exception ex)
            {
                _response.Result = ex.Message;
            }
            return _response;
        }


        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u=>u.CouponId==id);
                // This this can be achived from below smater way
                //CouponDto coupon = new CouponDto()
                //{
                //    CouponId = obj.CouponId,
                //    CouponCode=obj.CouponCode,
                //    DiscountAmount=obj.DiscountAmount,
                //    MiniAmount=obj.MiniAmount
                //};
               

                _response.Result = _mapper.Map<CouponDto>(obj) ;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {

            try
            {
                Coupon obj = _db.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch(Exception ex) 
            { }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                _response.Result= _mapper.Map<CouponDto>(obj);


            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try {
           Coupon obj= _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex) {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon obj= _db.Coupons.First(u=>u.CouponId==id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();   

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
