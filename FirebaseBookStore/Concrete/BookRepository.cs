using FirebaseBookStore.Abstract;
using FirebaseBookStore.Entites;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseBookStore.Concrete
{
    public class BookRepository : IBookRepository
    {
        IFirebaseConfig _config;
        string _table;

        public BookRepository()
        {
            _config = new FirebaseConfig()
            {
                AuthSecret = Secrets.AuthSecret,
                BasePath = Secrets.BasePath
            };
            _table = "Books";
        }

        public void Add(Book book)
        {
            using (var client = new FirebaseClient(_config))
            {
                var response = client.Set($"{_table}/{book.Id}", book);
            }
        }

        public void Update(Book book)
        {
            using (var client = new FirebaseClient(_config))
            {
                var response = client.Update($"{_table}/{book.Id}", book);
            }
        }

        public void Delete(Book book)
        {
            using (var client = new FirebaseClient(_config))
            {
                var response = client.Delete($"{_table}/{book.Id}");
            }
        }

        public List<Book> GetAll(Expression<Func<Book, bool>> filter = null)
        {
            using (var client = new FirebaseClient(_config))
            {
                List<Book> data = client.Get($"{_table}").ResultAs<List<Book>>().ToList();
                data.RemoveAll(u => u == null);
                return filter is null
                    ? data.ToList()
                    : data.AsQueryable().Where(filter).ToList();
            }
        }

        public Book Get(Expression<Func<Book, bool>> filter = null)
        {
            using (var client = new FirebaseClient(_config))
            {
                List<Book> data = client.Get($"{_table}").ResultAs<List<Book>>();
                data.RemoveAll(u => u == null);
                return filter is null
                    ? data.SingleOrDefault()
                    : data.AsQueryable().SingleOrDefault(filter);
            }
        }
    }
}
