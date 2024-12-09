using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using CarBookApp_Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookApp_Persistance.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarBookAppContext _appContext;

        public TagCloudRepository(CarBookAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<List<TagCloud>> GetTagCloudByBlogId(int id)
        {
            var values = await _appContext.TagClouds.Where(x => x.BlogID == id).ToListAsync();
            return values;
        }
    }
}
