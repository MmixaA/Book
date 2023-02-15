using Book.UI.Helper;
using Book.UI.Models.User;
using Book.UI.Services.Interfaces;
using Data.Entities.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Text;



namespace Book.UI.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient client;
        public UserService(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<UserModel> Login(LoginModel loginModel)
        {
            string json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("/api/Users/Login", content);
                var user = await response.ReadContentAsync<UserModel>();
                return user;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> Register(RegisterModel registerModel)
        {
            try
            {
                string json = JsonConvert.SerializeObject(registerModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/api/Users/Register", content);
                var user = await response.ReadContentAsync<UserModel>();

                return user;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
