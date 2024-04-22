using EFLessonUnitTesting.Models;

namespace EFLessonUnitTesting.Repositories
{
    public class BlogPostRepository(BlogsContext context)
    {
        private readonly BlogsContext _context = context;

        public List<BlogPost> GetAllBlogPost()
        {
            return _context.BlogPosts.ToList();
        }

        public void AddBlogPost(BlogPost blogPost)
        {
            _context.BlogPosts.Add(blogPost);
            _context.SaveChanges();

        }

    }
}
