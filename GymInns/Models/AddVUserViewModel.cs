namespace GymInns.Models
{
    public class AddVUserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Plan { get; set; }

        public DateTime DateJoin { get; set; }

        public DateTime DateExpired { get; set; }
    }
}
