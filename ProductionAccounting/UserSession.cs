namespace ProductionAccounting
{
    public class UserSession
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }

    public static class AppSession
    {
        public static UserSession CurrentUser { get; set; }

        public static bool IsAuthenticated => CurrentUser != null;

        public static bool HasRole(string roleName)
        {
            return CurrentUser != null && CurrentUser.Role == roleName;
        }

        public static bool HasAnyRole(params string[] roles)
        {
            if (CurrentUser == null) return false;
            foreach (var role in roles)
            {
                if (CurrentUser.Role == role) return true;
            }
            return false;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}