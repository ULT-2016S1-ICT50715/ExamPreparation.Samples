using NewLibraryApp.DataAccess.Model;
using SharpRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibraryApp.Services
{
    public class AuthorApplicationService
    {
        private IRepository<Author> _authorRepository;

        public AuthorApplicationService(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void CreateAuthor(string firstName, string lastName, string synopsis)
        {

        }

        public void UpdateAuthor(int authorId, string firstName, string lastName, string synopsis)
        {

        }
    }
}
