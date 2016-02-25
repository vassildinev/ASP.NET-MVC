namespace UserVoiceSystem.Services.Web
{
    public class EmailHiderService : IEMailHiderService
    {
        public string HideEmail(string email)
        {
            string[] parts = email.Split('@', '.'); // "pesho", "gmail", "com"
            string username = parts[0];
            string domain = parts[1];

            string result = string.Empty;
            if (username.Length < 4)
            {
                result += username;
            }
            else
            {
                for (int i = 0; i < username.Length; i++)
                {
                    if (i < 3)
                    {
                        result += username[i];
                    }
                    else
                    {
                        result += "*";
                    }
                }
            }

            result += "@";

            if (domain.Length < 4)
            {
                result += domain;
            }
            else
            {
                for (int i = 0; i < domain.Length; i++)
                {
                    if (i < 3)
                    {
                        result += domain[i];
                    }
                    else
                    {
                        result += "*";
                    }
                }
            }

            result += ".";

            result += parts[2];

            return result;
        }
    }
}
