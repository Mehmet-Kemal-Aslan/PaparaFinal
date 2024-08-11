using Microsoft.AspNetCore.Identity;

namespace PaparaFinalData.Entity
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Wallet>? Wallets { get; set; }
        public ICollection<Basket>? Baskets { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
        public ICollection<IdentityUserClaim<string>>? AspNetUserClaims { get; set; }
        public ICollection<IdentityUserRole<string>>? AspNetUserRoles { get; set; }
        public ICollection<IdentityUserToken<string>>? AspNetUserTokens { get; set; }
        public ICollection<IdentityUserLogin<string>>? AspNetUserLogins { get; set; }
    }
}
