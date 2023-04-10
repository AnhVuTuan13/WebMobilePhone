using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMobilePhone_DataAccess.Configurations
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
               new IdentityUserRole<string>
               {
                   UserId = "9fa0160f-c2c6-4124-8221-4f465e979807",
                   RoleId = "399b34de-5b32-48b2-86b4-fb0881a2517c"
               },
               new IdentityUserRole<string>
               {
                   UserId = "08bc2fc1-5387-4033-b7d3-8208d29746ff",
                   RoleId = "97ddd633-2a4d-42b3-8f82-a5fe1d94173a"
               },
                new IdentityUserRole<string>
                {
                    UserId = "3fa0160f-c2c6-4124-8221-4f465e979807",
                    RoleId = "58cd381e-8683-4b42-b7b6-70b6274bfa84"
                }
            );
        }
    }
}
