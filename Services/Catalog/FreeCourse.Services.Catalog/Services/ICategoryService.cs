using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Model;
using FreeCourse.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Services
{
   interface ICategoryService
   {
      Task<Response<List<CategoryDto>>> GetAllAsync();
      Task<Response<CategoryDto>> CreateAsync(Category category);
      Task<Response<CategoryDto>> GetByIdAsync(string id);
   }
}
