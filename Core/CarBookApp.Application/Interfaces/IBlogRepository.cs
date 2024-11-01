
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Interfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLast3BlogsWithAuthor();
        Task<List<Blog>> GetBlogsWithAuthors();
    }
}
