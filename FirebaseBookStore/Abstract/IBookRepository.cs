using FirebaseBookStore.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseBookStore.Abstract
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
        List<Book> GetAll(Expression<Func<Book, bool>> filter = null);
        Book Get(Expression<Func<Book, bool>> filter = null);
    }
}
