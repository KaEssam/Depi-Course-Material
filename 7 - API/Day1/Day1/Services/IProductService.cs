using Day1.Data;

namespace Day1.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetbyId(int id);
        Task<bool> DeletebyId(int id);
        Task<Product> UpdatebyId(int id, Product product);
        Task<Product> Create(Product product);
    }
}
