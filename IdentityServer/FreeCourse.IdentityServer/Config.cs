using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace FreeCourse.IdentityServer
{
   public static class Config
   {
      public static IEnumerable<ApiResource> ApiResources => new ApiResource[] {
        new ApiResource("resource_catalog"){ Scopes = { "catalog_fullpermissions" } },
        new ApiResource("photo_stock_catalog"){ Scopes = { "photo_stock_fullpermissions" } },
        new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
      };


      public static IEnumerable<IdentityResource> IdentityResources =>
         new IdentityResource[]
         {
         };

      public static IEnumerable<ApiScope> ApiScopes =>
          new ApiScope[]
          {
             new ApiScope("catalog_fullpermissions","Catalog API için full erişim."),
             new ApiScope("photo_stock_fullpermissions","Photo Stock API için full erişim."),
             new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
          };

      public static IEnumerable<Client> Clients =>
          new Client[]
          {
             new Client{

                ClientName = "Asp.Net Core Mvc",
                ClientId = "WebMvcClient",
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes={ "catalog_fullpermissions", "photo_stock_fullpermissions", IdentityServerConstants.LocalApi.ScopeName }
             }
          };
   }
}