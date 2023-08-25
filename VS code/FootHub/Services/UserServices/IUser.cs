using FootHub.Models;
using FootHub.UIFormatting;

namespace FootHub.Services.UserServices
{
    public interface IUser
    {
        Task<List<UserTable>> GetUsersList();

        Task<UserTable> SignUp(UserTable user);

        Task<UserTable> Login(string id, string password);

        Task<string> DeleteAccount(string id, string password);

        Task<string> UpdateAccount(string id, string password,UserUpdate user);



    }
}
