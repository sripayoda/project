using FootHub.Execptions;
using FootHub.Models;
using FootHub.UIFormatting;
using Microsoft.EntityFrameworkCore;

namespace FootHub.Services.UserServices
{
    public class UserService : IUser
    {
        private FootHubContext _context;

        public UserService(FootHubContext context)
        {
            _context = context;
        }

        public async Task<List<UserTable>> GetUsersList()
        {
            var users = await _context.UserTables.ToListAsync();
            return users;
        }

        public async Task<UserTable> SignUp(UserTable user)
        {
            var check = await _context.UserTables.FirstOrDefaultAsync(u => 
            u.UEmail.Equals(user.UEmail) && u.UPhone.Equals(user.UPhone));
            if(check != null) 
            {
                throw new Exception(UserExecptions.ExceptionMessages["SignUp"]);
            }
            await _context.UserTables.AddAsync(user);
            _context.SaveChanges();
            var addedUser = await _context.UserTables.FindAsync(user.UId);
            return addedUser;
        }

        public async Task<UserTable> Login(string id,string password)
        {
            var user = await _context.UserTables.FirstOrDefaultAsync(u => 
            (u.UPhone.Equals(id) || u.UEmail.Equals(id))
            && u.UPassword.Equals(password));
            if(user == null)
            {
                throw new Exception(UserExecptions.ExceptionMessages["Login"]);
            }
            return user;
        }

        public async Task<string> DeleteAccount(string id, string password)
        {
            var user = await _context.UserTables
                .Include(u => u.CartTables)
                .Include(u => u.OrderLinkTables)
                .Include(u => u.OrderTables)
                .FirstOrDefaultAsync(u =>(u.UPhone.Equals(id) || u.UEmail.Equals(id)) && u.UPassword.Equals(password));
            if (user == null)
            {
                throw new Exception(UserExecptions.ExceptionMessages["Delete"]);
            }

            _context.CartTables.RemoveRange(user.CartTables);
            _context.OrderLinkTables.RemoveRange(user.OrderLinkTables);
            _context.OrderTables.RemoveRange(user.OrderTables);

            _context.UserTables.Remove(user);
            await _context.SaveChangesAsync();
            return "Account Deleted Succesfully";

        }
        public async Task<string> UpdateAccount(string id, string password, UserUpdate user)
        {
            var dbuser = await _context.UserTables.FirstOrDefaultAsync(u =>
            (u.UPhone.Equals(id) || u.UEmail.Equals(id))
            && u.UPassword.Equals(password));
            if (dbuser == null)
            {
                throw new Exception(UserExecptions.ExceptionMessages["Login"]);
            }
            dbuser.UEmail=user.UEmail;
            dbuser.UPhone=user.UPhone;
            dbuser.UPassword=user.UPassword;
            dbuser.UName=user.UName;
            await _context.SaveChangesAsync();
            return "Updated Succesfully";
        }
    }
}
