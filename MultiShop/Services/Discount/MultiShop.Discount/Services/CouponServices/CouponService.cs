using Dapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos.CouponDtos;

namespace MultiShop.Discount.Services.CouponServices
{
    public class CouponService : ICouponService
    {
        private readonly DiscountContext _discountContext;

        public CouponService(DiscountContext discountContext)
        {
            _discountContext = discountContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _discountContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using (var connection = _discountContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); // ExecuteAsync returns the number of rows affected
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _discountContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultCouponDto>> GetListAllCouponAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _discountContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query); // QueryAsync returns a list of objects
                return values.ToList();
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);
            using (var connection = _discountContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultCouponDto> GetCouponDetailByCodeAsync(string code)
        {
            string query = "Select * From Coupons Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _discountContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query, parameters);
                return values;
            }
        }

        public int GetCouponRateByCode(string code)
        {
            string query = "Select Rate From Coupons Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _discountContext.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public async Task<int> GetCouponCount()
        {
            string query = "Select Count(*) From Coupons";
            using (var connection = _discountContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }
    }
}
