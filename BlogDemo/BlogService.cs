using Microsoft.EntityFrameworkCore;

namespace BlogDemo;

public class BlogService : IBlogService
{
    private readonly BlogDbContext _context;

    public BlogService(BlogDbContext context)
    {
        _context = context;
    }

    public async Task<List<BlogPost>> GetBlogPostsAsync()
    {
        return await _context.BlogPosts.ToListAsync();
    }

    public async Task<BlogPost> GetBlogPostAsync(int id)
    {
        return await _context.BlogPosts.FindAsync(id);
    }

    public async Task<BlogPost> AddBlogPostAsync(BlogPost blogPost)
    {
        _context.BlogPosts.Add(blogPost);
        await _context.SaveChangesAsync();
        return blogPost;
    }

    public async Task<BlogPost> UpdateBlogPostAsync(BlogPost blogPost)
    {
        _context.Entry(blogPost).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return blogPost;
    }

    public async Task<BlogPost> DeleteBlogPostAsync(int id)
    {
        var blogPost = await _context.BlogPosts.FindAsync(id);
        if (blogPost != null)
        {
            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();
        }

        return blogPost;
    }

    public bool BlogPostExists(int id)
    {
        return _context.BlogPosts.Any(e => e.Id == id);
    }
}