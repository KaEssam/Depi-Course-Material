using Day1.Data;
using Microsoft.EntityFrameworkCore;

namespace Day1.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService( AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeletebyId(int id)
        {
            var prod = await _context.Products.FindAsync(id);

             _context.Products.Remove(prod);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetbyId(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> UpdatebyId(int id, Product product)
        {
            var prod = await _context.Products.FindAsync(id);

            prod.Name = product.Name;
            prod.Price = product.Price;

            await _context.SaveChangesAsync();
            return prod;
        }
    }
}
