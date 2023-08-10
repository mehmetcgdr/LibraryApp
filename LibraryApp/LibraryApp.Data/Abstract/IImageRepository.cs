using LibraryApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data.Abstract
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        int ImageCount(int bookId);
    }
}