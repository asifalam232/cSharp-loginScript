using System;
namespace loginScript
{
    public class UserInfo
    {
        private string userName;
        private string password;

        public UserInfo(string name, string passwd)
        {
            userName = name;
            password = passwd;
        }

        public String getUserName()
        {
            return userName;
        }

        public void setUserName(string name)
        {
            userName = name;
        }

        public String getPassword()
        {
            return password;
        }
    }
}

