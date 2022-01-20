using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseBookStore.Entites
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
    }
}
