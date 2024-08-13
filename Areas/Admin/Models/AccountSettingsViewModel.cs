namespace Paradise.Areas.Admin.Models
{
    public class AccountSettingsViewModel
    {
        public List<AdminUserViewModel> AdminUsers { get; set; }
    }

    public class AdminUserViewModel
    {
        public string Email { get; set; }
    }
}
