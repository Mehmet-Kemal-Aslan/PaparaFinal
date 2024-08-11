using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectData.Entity
{
    public class Role : IdentityRole<string>
    {
        public ICollection<IdentityUserRole<string>> AspNetUserRoles { get; set; }
        public ICollection<IdentityRoleClaim<string>> AspNetRoleClaims { get; set; }
    }
}
