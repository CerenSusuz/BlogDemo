namespace BlogDemo
{
    public interface IBlogService
    {
        Task<List<BlogPost>> GetBlogPostsAsync();

        Task<BlogPost> GetBlogPostAsync(int id);

        Task<BlogPost> AddBlogPostAsync(BlogPost blogPost);

        Task<BlogPost> UpdateBlogPostAsync(BlogPost blogPost);

        Task<BlogPost> DeleteBlogPostAsync(int id);

        bool BlogPostExists(int id);
    }
}
