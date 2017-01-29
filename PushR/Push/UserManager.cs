using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushR.Push
{
    public class UserManager
    {
        #region Singleton
        private static object _mutex = new object();
        private static UserManager _instance = null;
        public static UserManager Instance
        {
            get
            {
                if (_instance == null)
                    lock (_mutex)
                        if (_instance == null)
                            _instance = new UserManager();

                return _instance;
            }
        }
        #endregion Singleton

        internal User testUser = new User{ UserId = "abc123", Username = "Dave" };

        internal User RetrieveUser(string userId)
        {
            if (userId == testUser.UserId)
                return testUser;
            else
                return null;
        }
    }
}