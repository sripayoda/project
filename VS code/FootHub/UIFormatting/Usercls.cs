using FootHub.Models;

namespace FootHub.UIFormatting
{
    public class Usercls
    {
        public int UId { get; set; }

        public string UName { get; set; }

        public string UEmail { get; set; }

        public string UPassword { get; set; }

        public string UPhone { get; set; }

        public string URole { get; set; }

        public int IsAvailable { get; set; }

        public Usercls(UserTable user)
        {
            UId = user.UId;
            UName = user.UName;
            UEmail = user.UEmail;
            UPassword = user.UPassword;
            UPhone = user.UPhone;
            URole = user.URole;
        }

        public static List<Usercls> GetUsers(List<UserTable> users)
        {
            List<Usercls> usersList = new List<Usercls>();
            foreach(UserTable user in users)
            {
                usersList.Add(new Usercls(user));
            }
            return usersList;
        }

        public static Usercls GetUser(UserTable user) 
        {
            return new Usercls(user);
        }
    }
}
