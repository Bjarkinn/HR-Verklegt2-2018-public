namespace TheBookCave.Models.ViewModels {
    public class UserListViewModel {
       public string Id { get; set; } 
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email {get; set; }
        public bool EmailConfirmed { get; set; }
        public string LockoutEnd {get; set; }
        public bool LockoutEnabled { get; set; }
        public string NormalizedEmail {get; set; }
        public string NormalizedUserName {get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public int AddressId { get; set; }
        public int FavoriteBookId { get; set; }

        

    }
}