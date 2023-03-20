using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMobilePhone_Models.Common;

namespace WebMobilePhone_DataAccess.Configurations
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                    Id = "58cd381e-8683-4b42-b7b6-70b6274bfa84",
                    Name = Roles.Master,
                    NormalizedName = Roles.Master.ToUpper()
            },
               new IdentityRole
               {
                   Id = "97ddd633-2a4d-42b3-8f82-a5fe1d94173a",
                   Name = Roles.User,
                   NormalizedName = Roles.User.ToUpper()
               },
                new IdentityRole
                {
                    Id = "399b34de-5b32-48b2-86b4-fb0881a2517c",
                    Name = Roles.Admin,
                    NormalizedName = Roles.Admin.ToUpper()
                }
            );
        }
    }
}
