
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Concrete.EfCore.Context;
using LibraryApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data.Concrete.EfCore
{
    public class EfCoreImageRepository : EfCoreGenericRepository<Image>, IImageRepository
    {
        public EfCoreImageRepository(LibraryAppContext _appContext) : base(_appContext)
        {
        }
        LibraryAppContext AppContext
        {
            get { return _dbContext as LibraryAppContext; }

        }

        public int ImageCount(int bookId)
        {
            return AppContext.Images.Count(i=>i.BookId== bookId);
        }
    }
}