﻿
namespace CarBookApp.Application.Mediator.Results.TagCloudResults
{
    public class GetTagCloudByBlogIdQueryResult
    {
        public int TagCloudID { get; set; }
        public string Title { get; set; }
        public int BlogID { get; set; }
    }
}
