using NewLibraryApp.DataAccess.Model;
using NewLibraryApp.Services;
using SharpRepository.InMemoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewLibraryApp.Tests
{
    public class AuthorApplicationServiceTests
    {
        [Fact]
        public void CreateAuthor_ShouldCreateValidAuthor()
        {
            // Fixture setup
            var authorRepo = new InMemoryRepository<Author>();
            var authorService = new AuthorApplicationService(authorRepo);

            var expected = new Author()
            {
                FirstName = "blah",
                LastName = "fdlskhgdsa",
                Synopsis = "fhlkhdfaslkhjgoiuwer"
            };

            // Exercise the SUT (system under test)
            authorService.CreateAuthor(
                expected.FirstName,
                expected.LastName,
                expected.Synopsis);

            // State verification
            var actual = authorRepo.AsQueryable().FirstOrDefault();

            Assert.Equal(1, authorRepo.Count());
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.Synopsis, actual.Synopsis);
        }

        [Fact]
        public void UpdateAuthor_ShouldUpdateValidAuthor()
        {
            // Fixture setup
            var author = new Author()
            {
                FirstName = "fhlkhsdgasd",
                LastName = "klhlkhjsdg",
                Synopsis = "zlkhzoiutqwp"
            };

            var authorRepo = new InMemoryRepository<Author>();
            authorRepo.Add(author);
            var authorService = new AuthorApplicationService(authorRepo);

            var expected = new Author()
            {
                FirstName = "blah",
                LastName = "fdlskhgdsa",
                Synopsis = "fhlkhdfaslkhjgoiuwer"
            };

            // Exercise the SUT (system under test)
            authorService.UpdateAuthor(
                author.Id,
                expected.FirstName,
                expected.LastName,
                expected.Synopsis);

            // State verification
            var actual = authorRepo.Get(author.Id);

            Assert.Equal(1, authorRepo.Count());
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.Synopsis, actual.Synopsis);
        }
    }
}
