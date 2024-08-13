using PaparaFinalBase.Entity;

namespace PaparaFinalData.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public decimal? Point {  get; set; }
        public ICollection<Wallet>? Wallets { get; set; }
        public ICollection<Basket>? Baskets { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
