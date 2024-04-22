using EFLessonUnitTesting.Models;
using EFLessonUnitTesting.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace EFLessonUnitTesting.UnitTest
{
    [TestFixture]
    public class BlogRepositoryTest
    {
        private DbContextOptions<BlogsContext>? _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<BlogsContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;
        }

        [Test]
        public void GetAllBlogPost()
        {
            //ARRANGE
            var author = new Author
            {
                Email = "Jong@gmail.com",
                Name = "Test",
                DateCreated = DateTime.Now,
            };

            using (var entities = new BlogsContext(_options!))
            {
                AuthorRepository authorRepository = new(entities);
                authorRepository.AddAuthor(author);

                var blogs = new BlogPost
                {
                    BlogContent = "Test Content",
                    AuthorId = author.Id,
                    Slug = "Test-Slug",
                    Title = "Test Title",
                };

                BlogPostRepository blogPostRepository = new(entities);
                blogPostRepository.AddBlogPost(blogs);

                //ACT
                var blogList = blogPostRepository.GetAllBlogPost();

                //ASSERT
                Assert.That(1, Is.EqualTo(blogList.Count));
                ClassicAssert.IsTrue(blogList.Any(p => p.Title == "Test Title"));

            }


        }

    }

}
