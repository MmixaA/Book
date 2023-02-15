using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Book.UI.Models.User
{
    public class UserModel
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
    }
}
