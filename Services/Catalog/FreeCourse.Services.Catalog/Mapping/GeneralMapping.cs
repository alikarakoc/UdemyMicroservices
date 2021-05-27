using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Model;

namespace FreeCourse.Services.Catalog.Mapping
{
   public class GeneralMapping : Profile
   {
      public GeneralMapping()
      {
         CreateMap<Course, CourseDto>().ReverseMap();
         CreateMap<Course, CourseCreateDto>().ReverseMap();
         CreateMap<Course, CourseUpdateDto>().ReverseMap();

         CreateMap<Category, CategoryDto>().ReverseMap();
         CreateMap<Feature, FeatureDto>().ReverseMap();
      }
   }
}
