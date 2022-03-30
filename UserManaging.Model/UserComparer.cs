using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManaging.Model
{
    public class UserComparer : IComparer<User>
    {
        public int Compare(User x, User y)
        {
            if (x.Id.CompareTo(y.Id) != 0)
            {
                return x.Id.CompareTo(y.Id);
            }
            else if (x.FirstName.CompareTo(y.FirstName) != 0)
            {
                return x.FirstName.CompareTo(y.FirstName);
            }
            else if (x.LastName.CompareTo(y.LastName) != 0)
            {
                return x.LastName.CompareTo(y.LastName);
            }
            else if (x.MiddleName.CompareTo(y.MiddleName) != 0)
            {
                return x.MiddleName.CompareTo(y.MiddleName);
            }
            else if (x.Phone.CompareTo(y.Phone) != 0)
            {
                return x.Phone.CompareTo(y.Phone);
            }
            else if (x.Email.CompareTo(y.Email) != 0)
            {
                return x.Email.CompareTo(y.Email);
            }
            else
            {
                return 0;
            }
        }
    }
}
