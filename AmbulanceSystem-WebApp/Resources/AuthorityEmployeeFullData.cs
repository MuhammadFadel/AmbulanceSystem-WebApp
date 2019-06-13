using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceSystem_WebApp.Resources
{
    public class AuthorityEmployeeFullData
    {
        public Guid Id { get; set; }
        public UserData UserData { get; set; }
        public AuthorityFullData AuthorityFullData { get; set; }
        public ICollection<NotificationData> NotificationData { get; set; }

        public AuthorityEmployeeFullData()
        {
            NotificationData = new List<NotificationData>();
        }
    }

    public class AuthorityFullData
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
    }
}
