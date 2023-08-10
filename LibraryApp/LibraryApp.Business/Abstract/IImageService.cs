using LibraryApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Abstract
{
    public interface IImageService
    {
        Task CreateAsync(Image image);
        Task<Image> GetByIdAsync(int id);
        Task<List<Image>> GetAllAsync();
        void Update(Image image);
        void Delete(Image image);
    }
}
