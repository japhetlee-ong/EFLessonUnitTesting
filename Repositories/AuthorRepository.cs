using EFLessonUnitTesting.Models;

namespace EFLessonUnitTesting.Repositories
{
    public class AuthorRepository(BlogsContext context)
    {
        private readonly BlogsContext _context = context;

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

    }
}
