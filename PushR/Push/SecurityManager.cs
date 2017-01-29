using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace PushR.Push
{
    public class SecurityManager
    {
        #region Singleton
        private static object _mutex = new object();
        private static SecurityManager _instance = null;
        public static SecurityManager Instance
        {
            get
            {
                if (_instance == null)
                    lock (_mutex)
                        if (_instance == null)
                            _instance = new SecurityManager();

                return _instance;
            }
        }
        #endregion Singleton

        public string Encrypt(string text)
        {
            byte[] data = ProtectedData.Protect(Encoding.Unicode.GetBytes(text), null, DataProtectionScope.LocalMachine);
            return Convert.ToBase64String(data);
        }

        public string Decrypt(string text)
        {
            byte[] data = ProtectedData.Unprotect(Convert.FromBase64String(text), null, DataProtectionScope.LocalMachine);
            return Encoding.Unicode.GetString(data);
        }
    }
}