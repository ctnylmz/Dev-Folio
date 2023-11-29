namespace Dev_Folio.Areas.Admin.Models
{
    public class User
    {
        public string? UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SelectedRole { get; set; }
    }
}
