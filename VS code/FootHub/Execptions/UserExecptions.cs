namespace FootHub.Execptions
{
    public class UserExecptions
    {
        public static Dictionary<string, string> ExceptionMessages{ get;} =
            new Dictionary<string, string> { { "SignUp","User Already Exists" },
                {"Login","No User Found yikess.." },{"Delete","Incorrect Credentials"}
            };
    }
}
