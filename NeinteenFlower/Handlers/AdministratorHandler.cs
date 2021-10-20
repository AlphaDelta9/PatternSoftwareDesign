using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handlers
{
    public class AdministratorHandler
    {
        public static Int32 Where(String AdministratorEmail)
        {
            if (AdministratorEmail.Equals("admin@local.localhost"))
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        public static String Find(Int32 AdministratorId)
        {
            return "Administrator";
        }
        public static Boolean Verify(String AdministratorEmail, String AdministratorPassword)
        {
            if (AdministratorEmail.Equals("admin@local.localhost") && AdministratorPassword.Equals("adminlocal"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}