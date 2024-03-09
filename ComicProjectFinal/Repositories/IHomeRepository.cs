using ComicProjectFinal.Models;

namespace ComicProjectFinal.Repositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Category>> Categories();
        Task<IEnumerable<Products>> GetProducts(string sTerm = "", int categoryId = 0);
    }
}