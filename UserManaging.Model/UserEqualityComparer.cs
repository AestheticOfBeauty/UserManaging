using System.Collections.Generic;

namespace UserManaging.Model
{
    public class UserEqualityComparer : IEqualityComparer<User>
    {
        public bool Equals(User u1, User u2)
        {
            if (u2 == null && u1 == null)
                return true;
            if (u1 == null || u2 == null)
                return false;
            if (u1.FirstName == u2.FirstName
                && u1.LastName == u2.LastName
                && u1.MiddleName == u2.MiddleName
                && u1.Phone == u2.Phone
                && u1.Email == u2.Email)
                return true;
            else
                return false;
        }

        public int GetHashCode(User user)
        {
            return user.GetHashCode();
        }
    }
}
