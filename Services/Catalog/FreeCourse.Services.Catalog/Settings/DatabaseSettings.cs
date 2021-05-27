using System;

namespace FreeCourse.Services.Catalog.Settings
{
   public class DatabaseSettings : IDatabaseSettings
   {
      public string CategoryCollectionName { get; set; }
      public string CourseCollectionName { get; set; }
      public string ConnectionString { get; set; }
      public string DatabaseName { get; set; }
   }
}
