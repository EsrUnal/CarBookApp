using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using CarBookApp_Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookApp_Persistance.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookAppContext _appContext;

        public BlogRepository(CarBookAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<List<Blog>> GetBlogsWithAuthors()
        {
            var values = await _appContext.Blogs.Include(b => b.Author).ToListAsync();
            return values;
        }

        public async Task<List<Blog>> GetLast3BlogsWithAuthor()
        {
            var values = await _appContext.Blogs.Include(b => b.Author).OrderByDescending(x => x.BlogID).Take(3).ToListAsync();
            return values;
        }
    }
}
