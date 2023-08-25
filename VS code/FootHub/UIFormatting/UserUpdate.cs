namespace FootHub.UIFormatting
{
    public class UserUpdate
    {
        public string UName { get; set; }

        public string UEmail { get; set; }

        public string UPassword { get; set; }

        public string UPhone { get; set; }

        public UserUpdate(string uName, string uEmail, string uPassword, string uPhone)
        {
            UName = uName;
            UEmail = uEmail;
            UPassword = uPassword;
            UPhone = uPhone;
        }
    }
}
