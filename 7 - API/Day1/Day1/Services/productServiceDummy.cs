using Day1.Data;
using Microsoft.EntityFrameworkCore;

namespace Day1.Services
{
    public class productServiceDummy : IProductService
    {

        private readonly AppDbContext _context;

        public productServiceDummy(AppDbContext context)
        {
            _context = context;
        }
        public Task<Product> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletebyId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public Task<Product> GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdatebyId(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
