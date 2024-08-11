using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinalData.Entity;
using PaparaProjectData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectData.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(u => u.AspNetUserRoles)
                   .WithOne()
                   .HasForeignKey(w => w.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.AspNetRoleClaims)
                   .WithOne()
                   .HasForeignKey(w => w.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
