﻿
namespace CarBookApp.Application.Mediator.Results.BlogResults
{
    public class GetBlogsWithAuthorsQueryResult
    {
        public int BlogID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
    }
}
