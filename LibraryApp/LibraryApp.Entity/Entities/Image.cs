
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entity.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}