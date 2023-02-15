using Book.UI.Models.User;

namespace Book.UI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> Login(LoginModel loginModel);
        Task<UserModel> Register(RegisterModel registerModel);
    }
}
