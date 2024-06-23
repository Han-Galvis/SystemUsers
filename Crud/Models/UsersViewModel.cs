namespace Crud.Models
{
    public class UsersViewModel
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
